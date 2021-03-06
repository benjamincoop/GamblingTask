﻿namespace Gambling_Task
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
            this.savePhaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfigPhase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfigUI = new System.Windows.Forms.ToolStripMenuItem();
            this.queueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAction = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPhaseStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPhaseNext = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPhasePrev = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.Slot1 = new System.Windows.Forms.Button();
            this.Slot2 = new System.Windows.Forms.Button();
            this.Slot3 = new System.Windows.Forms.Button();
            this.BlinkTimer = new System.Windows.Forms.Timer(this.components);
            this.CenterButton = new System.Windows.Forms.Button();
            this.DelayTimer = new System.Windows.Forms.Timer(this.components);
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.DataTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Enabled = false;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuConfig,
            this.MenuAction,
            this.MenuHelp,
            this.MenuExit,
            this.testToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1262, 28);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Visible = false;
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePhaseToolStripMenuItem,
            this.MenuFileLoad,
            this.exportDataToolStripMenuItem});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(46, 24);
            this.MenuFile.Text = "File";
            // 
            // savePhaseToolStripMenuItem
            // 
            this.savePhaseToolStripMenuItem.Name = "savePhaseToolStripMenuItem";
            this.savePhaseToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.savePhaseToolStripMenuItem.Text = "Save Phase";
            this.savePhaseToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.savePhaseToolStripMenuItem_Click);
            // 
            // MenuFileLoad
            // 
            this.MenuFileLoad.Name = "MenuFileLoad";
            this.MenuFileLoad.Size = new System.Drawing.Size(171, 26);
            this.MenuFileLoad.Text = "Load Phase";
            this.MenuFileLoad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuFileLoad_Click);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExportData);
            // 
            // MenuConfig
            // 
            this.MenuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConfigPhase,
            this.MenuConfigUI,
            this.queueToolStripMenuItem});
            this.MenuConfig.Name = "MenuConfig";
            this.MenuConfig.Size = new System.Drawing.Size(49, 24);
            this.MenuConfig.Text = "Edit";
            // 
            // MenuConfigPhase
            // 
            this.MenuConfigPhase.Name = "MenuConfigPhase";
            this.MenuConfigPhase.Size = new System.Drawing.Size(150, 26);
            this.MenuConfigPhase.Text = "Phase";
            this.MenuConfigPhase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenPhaseConfig);
            // 
            // MenuConfigUI
            // 
            this.MenuConfigUI.Name = "MenuConfigUI";
            this.MenuConfigUI.Size = new System.Drawing.Size(150, 26);
            this.MenuConfigUI.Text = "Interface";
            this.MenuConfigUI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuConfigUI_Click);
            // 
            // queueToolStripMenuItem
            // 
            this.queueToolStripMenuItem.Name = "queueToolStripMenuItem";
            this.queueToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.queueToolStripMenuItem.Text = "Queue";
            this.queueToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.queueToolStripMenuItem_Click);
            // 
            // MenuAction
            // 
            this.MenuAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPhaseStartStop,
            this.MenuPhaseNext,
            this.MenuPhasePrev});
            this.MenuAction.Name = "MenuAction";
            this.MenuAction.Size = new System.Drawing.Size(61, 24);
            this.MenuAction.Text = "Phase";
            // 
            // MenuPhaseStartStop
            // 
            this.MenuPhaseStartStop.Name = "MenuPhaseStartStop";
            this.MenuPhaseStartStop.Size = new System.Drawing.Size(160, 26);
            this.MenuPhaseStartStop.Text = "Start/Stop";
            this.MenuPhaseStartStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuActionStartStop_Click);
            // 
            // MenuPhaseNext
            // 
            this.MenuPhaseNext.Name = "MenuPhaseNext";
            this.MenuPhaseNext.Size = new System.Drawing.Size(160, 26);
            this.MenuPhaseNext.Text = "Next";
            this.MenuPhaseNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuPhaseNext_Click);
            // 
            // MenuPhasePrev
            // 
            this.MenuPhasePrev.Name = "MenuPhasePrev";
            this.MenuPhasePrev.Size = new System.Drawing.Size(160, 26);
            this.MenuPhasePrev.Text = "Previous";
            this.MenuPhasePrev.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuPhasePrev_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(55, 24);
            this.MenuHelp.Text = "Help";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(47, 24);
            this.MenuExit.Text = "Exit";
            this.MenuExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuExit_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispenseToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // dispenseToolStripMenuItem
            // 
            this.dispenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.dispenseToolStripMenuItem.Name = "dispenseToolStripMenuItem";
            this.dispenseToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.dispenseToolStripMenuItem.Text = "Dispense...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.TestDispense);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItem3.Text = "5";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.TestDispense);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItem4.Text = "10";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.TestDispense);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItem5.Text = "50";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.TestDispense);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItem6.Text = "100";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.TestDispense);
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
            this.LeftButton.Location = new System.Drawing.Point(12, 588);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(300, 200);
            this.LeftButton.TabIndex = 1;
            this.LeftButton.Text = "Roll";
            this.LeftButton.UseVisualStyleBackColor = false;
            this.LeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonClick);
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
            this.RightButton.Location = new System.Drawing.Point(968, 588);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(300, 200);
            this.RightButton.TabIndex = 2;
            this.RightButton.Text = "Collect";
            this.RightButton.UseVisualStyleBackColor = false;
            this.RightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonClick);
            // 
            // Slot1
            // 
            this.Slot1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Slot1.BackColor = System.Drawing.Color.Gray;
            this.Slot1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Slot1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Slot1.Location = new System.Drawing.Point(82, 157);
            this.Slot1.Name = "Slot1";
            this.Slot1.Size = new System.Drawing.Size(300, 300);
            this.Slot1.TabIndex = 3;
            this.Slot1.UseVisualStyleBackColor = false;
            this.Slot1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SlotClick);
            // 
            // Slot2
            // 
            this.Slot2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Slot2.BackColor = System.Drawing.Color.Gray;
            this.Slot2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Slot2.Location = new System.Drawing.Point(481, 157);
            this.Slot2.Name = "Slot2";
            this.Slot2.Size = new System.Drawing.Size(300, 300);
            this.Slot2.TabIndex = 4;
            this.Slot2.UseVisualStyleBackColor = false;
            this.Slot2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SlotClick);
            // 
            // Slot3
            // 
            this.Slot3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Slot3.BackColor = System.Drawing.Color.Gray;
            this.Slot3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Slot3.Location = new System.Drawing.Point(884, 157);
            this.Slot3.Name = "Slot3";
            this.Slot3.Size = new System.Drawing.Size(300, 300);
            this.Slot3.TabIndex = 5;
            this.Slot3.UseVisualStyleBackColor = false;
            this.Slot3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SlotClick);
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
            this.CenterButton.Location = new System.Drawing.Point(481, 588);
            this.CenterButton.Name = "CenterButton";
            this.CenterButton.Size = new System.Drawing.Size(300, 200);
            this.CenterButton.TabIndex = 6;
            this.CenterButton.Text = "Other";
            this.CenterButton.UseVisualStyleBackColor = false;
            this.CenterButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonClick);
            // 
            // DelayTimer
            // 
            this.DelayTimer.Interval = 1000;
            this.DelayTimer.Tick += new System.EventHandler(this.DelayTimer_Tick);
            // 
            // OpenDialog
            // 
            this.OpenDialog.AddExtension = false;
            // 
            // SaveDialog
            // 
            this.SaveDialog.AddExtension = false;
            // 
            // DataTimer
            // 
            this.DataTimer.Interval = 1000;
            this.DataTimer.Tick += new System.EventHandler(this.DataTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.ControlBox = false;
            this.Controls.Add(this.CenterButton);
            this.Controls.Add(this.Slot3);
            this.Controls.Add(this.Slot2);
            this.Controls.Add(this.Slot1);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
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
        private System.Windows.Forms.ToolStripMenuItem MenuFileLoad;
        private System.Windows.Forms.ToolStripMenuItem MenuConfigPhase;
        private System.Windows.Forms.ToolStripMenuItem MenuConfigUI;
        private System.Windows.Forms.ToolStripMenuItem MenuAction;
        private System.Windows.Forms.ToolStripMenuItem MenuPhaseStartStop;
        private System.Windows.Forms.Timer DelayTimer;
        private System.Windows.Forms.ToolStripMenuItem savePhaseToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.ToolStripMenuItem queueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuPhaseNext;
        private System.Windows.Forms.ToolStripMenuItem MenuPhasePrev;
        private System.Windows.Forms.Timer DataTimer;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}

