import sys
sys.path.append("/home/sftpuser")
sys.path.append("/home/student/gitrepo/pyspark_ds/signalr")
from pyspark.sql import SparkSession
from signalr_client import send_progress, send_solution, send_update
import input_file
import atexit
from signalrcore.hub_connection_builder import HubConnectionBuilder
import threading
import time
from pyspark import AccumulatorParam

		#.config("spark.executor.instances", "1") \


def main():
	spark = SparkSession.builder \
		.appName("pbf") \
		.master("spark://172.16.3.2:7077") \
		.getOrCreate()
	sc = spark.sparkContext
	sc.addPyFile(f"/home/sftpuser/input_file.py")
	sc.setLogLevel("INFO")
	atexit.register(lambda: sc.stop())

	def stop_spark():
		exit()


	def worker_count():
		time.sleep(5)
		active_executors = sc._jsc.sc().getExecutorMemoryStatus().size()
		return active_executors - 1


	class StringAccumulatorParam(AccumulatorParam):
		def zero(self, initialValue=""):
			return initialValue

		def addInPlace(self, v1, v2):
			return v1 + v2

	active_workers = worker_count()
	workers = sc.broadcast(active_workers)
	result_acc = sc.accumulator("", StringAccumulatorParam())
	progress_accumulator = sc.accumulator(0)
	switch = sc.accumulator(0)
	total_possibilities = input_file.input_data()
	total_possibilities_bc = sc.broadcast(total_possibilities)

	data_list = list(range(1, active_workers + 1))
	data_rdd = spark.sparkContext.parallelize(data_list, active_workers)


	def process_data(input_function, data_value, accumulator, switch, result_acc):
		for i in range(data_value, total_possibilities_bc.value, workers.value):
			result = input_function(i)
			print(result)
			accumulator.add(1)

			if result[1]:
				result_acc.add(result[0])
				switch.add(1)
				return result

		return [f"{data_value}, {total_possibilities_bc.value}, {workers.value}", False]

	def monitor_progress(switch, progress_accumulator, total_possibilities):
		start_timer = time.time()
		print("Setup complete, progress monitoring on")
		send_update(["Cluster innitialized, progress monitoring ON"])
		previous_percentage = 0
		while progress_accumulator.value <  total_possibilities and switch.value == 0:
			current_percentage = int(progress_accumulator.value / total_possibilities * 100)
			if current_percentage > previous_percentage:
				print(f"Progress: {current_percentage}%")
				send_progress([current_percentage, progress_accumulator.value])
				previous_percentage = current_percentage
				if switch.value > 0:
					break
			time.sleep(0.01)

		print(f"Success: {result_acc}")
		send_solution([result_acc.value, round(time.time() - start_timer, 3), progress_accumulator.value])
		stop_spark()

	progress_thread = threading.Thread(target=monitor_progress, args=(switch, progress_accumulator, total_possibilities))
	progress_thread.start()

	result = data_rdd.map(lambda x: process_data(input_file.input_function, x, progress_accumulator, switch, result_acc)).collect()
	print(result)

	progress_thread.join()


if __name__ == '__main__':
	main()
