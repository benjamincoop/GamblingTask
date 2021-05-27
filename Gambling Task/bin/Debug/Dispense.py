import sys
import time
import board
import RPi.GPIO as GPIO
from adafruit_motorkit import MotorKit

BEAM_PIN = 17
kit = MotorKit(i2c=board.I2C())

# the number of pellets dispensed this execution
count = 0

# flag indicating that the sensor has been tripped
beamBroken = False

# sets the beamBroken flag to true if the sensor beam is newly broken
def break_beam_callback(channel):
    global beamBroken
    if beamBroken == False and  GPIO.input(BEAM_PIN) == False:
        # beam is broken
        beamBroken = True

# set up break beam sensor trigger event
GPIO.setmode(GPIO.BCM)
GPIO.setup(BEAM_PIN, GPIO.IN, pull_up_down=GPIO.PUD_UP)
GPIO.add_event_detect(BEAM_PIN, GPIO.BOTH, callback=break_beam_callback)

if len(sys.argv) != 2:
    print("Missing argument: count")
else:
    # loop until we've dispensed the right number of pellets
    while count < int(sys.argv[1]):
        if beamBroken:
          count += 1
          beamBroken = False
        else:
          kit.stepper1.onestep()
          time.sleep(0.03)

kit.stepper1.release()
GPIO.cleanup()
