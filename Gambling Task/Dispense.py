import sys                

if len(sys.argv) < 2:
    print("Count argument missing. Aborting.")
else:
    print("Dispensing " + str(sys.argv[1]) + " pellets...")