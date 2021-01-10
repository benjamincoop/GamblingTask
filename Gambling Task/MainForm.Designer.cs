namespace Gambling_Task
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfigPhase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfigUI = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAction = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuActionStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.Slot1 = new System.Windows.Forms.Button();
            this.Slot2 = new System.Windows.Forms.Button();
            this.Slot3 = new System.Windows.Forms.Button();
            this.BlinkTimer = new System.Windows.Forms.Timer(this.components);
            this.CenterButton = new System.Windows.Forms.Button();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.savePhaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuConfig,
            this.MenuAction,
            this.MenuHelp,
            this.MenuExit});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(2176, 28);
            this.MenuStrip.TabIndex = 0;
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNew,
            this.savePhaseToolStripMenuItem,
            this.MenuFileLoad});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(44, 24);
            this.MenuFile.Text = "File";
            // 
            // MenuFileNew
            // 
            this.MenuFileNew.Name = "MenuFileNew";
            this.MenuFileNew.Size = new System.Drawing.Size(216, 26);
            this.MenuFileNew.Text = "New Phase";
            this.MenuFileNew.Click += new System.EventHandler(this.OpenPhaseConfig);
            // 
            // MenuFileLoad
            // 
            this.MenuFileLoad.Name = "MenuFileLoad";
            this.MenuFileLoad.Size = new System.Drawing.Size(216, 26);
            this.MenuFileLoad.Text = "Load Phase";
            this.MenuFileLoad.Click += new System.EventHandler(this.MenuFileLoad_Click);
            // 
            // MenuConfig
            // 
            this.MenuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConfigPhase,
            this.MenuConfigUI});
            this.MenuConfig.Name = "MenuConfig";
            this.MenuConfig.Size = new System.Drawing.Size(47, 24);
            this.MenuConfig.Text = "Edit";
            // 
            // MenuConfigPhase
            // 
            this.MenuConfigPhase.Name = "MenuConfigPhase";
            this.MenuConfigPhase.Size = new System.Drawing.Size(142, 26);
            this.MenuConfigPhase.Text = "Phase";
            this.MenuConfigPhase.Click += new System.EventHandler(this.OpenPhaseConfig);
            // 
            // MenuConfigUI
            // 
            this.MenuConfigUI.Name = "MenuConfigUI";
            this.MenuConfigUI.Size = new System.Drawing.Size(142, 26);
            this.MenuConfigUI.Text = "Interface";
            this.MenuConfigUI.Click += new System.EventHandler(this.MenuConfigUI_Click);
            // 
            // MenuAction
            // 
            this.MenuAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuActionStartStop});
            this.MenuAction.Name = "MenuAction";
            this.MenuAction.Size = new System.Drawing.Size(64, 24);
            this.MenuAction.Text = "Action";
            // 
            // MenuActionStartStop
            // 
            this.MenuActionStartStop.Name = "MenuActionStartStop";
            this.MenuActionStartStop.Size = new System.Drawing.Size(216, 26);
            this.MenuActionStartStop.Text = "Start/Stop";
            this.MenuActionStartStop.Click += new System.EventHandler(this.MenuActionStartStop_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.Enabled = false;
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(53, 24);
            this.MenuHelp.Text = "Help";
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(45, 24);
            this.MenuExit.Text = "Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftButton.AutoSize = true;
            this.LeftButton.BackColor = System.Drawing.Color.Gray;
            this.LeftButton.Enabled = false;
            this.LeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftButton.ForeColor = System.Drawing.Color.DimGray;
            this.LeftButton.Location = new System.Drawing.Point(289, 916);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(500, 169);
            this.LeftButton.TabIndex = 1;
            this.LeftButton.Text = "Roll";
            this.LeftButton.UseVisualStyleBackColor = false;
            this.LeftButton.Click += new System.EventHandler(this.ButtonClick);
            // 
            // RightButton
            // 
            this.RightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RightButton.AutoSize = true;
            this.RightButton.BackColor = System.Drawing.Color.Gray;
            this.RightButton.Enabled = false;
            this.RightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightButton.ForeColor = System.Drawing.Color.DimGray;
            this.RightButton.Location = new System.Drawing.Point(1388, 916);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(500, 169);
            this.RightButton.TabIndex = 2;
            this.RightButton.Text = "Collect";
            this.RightButton.UseVisualStyleBackColor = false;
            this.RightButton.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Slot1
            // 
            this.Slot1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Slot1.BackColor = System.Drawing.Color.Gray;
            this.Slot1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Slot1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Slot1.Location = new System.Drawing.Point(289, 143);
            this.Slot1.Name = "Slot1";
            this.Slot1.Size = new System.Drawing.Size(500, 500);
            this.Slot1.TabIndex = 3;
            this.Slot1.UseVisualStyleBackColor = false;
            this.Slot1.Click += new System.EventHandler(this.SlotClick);
            // 
            // Slot2
            // 
            this.Slot2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Slot2.BackColor = System.Drawing.Color.Gray;
            this.Slot2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Slot2.Location = new System.Drawing.Point(842, 143);
            this.Slot2.Name = "Slot2";
            this.Slot2.Size = new System.Drawing.Size(500, 500);
            this.Slot2.TabIndex = 4;
            this.Slot2.UseVisualStyleBackColor = false;
            this.Slot2.Click += new System.EventHandler(this.SlotClick);
            // 
            // Slot3
            // 
            this.Slot3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Slot3.BackColor = System.Drawing.Color.Gray;
            this.Slot3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Slot3.Location = new System.Drawing.Point(1388, 143);
            this.Slot3.Name = "Slot3";
            this.Slot3.Size = new System.Drawing.Size(500, 500);
            this.Slot3.TabIndex = 5;
            this.Slot3.UseVisualStyleBackColor = false;
            this.Slot3.Click += new System.EventHandler(this.SlotClick);
            // 
            // BlinkTimer
            // 
            this.BlinkTimer.Interval = 250;
            this.BlinkTimer.Tick += new System.EventHandler(this.SlotBlinkTimer_Tick);
            // 
            // CenterButton
            // 
            this.CenterButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CenterButton.AutoSize = true;
            this.CenterButton.BackColor = System.Drawing.Color.Gray;
            this.CenterButton.Enabled = false;
            this.CenterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CenterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CenterButton.ForeColor = System.Drawing.Color.DimGray;
            this.CenterButton.Location = new System.Drawing.Point(842, 916);
            this.CenterButton.Name = "CenterButton";
            this.CenterButton.Size = new System.Drawing.Size(500, 169);
            this.CenterButton.TabIndex = 6;
            this.CenterButton.Text = "Other";
            this.CenterButton.UseVisualStyleBackColor = false;
            this.CenterButton.Click += new System.EventHandler(this.ButtonClick);
            // 
            // StartTimer
            // 
            this.StartTimer.Interval = 1000;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // TimeoutTimer
            // 
            this.TimeoutTimer.Interval = 1000;
            this.TimeoutTimer.Tick += new System.EventHandler(this.TimeoutTimer_Tick);
            // 
            // savePhaseToolStripMenuItem
            // 
            this.savePhaseToolStripMenuItem.Name = "savePhaseToolStripMenuItem";
            this.savePhaseToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.savePhaseToolStripMenuItem.Text = "Save Phase";
            this.savePhaseToolStripMenuItem.Click += new System.EventHandler(this.savePhaseToolStripMenuItem_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.AddExtension = false;
            // 
            // SaveDialog
            // 
            this.SaveDialog.AddExtension = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2176, 1138);
            this.Controls.Add(this.CenterButton);
            this.Controls.Add(this.Slot3);
            this.Controls.Add(this.Slot2);
            this.Controls.Add(this.Slot1);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "Gambling Task";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuConfig;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button Slot1;
        private System.Windows.Forms.Button Slot2;
        private System.Windows.Forms.Button Slot3;
        private System.Windows.Forms.Timer BlinkTimer;
        private System.Windows.Forms.Button CenterButton;
        private System.Windows.Forms.ToolStripMenuItem MenuFileNew;
        private System.Windows.Forms.ToolStripMenuItem MenuFileLoad;
        private System.Windows.Forms.ToolStripMenuItem MenuConfigPhase;
        private System.Windows.Forms.ToolStripMenuItem MenuConfigUI;
        private System.Windows.Forms.ToolStripMenuItem MenuAction;
        private System.Windows.Forms.ToolStripMenuItem MenuActionStartStop;
        private System.Windows.Forms.Timer StartTimer;
        private System.Windows.Forms.Timer TimeoutTimer;
        private System.Windows.Forms.ToolStripMenuItem savePhaseToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
    }
}

