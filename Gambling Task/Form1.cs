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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuActionsStart_Click(object sender, EventArgs e)
        {
            MenuActionsStart.Enabled = false;
            MenuActionsStop.Enabled = true;
            RollButton.ForeColor = Color.Black;
            RollButton.BackColor = Color.Red;
            RollButton.Enabled = true;
            CollectButton.ForeColor = Color.Black;
            CollectButton.BackColor = Color.Green;
            CollectButton.Enabled = true;
        }

        private void MenuActionsStop_Click(object sender, EventArgs e)
        {
            MenuActionsStop.Enabled = false;
            MenuActionsStart.Enabled = true;
            RollButton.ForeColor = Color.DimGray;
            RollButton.BackColor = Color.Gray;
            RollButton.Enabled = false;
            CollectButton.ForeColor = Color.DimGray;
            CollectButton.BackColor = Color.Gray;
            CollectButton.Enabled = false;
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            Slot1.BackColor = Color.Black;
            Slot2.BackColor = Color.Black;
            Slot3.BackColor = Color.Black;
            RollButton.Enabled = false;
            CollectButton.Enabled = false;
            RollButton.ForeColor = Color.DimGray;
            RollButton.BackColor = Color.Gray;
            CollectButton.ForeColor = Color.DimGray;
            CollectButton.BackColor = Color.Gray;
            SlotBlinkTimer.Enabled = true;
            Slot1.Enabled = true;
        }

        private void CollectButton_Click(object sender, EventArgs e)
        {
            if(Slot1.BackColor == Color.White & Slot2.BackColor == Color.White & Slot3.BackColor == Color.White)
            {
                MessageBox.Show("Reward dispensed!");
                CollectButton.Enabled = false;
                CollectButton.ForeColor = Color.DimGray;
                CollectButton.BackColor = Color.Gray;
                Slot1.BackColor = Color.Black;
                Slot2.BackColor = Color.Black;
                Slot3.BackColor = Color.Black;
            } else
            {
                RollButton.Enabled = false;
                CollectButton.Enabled = false;
                RollButton.ForeColor = Color.DimGray;
                RollButton.BackColor = Color.Gray;
                CollectButton.ForeColor = Color.DimGray;
                CollectButton.BackColor = Color.Gray;
                RollButton.Text = timeoutTime.ToString();
                TimeoutTimer.Enabled = true;
            }
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
            SlotBlinkTimer.Enabled = false;
            Slot3.Enabled = false;

            if (CoinFlip())
            {
                Slot3.BackColor = Color.White;
            }
            else
            {
                Slot3.BackColor = Color.Black;
            }

            RollButton.Enabled = true;
            CollectButton.Enabled = true;
            RollButton.ForeColor = Color.Black;
            RollButton.BackColor = Color.Red;
            CollectButton.ForeColor = Color.Black;
            CollectButton.BackColor = Color.Green;
        }

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            timeoutTime -= 1;
            if(timeoutTime == 0)
            {
                TimeoutTimer.Enabled = false;
                RollButton.Enabled = true;
                RollButton.ForeColor = Color.Black;
                RollButton.BackColor = Color.Red;
                RollButton.Text = "Roll";
                timeoutTime = 10;
                Slot1.BackColor = Color.Black;
                Slot2.BackColor = Color.Black;
                Slot3.BackColor = Color.Black;
            } else
            {
                RollButton.Text = timeoutTime.ToString();
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
    }
}
