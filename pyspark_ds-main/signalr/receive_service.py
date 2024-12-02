import os
import subprocess
import logging


logging.basicConfig(
	filename=os.path.expanduser("~/error.txt"),
	filemode='a',
	level=logging.ERROR,
	format='%(asctime)s - %(levelname)s - %(message)s'
)

def receive_file_name(file_name):
	file = file_name[0]
	print(f"file received {file}")
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
