using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gambling_Task
{
    public partial class LooksConfigForm : Form
    {
        MainForm parent;
        LooksConfig current;

        public LooksConfigForm(MainForm sender, LooksConfig looks)
        {
            InitializeComponent();
            parent = sender;
            current = looks;
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                ((Label)sender).BackColor = ColorPicker.Color;
            }
        }

        private void BlinkRateSlider_Scroll(object sender, EventArgs e)
        {
            BlinkRateIndicator.Text = BlinkRateSlider.Value.ToString();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            parent.Looks = CollectInput();
            Close();
        }

        /// <summary>
        /// Creates a new LooksConfig from the data entered in the form.
        /// </summary>
        /// <returns></returns>
        private LooksConfig CollectInput()
        {
            Color leftBtnBGColor = LeftBG.BackColor;
            Color leftBtnFGColor = LeftFG.BackColor;
            string leftBtnLabel = LeftLabel.Text;
            Color centerBtnBGColor = CenterBG.BackColor;
            Color centerBtnFGColor = CenterFG.BackColor;
            string centerBtnLabel = CenterLabel.Text;
            Color rightBtnBGColor = RightBG.BackColor;
            Color rightBtnFGColor = RightFG.BackColor;
            string rightBtnLabel = RightLabel.Text;

            Color slotsBGColor = SlotsBG.BackColor;
            Color slotsFGColor = SlotsFG.BackColor;
            int slotsBlinkRate = BlinkRateSlider.Value;

            Color windowBGColor = WindowBG.BackColor;
            bool activeBtnsOnly = ActiveButtons.Checked;
            bool activeSlotsOnly = ActiveSlots.Checked;

            return new LooksConfig(
                leftBtnBGColor, leftBtnFGColor, leftBtnLabel,
                centerBtnBGColor, centerBtnFGColor, centerBtnLabel,
                rightBtnBGColor, rightBtnFGColor, rightBtnLabel,
                slotsBGColor, slotsFGColor, slotsBlinkRate,
                windowBGColor, activeBtnsOnly, activeSlotsOnly
                );
        }

        /// <summary>
        /// Updates the UI to match the current LooksConfig from MainForm.
        /// </summary>
        private void LoadCurrent()
        {
            LeftBG.BackColor = current.LeftBtnBGColor;
            LeftFG.BackColor = current.LeftBtnFGColor;
            LeftLabel.Text = current.LeftBtnLabel;
            CenterBG.BackColor = current.CenterBtnBGColor;
            CenterFG.BackColor = current.CenterBtnFGColor;
            CenterLabel.Text = current.CenterBtnLabel;
            RightBG.BackColor = current.RightBtnBGColor;
            RightFG.BackColor = current.RightBtnFGColor;
            RightLabel.Text = current.RightBtnLabel;

            SlotsBG.BackColor = current.SlotsBGColor;
            SlotsFG.BackColor = current.SlotsFGColor;
            BlinkRateSlider.Value = current.SlotsBlinkRate;

            WindowBG.BackColor = current.WindowBGColor;
            ActiveButtons.Checked = current.ActiveBtnsOnly;
            ActiveSlots.Checked = current.ActiveSlotsOnly;

            BlinkRateIndicator.Text = BlinkRateSlider.Value.ToString();
        }

        private void LooksConfigForm_Load(object sender, EventArgs e)
        {
            LoadCurrent();
        }
    }
}
