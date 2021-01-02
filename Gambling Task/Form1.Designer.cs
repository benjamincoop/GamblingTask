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
            this.MenuActions = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuActionsStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuActionsStop = new System.Windows.Forms.ToolStripMenuItem();
            this.RollButton = new System.Windows.Forms.Button();
            this.CollectButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Slot1 = new System.Windows.Forms.Button();
            this.Slot2 = new System.Windows.Forms.Button();
            this.Slot3 = new System.Windows.Forms.Button();
            this.SlotBlinkTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuActions,
            this.MenuConfig,
            this.MenuHelp,
            this.MenuExit});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1738, 28);
            this.MenuStrip.TabIndex = 0;
            // 
            // MenuActions
            // 
            this.MenuActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuActionsStart,
            this.MenuActionsStop});
            this.MenuActions.Name = "MenuActions";
            this.MenuActions.Size = new System.Drawing.Size(70, 24);
            this.MenuActions.Text = "Actions";
            // 
            // MenuConfig
            // 
            this.MenuConfig.Enabled = false;
            this.MenuConfig.Name = "MenuConfig";
            this.MenuConfig.Size = new System.Drawing.Size(86, 24);
            this.MenuConfig.Text = "Configure";
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
            // MenuActionsStart
            // 
            this.MenuActionsStart.Enabled = false;
            this.MenuActionsStart.Name = "MenuActionsStart";
            this.MenuActionsStart.Size = new System.Drawing.Size(216, 26);
            this.MenuActionsStart.Text = "Start";
            this.MenuActionsStart.Click += new System.EventHandler(this.MenuActionsStart_Click);
            // 
            // MenuActionsStop
            // 
            this.MenuActionsStop.Enabled = false;
            this.MenuActionsStop.Name = "MenuActionsStop";
            this.MenuActionsStop.Size = new System.Drawing.Size(216, 26);
            this.MenuActionsStop.Text = "Stop";
            this.MenuActionsStop.Click += new System.EventHandler(this.MenuActionsStop_Click);
            // 
            // RollButton
            // 
            this.RollButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RollButton.AutoSize = true;
            this.RollButton.BackColor = System.Drawing.Color.Red;
            this.RollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollButton.ForeColor = System.Drawing.Color.Black;
            this.RollButton.Location = new System.Drawing.Point(329, 637);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(500, 250);
            this.RollButton.TabIndex = 1;
            this.RollButton.Text = "Roll";
            this.RollButton.UseVisualStyleBackColor = false;
            this.RollButton.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // CollectButton
            // 
            this.CollectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectButton.AutoSize = true;
            this.CollectButton.BackColor = System.Drawing.Color.Gray;
            this.CollectButton.Enabled = false;
            this.CollectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollectButton.ForeColor = System.Drawing.Color.DimGray;
            this.CollectButton.Location = new System.Drawing.Point(912, 637);
            this.CollectButton.Name = "CollectButton";
            this.CollectButton.Size = new System.Drawing.Size(500, 250);
            this.CollectButton.TabIndex = 2;
            this.CollectButton.Text = "Collect";
            this.CollectButton.UseVisualStyleBackColor = false;
            this.CollectButton.Click += new System.EventHandler(this.CollectButton_Click);
            // 
            // Slot1
            // 
            this.Slot1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Slot1.BackColor = System.Drawing.Color.Black;
            this.Slot1.Enabled = false;
            this.Slot1.Location = new System.Drawing.Point(0, 12);
            this.Slot1.Name = "Slot1";
            this.Slot1.Size = new System.Drawing.Size(500, 500);
            this.Slot1.TabIndex = 3;
            this.Slot1.UseVisualStyleBackColor = false;
            this.Slot1.Click += new System.EventHandler(this.Slot1_Click);
            // 
            // Slot2
            // 
            this.Slot2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Slot2.BackColor = System.Drawing.Color.Black;
            this.Slot2.Enabled = false;
            this.Slot2.Location = new System.Drawing.Point(618, 12);
            this.Slot2.Name = "Slot2";
            this.Slot2.Size = new System.Drawing.Size(500, 500);
            this.Slot2.TabIndex = 4;
            this.Slot2.UseVisualStyleBackColor = false;
            this.Slot2.Click += new System.EventHandler(this.Slot2_Click);
            // 
            // Slot3
            // 
            this.Slot3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Slot3.BackColor = System.Drawing.Color.Black;
            this.Slot3.Enabled = false;
            this.Slot3.Location = new System.Drawing.Point(1238, 12);
            this.Slot3.Name = "Slot3";
            this.Slot3.Size = new System.Drawing.Size(500, 500);
            this.Slot3.TabIndex = 5;
            this.Slot3.UseVisualStyleBackColor = false;
            this.Slot3.Click += new System.EventHandler(this.Slot3_Click);
            // 
            // SlotBlinkTimer
            // 
            this.SlotBlinkTimer.Interval = 500;
            this.SlotBlinkTimer.Tick += new System.EventHandler(this.SlotBlinkTimer_Tick);
            // 
            // TimeoutTimer
            // 
            this.TimeoutTimer.Interval = 1000;
            this.TimeoutTimer.Tick += new System.EventHandler(this.TimeoutTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1738, 899);
            this.Controls.Add(this.Slot3);
            this.Controls.Add(this.Slot2);
            this.Controls.Add(this.Slot1);
            this.Controls.Add(this.CollectButton);
            this.Controls.Add(this.RollButton);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "Gambling Task";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuActions;
        private System.Windows.Forms.ToolStripMenuItem MenuConfig;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuActionsStart;
        private System.Windows.Forms.ToolStripMenuItem MenuActionsStop;
        private System.Windows.Forms.Button RollButton;
        private System.Windows.Forms.Button CollectButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button Slot1;
        private System.Windows.Forms.Button Slot2;
        private System.Windows.Forms.Button Slot3;
        private System.Windows.Forms.Timer SlotBlinkTimer;
        private System.Windows.Forms.Timer TimeoutTimer;
    }
}

