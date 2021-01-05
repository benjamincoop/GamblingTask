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
    public partial class MainForm : Form
    {
        int activeSlot = 1;
        int timeoutTime = 10;
        Form phaseEditor = new NewPhase();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Roll()
        {

        }

        private void ActivateButton(object button)
        {

        }

        private void DectivateButton(object button)
        {

        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            Slot1.BackColor = Color.Black;
            Slot2.BackColor = Color.Black;
            Slot3.BackColor = Color.Black;
            LeftButton.Enabled = false;
            RightButton.Enabled = false;
            LeftButton.ForeColor = Color.DimGray;
            LeftButton.BackColor = Color.Gray;
            RightButton.ForeColor = Color.DimGray;
            RightButton.BackColor = Color.Gray;
            BlinkTimer.Enabled = true;
            Slot1.Enabled = true;
        }

        private void CollectButton_Click(object sender, EventArgs e)
        {

        }

        private void SlotBlinkTimer_Tick(object sender, EventArgs e)
        {
            switch (activeSlot)
            {
                case 1:
                    if(Slot1.BackColor == Color.Black)
                    {
                        Slot1.BackColor = Color.White;
                    } else
                    {
                        Slot1.BackColor = Color.Black;
                    }
                    break;
                case 2:
                    if (Slot2.BackColor == Color.Black)
                    {
                        Slot2.BackColor = Color.White;
                    }
                    else
                    {
                        Slot2.BackColor = Color.Black;
                    }
                    break;
                case 3:
                    if (Slot3.BackColor == Color.Black)
                    {
                        Slot3.BackColor = Color.White;
                    }
                    else
                    {
                        Slot3.BackColor = Color.Black;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Slot1_Click(object sender, EventArgs e)
        {
            activeSlot = 2;
            Slot1.Enabled = false;
            Slot2.Enabled = true;
            if(CoinFlip())
            {
                Slot1.BackColor = Color.White;
            } else
            {
                Slot1.BackColor = Color.Black;
            }
        }

        private void Slot2_Click(object sender, EventArgs e)
        {
            activeSlot = 3;
            Slot2.Enabled = false;
            Slot3.Enabled = true;
            if (CoinFlip())
            {
                Slot2.BackColor = Color.White;
            }
            else
            {
                Slot2.BackColor = Color.Black;
            }
        }

        private void Slot3_Click(object sender, EventArgs e)
        {
            activeSlot = 1;
            BlinkTimer.Enabled = false;
            Slot3.Enabled = false;

            if (CoinFlip())
            {
                Slot3.BackColor = Color.White;
            }
            else
            {
                Slot3.BackColor = Color.Black;
            }

            LeftButton.Enabled = true;
            RightButton.Enabled = true;
            LeftButton.ForeColor = Color.Black;
            LeftButton.BackColor = Color.Red;
            RightButton.ForeColor = Color.Black;
            RightButton.BackColor = Color.Green;
        }

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            timeoutTime -= 1;
            if(timeoutTime == 0)
            {
                TimeoutTimer.Enabled = false;
                LeftButton.Enabled = true;
                LeftButton.ForeColor = Color.Black;
                LeftButton.BackColor = Color.Red;
                LeftButton.Text = "Roll";
                timeoutTime = 10;
                Slot1.BackColor = Color.Black;
                Slot2.BackColor = Color.Black;
                Slot3.BackColor = Color.Black;
            } else
            {
                LeftButton.Text = timeoutTime.ToString();
            }
        }

        private bool CoinFlip()
        {
            Random rand = new Random();
            int t = rand.Next(2);
            if(t > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void MenuFileNew_Click(object sender, EventArgs e)
        {
            phaseEditor.Show();
        }
    }
}
