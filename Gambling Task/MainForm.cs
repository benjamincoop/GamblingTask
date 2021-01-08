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
        enum TrialStage { Stopped, Starting, Started, PreTrialDelay, WaitingForStartButton, WaitingForSlot, WaitingForCollectButton, TimeoutDelay}

        public PhaseConfig Phase { get; set; }
        public LooksConfig Looks { get; set; }
        private SlotsEngine engine;
        private Button[] slots;
        private Button[] buttons;
        private TrialStage stage = TrialStage.Stopped;
        private int activeSlot = 0; // index of current slot in slots[]
        private int numSlots = 0; // the number of slots to be pressed
        private int[] result; // the outcome of the slot spin.

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Makes the active slot blink at regular intervals.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlotBlinkTimer_Tick(object sender, EventArgs e)
        {
            BlinkSlot(slots[activeSlot]);
        }

        /// <summary>
        /// Toggles the foreground and background colors of the given slot.
        /// </summary>
        /// <param name="slot"></param>
        private void BlinkSlot(Button slot)
        {
            if (slot.BackColor == Looks.SlotsBGColor)
            {
                slot.BackColor = Looks.SlotsFGColor;
            }
            else
            {
                slot.BackColor = Looks.SlotsBGColor;
            }
        }

        /// <summary>
        /// Handles request for PhaseConfigForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPhaseConfig(object sender, EventArgs e)
        {
            Form phaseEditor;
            bool modified;

            if (((ToolStripMenuItem)sender).Text == "Phase") {
                phaseEditor = new PhaseConfigForm(this, Phase);
                modified = true;
            } else
            {
                phaseEditor = new PhaseConfigForm(this);
                modified = false;
            }
            
            DialogResult result = phaseEditor.ShowDialog();
            if (result == DialogResult.OK)
            {
                UpdateEngine();
                if(modified)
                {
                    MessageBox.Show("Phase configuration updated.");
                } else
                {
                    MessageBox.Show("Phase configuration created.");
                }
                UpdateLooks();
            }
            else
            {
                MessageBox.Show("Operation aborted.");
            }
            phaseEditor.Dispose();
        }

        /// <summary>
        /// Handles request for LooksConfigForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuConfigUI_Click(object sender, EventArgs e)
        {
            Form looksEditor = new LooksConfigForm(this, Looks);
            DialogResult result = looksEditor.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Looks configuration loaded.");
                UpdateLooks();
            }
            else
            {
                MessageBox.Show("Operation aborted.");
            }
            looksEditor.Dispose();
        }

        /// <summary>
        /// Initalize variables, set default phase and UI configurations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            slots = new Button[3] { Slot1, Slot2, Slot3 };
            buttons = new Button[3] { LeftButton, RightButton, CenterButton };
            Phase = new PhaseConfig(); 
            Looks = new LooksConfig();
            UpdateEngine();
            UpdateLooks();
        }

        /// <summary>
        /// Sets UI looks from current LooksConfig.
        /// </summary>
        private void UpdateLooks()
        {
            BackColor = Looks.WindowBGColor;
            LeftButton.BackColor = Looks.LeftBtnBGColor;
            CenterButton.BackColor = Looks.CenterBtnBGColor;
            RightButton.BackColor = Looks.RightBtnBGColor;
            LeftButton.ForeColor = Looks.LeftBtnFGColor;
            CenterButton.ForeColor = Looks.CenterBtnFGColor;
            RightButton.ForeColor = Looks.RightBtnFGColor;
            LeftButton.Text = Looks.LeftBtnLabel;
            CenterButton.Text = Looks.CenterBtnLabel;
            RightButton.Text = Looks.RightBtnLabel;

            Slot1.BackColor = Looks.SlotsBGColor;
            Slot2.BackColor = Looks.SlotsBGColor;
            Slot3.BackColor = Looks.SlotsBGColor;

            // disable buttons
            LeftButton.Enabled = false;
            CenterButton.Enabled = false;
            RightButton.Enabled = false;

            // hide slots
            if(Looks.ActiveSlotsOnly)
            {
                Slot1.Visible = false;
                Slot2.Visible = false;
                Slot3.Visible = false;
            } else // show slots
            {
                for(int i=0; i<3; i++)
                {
                    slots[i].Visible = Phase.Slots[i];
                }
            }

            // hide or show buttons
            if(Looks.ActiveBtnsOnly)
            {
                LeftButton.Visible = false;
                CenterButton.Visible = false;
                RightButton.Visible = false;
            } else
            {
                LeftButton.Visible = true;
                CenterButton.Visible = true;
                RightButton.Visible = true;
            }
        }

        /// <summary>
        /// Updates SlotEngine with latest PhaseConfig.
        /// </summary>
        private void UpdateEngine()
        {
            engine = new SlotsEngine(Phase.Slots, Phase.Schedule);
        }

        private void SlotClick(object sender, EventArgs e)
        {
            // Advance trial if active slot is clicked.
            Button slot = (Button)sender;
            if(stage == TrialStage.WaitingForSlot & slots[activeSlot] == slot)
            {
                AdvanceTrial(slot);
            }
        }

        // advance trial when button is clicked.
        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            if(Looks.ActiveBtnsOnly)
            {
                button.Visible = false;
            }
            AdvanceTrial(button);
        }

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            TimeoutTimer.Enabled = false;
            AdvanceTrial(null);
        }


        /// <summary>
        /// Continue trial when delay time is up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StartTimer.Enabled = false;
            AdvanceTrial(null);
        }


        private void AdvanceTrial(Button sender)
        {
            switch(stage)
            {
                case TrialStage.Starting:
                    // check start conditions
                    if (Phase.StartCond[0] == 0)
                    {
                        // start pretrial delay timer
                        stage = TrialStage.PreTrialDelay;
                        StartTimer.Interval = Phase.StartCond[1] * 1000;
                        StartTimer.Enabled = true;
                    } else
                    {
                        // start waiting for start button press
                        stage = TrialStage.WaitingForStartButton;
                        buttons[Phase.StartCond[1]].Enabled = true;
                        buttons[Phase.StartCond[1]].Visible = true;
                    }
                    break;

                case TrialStage.PreTrialDelay:
                    // delay time is up, trial is now started.
                    stage = TrialStage.Started;
                    AdvanceTrial(null);
                    break;

                case TrialStage.WaitingForStartButton:
                    // start button pressed, trial is now started.
                    stage = TrialStage.Started;
                    AdvanceTrial(null);
                    break;

                case TrialStage.Started:
                    // generate slot result
                    result = engine.Roll();

                    // count slots to be pressed
                    numSlots = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (Phase.Slots[i])
                        {
                            numSlots++;
                        }
                    }
                    // determine if we can skip the slot stage
                    if (numSlots == 0)
                    {
                        // enable collect button
                        stage = TrialStage.WaitingForCollectButton;
                        buttons[Phase.RewardButton].Enabled = true;
                        buttons[Phase.RewardButton].Visible = true;

                        // enable timeout button
                        buttons[Phase.TimeoutButton].Enabled = true;
                        buttons[Phase.TimeoutButton].Visible = true;
                    } else
                    {
                        // enable first slot
                        stage = TrialStage.WaitingForSlot;
                        for(int i=0; i<3; i++)
                        {
                            if(Phase.Slots[i])
                            {
                                activeSlot = i;
                                slots[activeSlot].Enabled = true;
                                slots[activeSlot].Visible = true;
                                break;
                            }
                        }
                        // start blinking
                        BlinkTimer.Interval = 1000 / (Looks.SlotsBlinkRate * 2);
                        BlinkTimer.Enabled = true;
                    }
                    break;

                case TrialStage.WaitingForSlot:
                    // set slot color
                    numSlots--;
                    if(result[numSlots] == 1)
                    {
                        sender.BackColor = Looks.SlotsFGColor;
                    } else
                    {
                        sender.BackColor = Looks.SlotsBGColor;
                    }

                    // determine if we're done with slot stage
                    if (numSlots == 0)
                    {
                        stage = TrialStage.WaitingForCollectButton;

                        if(Phase.StartCond[0] == 1)
                        {
                            // enable roll button
                            buttons[Phase.StartCond[1]].Enabled = true;
                            buttons[Phase.StartCond[1]].Visible = true;
                        }

                        // enable collect button
                        buttons[Phase.RewardButton].Enabled = true;
                        buttons[Phase.RewardButton].Visible = true;

                        // enable timeout button
                        buttons[Phase.TimeoutButton].Enabled = true;
                        buttons[Phase.TimeoutButton].Visible = true;

                        // stop blinking
                        BlinkTimer.Enabled = false;
                    } else
                    {
                        // enable next slot
                        for(int i=activeSlot+1; i<3; i++)
                        {
                            if(Phase.Slots[i])
                            {
                                activeSlot = i;
                                slots[activeSlot].Enabled = true;
                                slots[activeSlot].Visible = true;
                                break;
                            }
                        }
                    }
                    break;

                case TrialStage.WaitingForCollectButton:
                    UpdateLooks();
                    // fail state
                    if(sender == buttons[Phase.TimeoutButton] & SlotsEngine.CheckRoll(result) == false)
                    {
                        //disable other buttons
                        stage = TrialStage.TimeoutDelay;
                        TimeoutTimer.Interval = Phase.Timeout * 1000;
                        TimeoutTimer.Enabled = true;
                    } else
                    {
                        // success state
                        if (sender == buttons[Phase.RewardButton] & SlotsEngine.CheckRoll(result) == true)
                        {
                            stage = TrialStage.Starting;

                            MessageBox.Show("Dispensed " + Phase.RewardAmount.ToString() + " pellets.");
                            // restarting trial
                            stage = TrialStage.Starting;
                            AdvanceTrial(null);
                        } else
                        {
                            // rerolling
                            if(sender == buttons[Phase.StartCond[1]] & Phase.StartCond[0] == 1)
                            {
                                stage = TrialStage.WaitingForStartButton;
                                AdvanceTrial(null);
                            }
                        }
                    }
                    break;

                case TrialStage.TimeoutDelay:
                    // timeout time is up, restarting trial.
                    stage = TrialStage.Starting;
                    AdvanceTrial(null);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Updates the UI to reflect the start/stop status of the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuActionStartStop_Click(object sender, EventArgs e)
        {
            if(stage == TrialStage.Stopped) // starting
            {
                stage = TrialStage.Starting;
                MenuConfig.Enabled = false;
                MenuFile.Enabled = false;
                AdvanceTrial(null);

            } else // stopping
            {
                stage = TrialStage.Stopped;
                MenuConfig.Enabled = true;
                MenuFile.Enabled = true;
                UpdateLooks();
            }
        }
    }
}
