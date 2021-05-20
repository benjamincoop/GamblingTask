using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gambling_Task
{
    /// <summary>
    /// Handles main UI and program logic.
    /// </summary>
    public partial class MainForm : Form
    {
        enum TrialStage { Stopped, Starting, Started, PreTrialDelay, WaitingForStartButton, WaitingForSlot, WaitingForCollectButton, TimeoutDelay }

        public PhaseConfig Phase { get; set; } // the current PhaseConfig object used in the slot simulation
        public LooksConfig Looks { get; set; } // the current LooksConfig object used by the GUI
        public PhaseData Data { get; set; } // the current TrialData object used for data collection
        private SlotsEngine engine; // the current SlotsEngine object used in the slot simulation
        private Button[] slots; // array of references to all slots
        private Button[] buttons; // array of references to all buttons
        private TrialStage stage = TrialStage.Stopped; // the current state of the state machine that controls the slot simulation
        private int activeSlot = 0; // index of current slot in slots[]
        private int numSlots = 0; // the number of slots to be pressed
        private int[] result; // the outcome of the slot spin
        private int slotsTime = 0; // the number of seconds spent in the slot stage
        private int buttonTime = 0; // the number of seconds spent in the button stage
        private PhaseConfig[] phaseQueue = new PhaseConfig[0]; // the array of phases to iterate through.
        private string exportPath = ""; // the external location to save data to
        private bool manualControl = false; // indicates if manual control (toolbar) is enabled.
        private Socket socket = new TcpClient().Client;
        private byte[] buffer = new byte[12];
        public int CurrentPhase { get; set; } // the index of the current phase in the phase queue.

        private delegate void ClickDelegate(object sender, MouseEventArgs e);
        private delegate void VoidDelegate();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExit_Click(object sender, MouseEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ClickDelegate(MenuExit_Click), new object[] { sender, e });
            }
            else
            {
                Application.Exit();
            }
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
        private void OpenPhaseConfig(object sender, MouseEventArgs e)
        {
            Form phaseEditor = new PhaseConfigForm(this, Phase);

            DialogResult result = phaseEditor.ShowDialog();
            if (result == DialogResult.OK)
            {
                UpdateEngine();
                MessageBox.Show("Phase configuration updated.");
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
        private void MenuConfigUI_Click(object sender, MouseEventArgs e)
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
            CurrentPhase = 0;
            UpdateEngine();
            UpdateLooks();

            // attempt to connect socket
            try
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, 25565));
                socket.Blocking = false;
                socket.Listen(1);
                SocketAsyncEventArgs connectArgs = new SocketAsyncEventArgs();
                connectArgs.Completed += ConnectCompleted;
                socket.AcceptAsync(connectArgs);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void ConnectCompleted(object sender, SocketAsyncEventArgs e)
        {
            socket = e.AcceptSocket;
            RecieveCmd();
        }

        /// <summary>
        /// Sets UI looks from current LooksConfig.
        /// </summary>
        private void UpdateLooks()
        {
            if (InvokeRequired)
            {
                Invoke(new VoidDelegate(UpdateLooks), new object[] { });
            }
            else
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
                if (Looks.ActiveSlotsOnly)
                {
                    Slot1.Visible = false;
                    Slot2.Visible = false;
                    Slot3.Visible = false;
                }
                else // show slots
                {
                    for (int i = 0; i < 3; i++)
                    {
                        slots[i].Visible = Phase.Slots[i];
                    }
                }

                // hide or show buttons
                if (Looks.ActiveBtnsOnly)
                {
                    LeftButton.Visible = false;
                    CenterButton.Visible = false;
                    RightButton.Visible = false;
                }
                else
                {
                    LeftButton.Visible = true;
                    CenterButton.Visible = true;
                    RightButton.Visible = true;
                }
            }
        }

        /// <summary>
        /// Updates SlotEngine with latest PhaseConfig and replace PhaseData object.
        /// </summary>
        private void UpdateEngine()
        {
            if (InvokeRequired)
            {
                Invoke(new VoidDelegate(UpdateEngine), new object[] { });
            }
            else
            {
                engine = new SlotsEngine(Phase.Slots, Phase.Schedule);
                Data = new PhaseData();
            }
        }

        /// <summary>
        /// Handle slot clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlotClick(object sender, MouseEventArgs e)
        {
            // Advance trial if active slot is clicked.
            Button slot = (Button)sender;
            if (stage == TrialStage.WaitingForSlot & slots[activeSlot] == slot)
            {
                AdvanceTrial(slot);
            }
        }

        /// <summary>
        /// Handle button clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            if (Looks.ActiveBtnsOnly)
            {
                button.Visible = false;
            }
            if (stage == TrialStage.WaitingForCollectButton)
            {
                Data.ButtonsPressed.Add(button.Text);
            }
            AdvanceTrial(button);
        }

        /// <summary>
        /// Continue trial when timeout time is up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            DelayTimer.Enabled = false;
            AdvanceTrial(null);
        }

        /// <summary>
        /// Main driving logic for slot simulation.
        /// </summary>
        /// <param name="sender"></param>
        private void AdvanceTrial(Button sender)
        {
            switch (stage)
            {
                case TrialStage.Starting:
                    // check start conditions
                    if (Phase.StartCond[0] == 0)
                    {
                        // start pretrial delay timer
                        stage = TrialStage.PreTrialDelay;
                        if (Phase.StartCond[1] == 0) // check if delay time is 0
                        {
                            DelayTimer_Tick(null, null); // invoke timer elapsed method to skip timer
                        }
                        else
                        {
                            // set and start timer.
                            DelayTimer.Interval = Phase.StartCond[1] * 1000;
                            DelayTimer.Enabled = true;
                        }
                    }
                    else
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
                    Data.SlotOutcomes.Add(result);

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
                    }
                    else
                    {
                        // enable first slot
                        stage = TrialStage.WaitingForSlot;
                        for (int i = 0; i < 3; i++)
                        {
                            if (Phase.Slots[i])
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
                    if (result[numSlots] == 1)
                    {
                        sender.BackColor = Looks.SlotsFGColor;
                    }
                    else
                    {
                        sender.BackColor = Looks.SlotsBGColor;
                    }

                    // determine if we're done with slot stage
                    if (numSlots == 0)
                    {
                        stage = TrialStage.WaitingForCollectButton;

                        if (Phase.StartCond[0] == 1)
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
                    }
                    else
                    {
                        // enable next slot
                        for (int i = activeSlot + 1; i < 3; i++)
                        {
                            if (Phase.Slots[i])
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
                    Data.SlotsTime.Add(slotsTime);
                    Data.ButtonTime.Add(buttonTime);
                    slotsTime = 0; buttonTime = 0;
                    Data.NumTrials++;

                    UpdateLooks();
                    bool success = SlotsEngine.CheckRoll(result);
                    int progress;
                    if (success)
                    {
                        Data.NumSuccessStates++;
                    }

                    // handle reroll button first
                    if (sender == buttons[Phase.StartCond[1]] & Phase.StartCond[0] == 1)
                    {
                        Data.TrialResults.Add("skip");
                        if (success)
                        {
                            Data.NumIncorrect++;
                        }
                        else
                        {
                            Data.NumCorrect++;
                        }
                        progress = CheckProgressCond();
                        if (progress != 0)
                        {
                            PhaseTransition(progress);
                        }
                        else
                        {
                            // restarting trial
                            stage = TrialStage.WaitingForStartButton;
                            AdvanceTrial(null);
                        }
                        break;
                    }

                    // special cases when timeout and reward buttons are different
                    if (Phase.TimeoutButton != Phase.RewardButton)
                    {
                        if ((sender == buttons[Phase.RewardButton] & success == false) | (sender == buttons[Phase.TimeoutButton] & success == true))
                        {
                            // trigger timeout
                            Data.TrialResults.Add("timeout");
                            System.Media.SystemSounds.Hand.Play();
                            Data.NumIncorrect++;
                            progress = CheckProgressCond();
                            if (progress != 0)
                            {
                                PhaseTransition(progress);
                            }
                            else
                            {
                                stage = TrialStage.TimeoutDelay;
                            }
                            if (Phase.Timeout == 0) // check if timeout time is 0
                            {
                                DelayTimer_Tick(null, null); // invoke timer elapsed method to skip timer
                            }
                            else
                            {
                                // set and start timer.
                                DelayTimer.Interval = Phase.Timeout * 1000;
                                DelayTimer.Enabled = true;
                            }
                            break;
                        }
                        if ((sender == buttons[Phase.TimeoutButton] & success == false) | (sender == buttons[Phase.RewardButton] & success == true))
                        {
                            // dispense reward
                            Data.TrialResults.Add("reward");
                            System.Media.SystemSounds.Beep.Play();
                            DispenserInterface.Dispense(Phase.RewardAmount);
                            //MessageBox.Show("Dispensed " + Phase.RewardAmount.ToString() + " pellets.");
                            Data.NumCorrect++;
                            progress = CheckProgressCond();
                            if (progress != 0)
                            {
                                PhaseTransition(progress);
                            }
                            else
                            {
                                // restarting trial
                                stage = TrialStage.Starting;
                                AdvanceTrial(null);
                            }
                            break;
                        }
                    }
                    else
                    {
                        // base cases
                        if (sender == buttons[Phase.TimeoutButton] & success == false)
                        {
                            // trigger timeout
                            Data.TrialResults.Add("timeout");
                            System.Media.SystemSounds.Hand.Play();
                            Data.NumIncorrect++;
                            progress = CheckProgressCond();
                            if (progress != 0)
                            {
                                PhaseTransition(progress);
                            }
                            else
                            {
                                stage = TrialStage.TimeoutDelay;
                            }
                            if (Phase.Timeout == 0) // check if timeout time is 0
                            {
                                DelayTimer_Tick(null, null); // invoke timer elapsed method to skip timer
                            }
                            else
                            {
                                // set and start timer.
                                DelayTimer.Interval = Phase.Timeout * 1000;
                                DelayTimer.Enabled = true;
                            }
                            break;
                        }
                        else
                        {
                            if (sender == buttons[Phase.RewardButton] & success == true)
                            {
                                // dispense reward
                                Data.TrialResults.Add("reward");
                                System.Media.SystemSounds.Beep.Play();
                                DispenserInterface.Dispense(Phase.RewardAmount);
                                //MessageBox.Show("Dispensed " + Phase.RewardAmount.ToString() + " pellets.");
                                Data.NumCorrect++;
                                progress = CheckProgressCond();
                                if (progress != 0)
                                {
                                    PhaseTransition(progress);
                                }
                                else
                                {
                                    // restarting trial
                                    stage = TrialStage.Starting;
                                    AdvanceTrial(null);
                                }
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
        private void MenuActionStartStop_Click(object sender, MouseEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ClickDelegate(MenuActionStartStop_Click), new object[] { sender, e });
            }
            else
            {
                if (stage == TrialStage.Stopped) // starting
                {
                    stage = TrialStage.Starting;
                    DataTimer.Enabled = true;
                    MenuConfig.Enabled = false;
                    MenuFile.Enabled = false;
                    MenuPhaseNext.Enabled = false;
                    MenuPhasePrev.Enabled = false;
                    AdvanceTrial(null);

                }
                else // stopping
                {
                    stage = TrialStage.Stopped;
                    DataTimer.Enabled = false;
                    MenuConfig.Enabled = true;
                    MenuFile.Enabled = true;
                    MenuPhaseNext.Enabled = true;
                    MenuPhasePrev.Enabled = true;
                    DelayTimer.Enabled = false;
                    BlinkTimer.Enabled = false;
                    UpdateLooks();
                }
            }
        }

        /// <summary>
        /// Saves or loads a binary file containing serialized PhaseConfig and LooksConfig objects. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="saveMode"></param>
        public void PhaseFileIO(string path, bool saveMode)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream;
            object[] data;
            if (saveMode)
            {
                stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                data = new object[] { Phase, Looks };
                formatter.Serialize(stream, data);
            }
            else
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                data = (object[])formatter.Deserialize(stream);
                Phase = (PhaseConfig)data[0];
                Looks = (LooksConfig)data[1];
                UpdateEngine();
                UpdateLooks();
            }
            stream.Close();
        }

        /// <summary>
        /// Handles save button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savePhaseToolStripMenuItem_Click(object sender, MouseEventArgs e)
        {
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                PhaseFileIO(SaveDialog.FileName, true);
                MessageBox.Show("File saved.");
            }
        }

        /// <summary>
        /// Handles load button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuFileLoad_Click(object sender, MouseEventArgs e)
        {
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                PhaseFileIO(OpenDialog.FileName, false);
                MessageBox.Show("File loaded.");
            }
        }

        /// <summary>
        /// Continue trial when timer expires.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            DelayTimer.Enabled = false;
            AdvanceTrial(null);
        }

        /// <summary>
        /// Handles request for QueueConfigForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queueToolStripMenuItem_Click(object sender, MouseEventArgs e)
        {
            Form queueEditor = new QueueConfigForm(this);
            if (queueEditor.ShowDialog() == DialogResult.OK)
            {
                if (phaseQueue.Length < CurrentPhase + 1)
                {
                    Array.Resize(ref phaseQueue, CurrentPhase + 1);
                }

                if (phaseQueue[CurrentPhase] == null)
                {
                    phaseQueue[CurrentPhase] = Phase;
                    MessageBox.Show("Saved configuration to selected queue position.");
                }
                else
                {
                    Phase = phaseQueue[CurrentPhase];
                    MessageBox.Show("Loaded configuration from selected queue position.");
                }

                UpdateEngine();
                UpdateLooks();
            }
            else
            {
                MessageBox.Show("Operation aborted.");
            }
            queueEditor.Dispose();
        }

        /// <summary>
        /// Handles next phase menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPhaseNext_Click(object sender, MouseEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ClickDelegate(MenuPhaseNext_Click), new object[] { sender, e });
            }
            else
            {
                NextPhase();
            }
        }

        /// <summary>
        /// Switches to next phase in queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool NextPhase()
        {
            if (phaseQueue.Length > CurrentPhase + 1)
            {
                CurrentPhase++;
                Phase = phaseQueue[CurrentPhase];
                MessageBox.Show("Loaded next phase in queue.");
                UpdateEngine();
                UpdateLooks();
                return true;
            }
            else
            {
                MessageBox.Show("End of queue reached.");
                return false;
            }
        }

        /// <summary>
        /// Handles previous phase menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPhasePrev_Click(object sender, MouseEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ClickDelegate(MenuPhasePrev_Click), new object[] { sender, e });
            }
            else
            {
                PrevPhase();
            }
        }

        /// <summary>
        /// Switches to the previous phase in queue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool PrevPhase()
        {
            if (CurrentPhase > 0)
            {
                CurrentPhase--;
                Phase = phaseQueue[CurrentPhase];
                MessageBox.Show("Loaded previous phase in queue.");
                UpdateEngine();
                UpdateLooks();
                return true;
            }
            else
            {
                MessageBox.Show("Start of queue reached.");
                return false;
            }
        }

        /// <summary>
        /// Stops the current phase when the alloted time is up.
        /// </summary>
        private void CheckTrialTime()
        {
            if (Phase.ProgressCond[0] == 1 & (Data.PhaseTime / 60) >= Phase.ProgressCond[3])
            {
                MessageBox.Show("Phase timer expired.");
                PhaseTransition(-1);
            }
        }

        /// <summary>
        /// Handles the transition from one active phase to the next.
        /// </summary>
        private void PhaseTransition(int code)
        {
            if (exportPath != "")
            {
                ExportData(exportPath);
            }
            switch (code)
            {
                case 0:
                    break;
                case 1:
                    MessageBox.Show("Phase completed.");
                    MenuActionStartStop_Click(null, null);
                    if (NextPhase())
                    {
                        MenuActionStartStop_Click(null, null);
                    }
                    break;
                case -1:
                    MessageBox.Show("Phase completion failed.");
                    MenuActionStartStop_Click(null, null);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Checks conditions to phase end/progression. Ret 0 indicates no progress, return 1 indicates progress, and return -1 indicates failure.
        /// </summary>
        /// <returns></returns>
        private int CheckProgressCond()
        {
            if (Phase.ProgressCond[0] == 1) // check for conditions
            {
                if (Phase.ProgressCond[2] == 1) // success-state progress type
                {
                    if (Data.NumSuccessStates >= Phase.ProgressCond[1])
                    {
                        if (Phase.ProgressCond[4] == 1 & (int)Math.Round((float)Data.NumCorrect / Data.NumTrials * 100) < Phase.ProgressCond[5]) // optimality requirement
                        {
                            MessageBox.Show("Optimality threshold not met.");
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (Data.NumTrials >= Phase.ProgressCond[1])
                    {
                        if (Phase.ProgressCond[4] == 1 & (int)Math.Round((float)Data.NumCorrect / Data.NumTrials * 100) < Phase.ProgressCond[5]) // optimality requirement
                        {
                            MessageBox.Show("Optimality threshold not met.");
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        private void DataTimer_Tick(object sender, EventArgs e)
        {
            Data.PhaseTime++;
            if (stage == TrialStage.WaitingForSlot)
            {
                slotsTime++;
            }
            else
            {
                if (stage == TrialStage.WaitingForCollectButton)
                {
                    buttonTime++;
                }
            }
            CheckTrialTime();
        }

        /// <summary>
        /// Serializes and saves phase data to path user chooses from dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportData(object sender, MouseEventArgs e)
        {
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                exportPath = SaveDialog.FileName;
                if (Data.NumTrials > 0)
                {
                    System.IO.File.AppendAllText(exportPath, Data.Serialize(Phase));
                    MessageBox.Show("Data exported.");
                    Data = new PhaseData();
                }
                else
                {
                    MessageBox.Show("Export path set.");
                }
            }
        }
        /// <summary>
        /// Overload of previous method for autosaving when path is already known.
        /// </summary>
        /// <param name="path"></param>
        private void ExportData(string path)
        {
            string data = "\n// PHASE " + CurrentPhase + " //\n\n" + Data.Serialize(Phase);
            System.IO.File.AppendAllText(path, data);
        }

        /// <summary>
        /// Temporary method for testing dispenser operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestDispense(object sender, EventArgs e)
        {
            int count = int.Parse(((ToolStripMenuItem)sender).Text);
            DispenserInterface.Dispense(count);
        }

        private void MenuHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/benjamincoop/GamblingTask/wiki");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (manualControl)
                {
                    manualControl = false;
                    MenuStrip.Enabled = false;
                    MenuStrip.Visible = false;
                }
                else
                {
                    manualControl = true;
                    MenuStrip.Enabled = true;
                    MenuStrip.Visible = true;
                }
            }
        }

        /// <summary>
        /// Recieves an incoming command from the remote control program
        /// </summary>
        /// <returns></returns>
        private void RecieveCmd()
        {
            if (socket.Connected)
            {
                // attempt to recieve
                try
                {
                    SocketAsyncEventArgs recieveArgs = new SocketAsyncEventArgs();
                    recieveArgs.SetBuffer(buffer, 0, 12);
                    recieveArgs.Completed += RecieveCompleted;
                    socket.ReceiveAsync(recieveArgs);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            } else
            {
                // attempt to connect socket
                try
                {
                    socket.Bind(new IPEndPoint(IPAddress.Any, 25565));
                    socket.Blocking = false;
                    socket.Listen(1);
                    SocketAsyncEventArgs connectArgs = new SocketAsyncEventArgs();
                    connectArgs.Completed += ConnectCompleted;
                    socket.AcceptAsync(connectArgs);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        private void RecieveCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (manualControl == false)
            {
                ParseCmd(Encoding.ASCII.GetString(buffer).Split('!')[0]);
                RecieveCmd();
            }

        }

        /// <summary>
        /// Maps the string commands recieved from remote to appropriate functions
        /// </summary>
        /// <param name="cmd"></param>
        private void ParseCmd(string cmd)
        {
            switch (cmd)
            {
                case "load_phase":
                    Thread.Sleep(1000); // block for a second to resolve timing issues
                    // attempt to recieve and load files
                    using (MemoryStream ms = new MemoryStream())
                    {
                        try
                        {
                            // recieve bytes (chunks of 0.5KB) and load into stream
                            byte[] buffer = new byte[512];
                            int bytesRead = 0;
                            while ((bytesRead = socket.Receive(buffer)) != 0)
                            {
                                ms.Write(buffer, 0, bytesRead);
                            }
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        // deserialize data from stream and load into program
                        IFormatter formatter = new BinaryFormatter();
                        object[] data;
                        ms.Seek(0, SeekOrigin.Begin);
                        data = (object[])formatter.Deserialize(ms);
                        Phase = (PhaseConfig)data[0];
                        Looks = (LooksConfig)data[1];
                        UpdateEngine();
                        UpdateLooks();
                        ms.Close();
                    }
                    break;
                case "start_stop":
                    MenuActionStartStop_Click(null, null);
                    break;
                case "next_phase":
                    MenuPhaseNext_Click(null, null);
                    break;
                case "prev_phase":
                    MenuPhasePrev_Click(null, null);
                    break;
                case "exit":
                    MenuExit_Click(null, null);
                    break;
                default:
                    Console.WriteLine(cmd);
                    break;
            }
        }
    }
}