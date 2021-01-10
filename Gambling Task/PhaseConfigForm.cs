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
    public partial class PhaseConfigForm : Form
    {
        MainForm parent;
        PhaseConfig current;

        /// <summary>
        /// Public constructor for new PhaseConfig
        /// </summary>
        /// <param name="sender"></param>
        public PhaseConfigForm(MainForm sender)
        {
            InitializeComponent();
            parent = sender;
            current = new PhaseConfig();
        }

        /// <summary>
        /// Public constructor for a modifying PhaseConfig
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="phase"></param>
        public PhaseConfigForm(MainForm sender, PhaseConfig phase)
        {
            InitializeComponent();
            parent = sender;
            current = phase;
        }

        /// <summary>
        /// Sets the inital UI state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPhaseForm_Load(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        /// <summary>
        /// Sets UI looks from current PhaseConfig.
        /// </summary>
        private void UpdateConfig()
        {
            RewardAmount.Value = current.RewardAmount;
            RewardButton.SelectedIndex = current.RewardButton;
            TimeoutAmount.Value = current.Timeout;
            TimeoutButton.SelectedIndex = current.TimeoutButton;
            if(current.Slots[0])
            {
                LeftSlot.Checked = true;
            } else
            {
                LeftSlot.Checked = false;
            }
            if (current.Slots[1])
            {
                CenterSlot.Checked = true;
            }
            else
            {
                CenterSlot.Checked = false;
            }
            if (current.Slots[2])
            {
                RightSlot.Checked = true;
            }
            else
            {
                RightSlot.Checked = false;
            }
            if(current.Schedule[0] == 0)
            {
                ScheduleFixed.Checked = true;
                ScheduleFixedRate.Value = current.Schedule[1];
            } else
            {
                ScheduleVariable.Checked = true;
                ScheduleVariableNumerator.Value = current.Schedule[1];
                ScheduleVariableDenominator.Value = current.Schedule[2];
            }
            if(current.StartCond[0] == 0)
            {
                StartAutomatic.Checked = true;
                StartAutomaticDelay.Value = current.StartCond[1];
                StartButtonSelection.SelectedIndex = 0;
            } else
            {
                if(current.StartCond[0] == 1)
                {
                    StartButton.Checked = true;
                    StartButtonSelection.SelectedIndex = current.StartCond[1];
                } else
                {
                    if(current.StartCond[0] == 2)
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            if(current.ProgressCond[0] == 0)
            {
                ProgressNever.Checked = true;
                ProgressTrialType.SelectedIndex = 0;
            } else
            {
                if(current.ProgressCond[0] == 1)
                {
                    ProgressConditional.Checked = true;
                    ProgressTrialCount.Value = current.ProgressCond[1];
                    ProgressTrialType.SelectedIndex = current.ProgressCond[2];
                    ProgressTime.Value = current.ProgressCond[3];
                    if(current.ProgressCond[4] == 1)
                    {
                        ProgressRequireOptimal.Checked = true;
                    } else
                    {
                        ProgressRequireOptimal.Checked = false;
                    }
                    ProgressOptimalPercent.Value = current.ProgressCond[5];
                }
            }
        }

        /// <summary>
        /// Passes new PhaseConfig to parent form, saves if applicable, then closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            parent.Phase = CollectInput();

            // save phase, if requested.
            if(SaveOption.Checked)
            {
                parent.PhaseFileIO(SavePathField.Text, true);
            }

            Close();
        }

        /// <summary>
        /// Creates a new PhaseConfig from the data entered in the form.
        /// </summary>
        /// <returns></returns>
        private PhaseConfig CollectInput()
        {
            int rewardAmount = (int)RewardAmount.Value;
            int rewardButton = RewardButton.SelectedIndex;
            int timeout = (int)TimeoutAmount.Value;
            int timeoutButton = TimeoutButton.SelectedIndex;
            bool[] slots = new bool[3];
            int[] schedule = new int[3];
            int[] startCond = new int[2];
            int[] progressCond = new int[6];

            if (LeftSlot.Checked)
            {
                slots[0] = true;
            }
            else
            {
                slots[0] = false;
            }
            if (CenterSlot.Checked)
            {
                slots[1] = true;
            }
            else
            {
                slots[1] = false;
            }
            if (RightSlot.Checked)
            {
                slots[2] = true;
            }
            else
            {
                slots[2] = false;
            }

            if (ScheduleFixed.Checked)
            {
                schedule[0] = 0;
                schedule[1] = (int)ScheduleFixedRate.Value;
            }
            else
            {
                schedule[0] = 1;
                schedule[1] = (int)ScheduleVariableNumerator.Value;
                schedule[2] = (int)ScheduleVariableDenominator.Value;
            }

            if (StartAutomatic.Checked)
            {
                startCond[0] = 0;
                startCond[1] = (int)StartAutomaticDelay.Value;
            }
            else
            {
                if (StartButton.Checked)
                {
                    startCond[0] = 1;
                    startCond[1] = StartButtonSelection.SelectedIndex;
                }
                else
                {
                    if (StartPellet.Checked)
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            if (ProgressNever.Checked)
            {
                progressCond[0] = 0;
            }
            else
            {
                progressCond[0] = 1;
                progressCond[1] = (int)ProgressTrialCount.Value;
                progressCond[2] = ProgressTrialType.SelectedIndex;
                progressCond[3] = (int)ProgressTime.Value;
                if (ProgressRequireOptimal.Checked)
                {
                    progressCond[4] = 1;
                }
                else
                {
                    progressCond[4] = 0;
                }
                progressCond[5] = (int)ProgressOptimalPercent.Value;
            }
            return new PhaseConfig(slots, schedule, rewardAmount, rewardButton, timeout, timeoutButton, startCond, progressCond);
        }

        private void SaveOption_CheckedChanged(object sender, EventArgs e)
        {
            SaveBrowseButton.Enabled = SaveOption.Checked;
            SavePathField.Enabled = SaveOption.Checked;
        }

        private void SaveBrowseButton_Click(object sender, EventArgs e)
        {
            if(SaveDialog.ShowDialog() == DialogResult.OK)
            {
                SavePathField.Text = SaveDialog.FileName;
            }
        }
    }
}
