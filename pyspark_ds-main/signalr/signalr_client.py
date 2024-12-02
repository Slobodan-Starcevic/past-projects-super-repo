import time
from signalrcore.hub_connection_builder import HubConnectionBuilder
import os
import subprocess
import logging

connection = HubConnectionBuilder() \
		.with_url("https://172.16.1.3:8081/file") \
		.build()
connection.start()

logging.basicConfig(
	filename=os.path.expanduser("~/error.txt"),
	filemode='a',
	level=logging.ERROR,
	format='%(asctime)s - %(levelname)s - %(message)s'
)

def main():
	global connection
	connection.on("ReceiveFile", receive_file_name)

	try:
		while True:
			time.sleep(1)
	except KeyboardInterrupt:
		print("SignalR client stopped")
	finally:
		connection.stop()

def receive_file_name(file_name):
	file = file_name[0]
	print(f"File received: {file}")
	send_update(["File received successfully"])
	spark_path = os.path.expanduser("~/gitrepo/pyspark_ds/spark.py")
	sanitized_file_name = os.path.basename(file)

	process = subprocess.Popen(
		["spark-submit", spark_path, sanitized_file_name],
		stdout=subprocess.PIPE,
		stderr=subprocess.PIPE,
		text=True,
		bufsize=1
	)

	with process.stdout:
		for line in iter(process.stdout.readline, ''):
			print(line, end='')

	process.wait()

	stderr_output = process.stderr.read()
	if process.returncode != 0:
		error = f"Error running spark job: {process.stderr}"
		print(error)
		logging.error(error_message)
	else:
		print("Spark job completed")

def send_progress(progress):
	global connection
	connection.send("SendProgress", progress)

def send_solution(solution):
	global connection
	connection.send("SendSolution", solution)

def send_update(update):
	global connection
	connection.send("SendUpdate", update)

if __name__ == "__main__":
	main()
