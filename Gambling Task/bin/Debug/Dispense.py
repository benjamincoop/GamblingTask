import sys                
import time
import board
from adafruit_motorkit import MotorKit
     
kit = MotorKit(i2c=board.I2C())
     
for i in range(sys.argv[1]):
    kit.stepper1.onestep()
    time.sleep(0.01)