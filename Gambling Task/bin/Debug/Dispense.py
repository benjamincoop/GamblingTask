import sys
import time
import board
import digitalio
from adafruit_motorkit import MotorKit

kit = MotorKit(i2c=board.I2C())

# break beam sensor -> GPIO #5
break_beam = digitalio.DigitalInOut(board.D5)
break_beam.direction = digitalio.Direction.INPUT
break_beam.pull = digitalio.Pull.UP

# tracks number of pellets dispensed
count = 0

if len(sys.argv) != 2:
	print("Incorrect number of arguments!")
else:
    # loop until we have dispensed the correct number of pellets
	while count < sys.argv[1]:
        # take 5 motor steps, with a tiny break between each
		for i in range(5):
			kit.stepper1.onestep()
            time.sleep(0.01)
        # if break beam is triggered, increment count
        if break_beam.value:
            count += 1
