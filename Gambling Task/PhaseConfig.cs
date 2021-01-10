using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling_Task
{

    /// <summary>
    /// Data structure class containing the various options which define the behavior of a phase of trials.
    /// </summary>
    [Serializable]
    public class PhaseConfig
    {
        /// <summary>
        /// Default public class constructor
        /// </summary>
        public PhaseConfig()
        {
            Slots = new bool[3] {true, true, true};
            Schedule = new int[3] { 1, 1, 8 };
            RewardAmount = 10;
            RewardButton = 1;
            Timeout = 10;
            TimeoutButton = 1;
            StartCond = new int[2] { 1, 0 };
            ProgressCond = new int[6] { 0, 0, 0, 0, 0, 0 };
        }

        /// <summary>
        /// Public class constructor
        /// </summary>
        /// <param name="slots">Indicates the status of each slot, with [0] being the leftmost slot.</param>
        /// <param name="schedule">Indicates success schedule type. [0]=0 is fixed-rate and [0]=1 is variabled-rate. Subsequent indices are the parameters of the selected mode.</param>
        /// <param name="rewardAmount">Indicates number of pellets to be dispensed.</param>
        /// <param name="rewardButton">Indicates which button will give reward.</param>
        /// <param name="timeout">Indicates number of seconds to wait during timeout period.</param>
        /// <param name="timeoutButton">Indicates which button will cause timeout.</param>
        /// <param name="startCond">Indicates trial start mode. [0]=0 is automatic, [0]=1 is conditional, and [0]=3 is after pellet collection. Subsequent indices are the parameters of the selected mode.</param>
        /// <param name="progressCond">Indicates phase progression mode. [0]=0 is no phase progress and [0]=1 is conditional. Subsequent indices are the parameters of the selected mode.</param>
        public PhaseConfig(bool[] slots, int[] schedule, int rewardAmount, int rewardButton, int timeout, int timeoutButton, int[] startCond, int[] progressCond)
        {
            Slots = slots;
            Schedule = schedule;
            RewardAmount = rewardAmount;
            RewardButton = rewardButton;
            Timeout = timeout;
            TimeoutButton = timeoutButton;
            StartCond = startCond;
            ProgressCond = progressCond;
        }

        public bool[] Slots { get; }
        public int[] Schedule { get; }
        public int RewardAmount { get; }
        public int RewardButton { get; }
        public int Timeout { get; }
        public int TimeoutButton { get; }
        public int[] StartCond { get; }
        public int[] ProgressCond { get; }
    }
}
