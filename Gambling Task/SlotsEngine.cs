using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling_Task
{
    public class SlotsEngine
    {
        private Random rand; // Random class instance
        private int[] schedule; // The parameters to be used in the simulation
        private int numSlots = 0; // The number of active slots in the simulation
        private int trialCount; // The number of trials elapsed since last reward (for fixed-ratio schedule)

        // Mapping of possible outcomes for the various versions of the simulation.
        private static readonly int[] zeroOrOneSlotFail = { 0 };
        private static readonly int[,] twoSlotFails = { { 0, 0 }, { 0, 1 }, { 1, 0 } };
        private static readonly int[,] threeSlotFails = { { 0, 0, 0 }, { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 }, { 1, 0, 1 }, { 1, 1, 0 }, { 0, 1, 1 } };
        private static readonly int[] zeroOrOneSlotSuccess = { 1 };
        private static readonly int[] twoSlotSuccess = { 1, 1 };
        private static readonly int[] threeSlotSuccess = { 1, 1, 1 };

        public SlotsEngine(bool[] slots, int[] config)
        {
            rand = new Random();
            schedule = config;

            // Count numSlots
            foreach (bool b in slots)
            {
                if(b)
                {
                    numSlots++;
                }
            }
        }

        /// <summary>
        /// Checks a roll result array to determine if it represents a success-state.
        /// </summary>
        /// <param name="roll"></param>
        /// <returns></returns>
        public static bool CheckRoll(int[] roll)
        {
            foreach(int i in roll)
            {
                if(i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Simulates a slot machine roll and returns an int array reprsenting the status of each slot.
        /// </summary>
        /// <returns></returns>
        public int[] Roll()
        {
            if (schedule[0] == 0) // Fixed-ratio
            {
                switch (numSlots)
                {
                    case 3:
                        if (trialCount == schedule[1])
                        {
                            trialCount = 0;
                            return threeSlotSuccess;
                        }
                        else
                        {
                            trialCount++;
                            int i = rand.Next(0, 7);
                            return new int[] { threeSlotFails[i, 0], threeSlotFails[i, 1], threeSlotFails[i, 2] };
                        }
                    case 2:
                        if (trialCount == schedule[1])
                        {
                            trialCount = 0;
                            return twoSlotSuccess;
                        }
                        else
                        {
                            trialCount++;
                            int i = rand.Next(0, 3);
                            return new int[] { twoSlotFails[i, 0], twoSlotFails[i, 1] };
                        }
                    case 1:
                        if (trialCount == schedule[1])
                        {
                            trialCount = 0;
                            return zeroOrOneSlotSuccess;
                        }
                        else
                        {
                            trialCount++;
                            return zeroOrOneSlotFail;
                        }
                    case 0:
                        if (trialCount == schedule[1])
                        {
                            trialCount = 0;
                            return zeroOrOneSlotSuccess;
                        }
                        else
                        {
                            trialCount++;
                            return zeroOrOneSlotFail;
                        }
                }
            } else // Variable-ratio
            {
                // roll is a random int inclusive between 1 and variable-ratio denominator
                int roll = rand.Next(1, schedule[2] + 1);
                if(roll <= schedule[1]) // success
                {
                    switch(numSlots)
                    {
                        case 3:
                            return threeSlotSuccess;
                        case 2:
                            return twoSlotSuccess;
                        case 1:
                            return zeroOrOneSlotSuccess;
                        case 0:
                            return zeroOrOneSlotSuccess;
                    }
                } else // fail
                {
                    switch(numSlots)
                    {
                        case 3:
                            int x = rand.Next(0, 7);
                            return new int[] { threeSlotFails[x, 0], threeSlotFails[x, 1], threeSlotFails[x, 2] };
                        case 2:
                            int y = rand.Next(0, 3);
                            return new int[] { twoSlotFails[y, 0], twoSlotFails[y, 1] };
                        case 1:
                            return zeroOrOneSlotFail;
                        case 0:
                            return zeroOrOneSlotFail;
                    }
                }
            }
            // something's gone terribly wrong if this point is reached
            return new int[] { -1 };
        }

    }
}
