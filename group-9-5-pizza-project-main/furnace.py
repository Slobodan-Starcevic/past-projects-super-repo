'''
Smart furnace mock implementation

Backend API description:

Take a pizza from the backend and cook it.
-> GET /api/item/take
<- 200, {
    "cook_time": 300,
    "id": 1234
}

Inform the backend that the pizza (with id item_id) is complete
-> POST /api/item/<item_id>/complete
<- 200, Ok

An "item" is a single pizza, with at least a cook time and an unique id.
'''
import time
from fhict_cb_01.CustomPymata4 import CustomPymata4
import platform
import requests

DEBOUNCE = 250
API_URL = "http://127.0.0.1:5000"
BUZZER_PIN = 3
LEFT_BUTTON_PIN = 9

if platform.system() == "Linux":
    COM_PORT = "/dev/ttyUSB0"
elif platform.system() == "Windows":
    COM_PORT = "COM8"
elif platform.system() == "Darwin":
    COM_PORT = input("Enter arduino com port: ")

last_debounce = 0
timer = 0
current_item = None

def button_pressed(e):
    global last_debounce
    _, _, val, timestamp = e
    timestamp *= 1000
    if timestamp - last_debounce > DEBOUNCE and val == 1: # keyup
        last_debounce = timestamp
        take_item()

def take_item():
    global timer
    global current_item
    if timer > 0 or current_item is not None:
        return
    try:
        resp = requests.get(f"{API_URL}/api/item/take")
        if resp.status_code == 503:
            print("No items available")
            return
        data = resp.json()
        current_item = data
        timer = data["cook_time"]
    except requests.exceptions.ConnectionError:
        print("Server not running")
        return


def mark_as_complete():
    global current_item
    try:
        resp = requests.post(f"{API_URL}/api/item/{current_item['id']}/complete")
        current_item = None
    except requests.exceptions.ConnectionError:
        print("Server not running")
        return


def setup():
    global board
    board = CustomPymata4(com_port=COM_PORT)
    board.set_pin_mode_digital_input_pullup(LEFT_BUTTON_PIN, button_pressed)
    board.set_pin_mode_pwm_output(BUZZER_PIN)


def buzz(duration=0.5):
    board.pwm_write(BUZZER_PIN, 2)
    time.sleep(duration)
    board.pwm_write(BUZZER_PIN, 0)


def loop():
    global timer
    if timer > 0:
        timer -= 1
        board.displayShow(str(timer).rjust(4))
        if timer == 0:
            mark_as_complete()
            buzz()

if __name__ == "__main__":
    setup()
    while True:
        loop()
        time.sleep(0.5)