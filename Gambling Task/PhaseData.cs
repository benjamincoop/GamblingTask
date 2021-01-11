using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling_Task
{
    public class PhaseData
    {
        public PhaseData()
        {
            NumTrials = 0;
            NumSuccessStates = 0;
            NumCorrect = 0;
            NumIncorrect = 0;
            Time = 0;
            ButtonsPressed = new List<string>();
            SlotOutcomes = new List<int[]>();
        }

        public int NumTrials { get; set; }
        public int NumSuccessStates { get; set; }
        public int NumCorrect { get; set; }
        public int NumIncorrect { get; set; }
        public int Time { get; set; }
        public List<string> ButtonsPressed { get; set; }
        public List<int[]> SlotOutcomes { get; set; }
    }
}
