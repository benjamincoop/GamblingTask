using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling_Task
{
    /// <summary>
    /// Data structure class containing the various options which define the look of the main UI.
    /// </summary>
    [Serializable]
    public class LooksConfig
    {
        /// <summary>
        /// Default public class constructor
        /// </summary>
        public LooksConfig()
        {
            LeftBtnBGColor = Color.Red;
            CenterBtnBGColor = Color.Yellow;
            RightBtnBGColor = Color.Green;
            LeftBtnFGColor = Color.Black;
            CenterBtnFGColor = Color.Black;
            RightBtnFGColor = Color.Black;
            LeftBtnLabel = "Roll";
            CenterBtnLabel = "Other";
            RightBtnLabel = "Collect";

            SlotsBGColor = Color.Black;
            SlotsFGColor = Color.White;
            SlotsBlinkRate = 2;

            WindowBGColor = Color.Black;
            ActiveBtnsOnly = true;
            ActiveSlotsOnly = true;
        }

        /// <summary>
        /// Public class constructor
        /// </summary>
        /// <param name="leftBtnBGColor"></param>
        /// <param name="leftBtnFGColor"></param>
        /// <param name="leftBtnLabel"></param>
        /// <param name="centerBtnBGColor"></param>
        /// <param name="centerBtnFGColor"></param>
        /// <param name="centerBtnLabel"></param>
        /// <param name="rightBtnBGColor"></param>
        /// <param name="rightBtnFGColor"></param>
        /// <param name="rightBtnLabel"></param>
        /// <param name="slotsBGColor"></param>
        /// <param name="slotsFGColor"></param>
        /// <param name="slotsBlinkRate"></param>
        /// <param name="windowBGColor"></param>
        /// <param name="activeBtnsOnly"></param>
        /// <param name="activeSlotsOnly"></param>
        public LooksConfig(
            Color leftBtnBGColor, Color leftBtnFGColor, string leftBtnLabel,
            Color centerBtnBGColor, Color centerBtnFGColor, string centerBtnLabel,
            Color rightBtnBGColor, Color rightBtnFGColor, string rightBtnLabel,
            Color slotsBGColor, Color slotsFGColor, int slotsBlinkRate,
            Color windowBGColor, bool activeBtnsOnly, bool activeSlotsOnly
            )
        {
            LeftBtnBGColor = leftBtnBGColor;
            CenterBtnBGColor = centerBtnBGColor;
            RightBtnBGColor = rightBtnBGColor;
            LeftBtnFGColor = leftBtnFGColor;
            CenterBtnFGColor = centerBtnFGColor;
            RightBtnFGColor = rightBtnFGColor;
            LeftBtnLabel = leftBtnLabel;
            CenterBtnLabel = centerBtnLabel;
            RightBtnLabel = rightBtnLabel;

            SlotsBGColor = slotsBGColor;
            SlotsFGColor = slotsFGColor;
            SlotsBlinkRate = slotsBlinkRate;

            WindowBGColor = windowBGColor;
            ActiveBtnsOnly = activeBtnsOnly;
            ActiveSlotsOnly = activeSlotsOnly;
        }

        /// <summary>
        /// Converts slot blink rate (Hz) to a timer tick interval (ms)
        /// </summary>
        /// <returns></returns>
        public int GetTimerInterval()
        {
            if(SlotsBlinkRate > 0)
            {
                return 1000 / (SlotsBlinkRate * 2);
            } else
            {
                throw new ArgumentOutOfRangeException();
            }
            
        }

        public Color LeftBtnBGColor { get; }
        public Color LeftBtnFGColor { get; }
        public string LeftBtnLabel { get; }
        public Color CenterBtnBGColor { get; }
        public Color CenterBtnFGColor { get; }
        public string CenterBtnLabel { get; }
        public Color RightBtnBGColor { get; }
        public Color RightBtnFGColor { get; }
        public string RightBtnLabel { get; }

        public Color SlotsBGColor { get; }
        public Color SlotsFGColor { get; }
        public int SlotsBlinkRate { get; }

        public Color WindowBGColor { get; }
        public bool ActiveBtnsOnly { get; }
        public bool ActiveSlotsOnly { get; }
    }
}
