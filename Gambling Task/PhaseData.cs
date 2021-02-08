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
            PhaseTime = 0;
            SlotsTime = new List<int>();
            ButtonTime = new List<int>();
            ButtonsPressed = new List<string>();
            SlotOutcomes = new List<int[]>();
            TrialResults = new List<string>();
        }

        public int NumTrials { get; set; }
        public int NumSuccessStates { get; set; }
        public int NumCorrect { get; set; }
        public int NumIncorrect { get; set; }
        public int PhaseTime { get; set; }
        public List<int> SlotsTime { get; set; }
        public List<int> ButtonTime { get; set; }
        public List<string> ButtonsPressed { get; set; }
        public List<int[]> SlotOutcomes { get; set; }
        public List<string> TrialResults { get; set; }

        /// <summary>
        /// Returns a string representation of this object that can then be exported to a text file.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public string Serialize(PhaseConfig config)
        {
            StringBuilder sb = new StringBuilder();
            for (int t = 0; t < NumTrials; t++)
            {
                sb.AppendLine(
                    SerializeSlots(SlotOutcomes[t]) + ","
                    + SlotsTime[t] + ","
                    + ButtonsPressed[t] + ","
                    + ButtonTime[t] + ","
                    + TrialResults[t] + ","
                );
            }
            return sb.ToString();
        }

        private string SerializeSlots(int[] slots)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            for(int i=slots.Length-1; i>-1; i--)
            {
                if(slots[i] == 1)
                {
                    sb.Append("1 ");
                } else
                {
                    sb.Append("0 ");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
