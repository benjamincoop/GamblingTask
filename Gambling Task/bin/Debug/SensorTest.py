import sys
import time
import board
import digitalio

# break beam sensor -> GPIO #5
break_beam = digitalio.DigitalInOut(board.D5)
break_beam.direction = digitalio.Direction.INPUT
break_beam.pull = digitalio.Pull.UP

# print message if beam is broken, wait one second to prevent repeat detections
while True:
  if break_beam.value:
    print("Beam broken!")
    time.sleep(1000)
