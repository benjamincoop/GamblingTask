
namespace Remote_Control
{
    partial class Form1
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
            this.selectionGroupBox = new System.Windows.Forms.GroupBox();
            this.chamber1Select = new System.Windows.Forms.RadioButton();
            this.chamber2Select = new System.Windows.Forms.RadioButton();
            this.chamber3Select = new System.Windows.Forms.RadioButton();
            this.chamber4Select = new System.Windows.Forms.RadioButton();
            this.IPAddressBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePhaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPhaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionGroupBox
            // 
            this.selectionGroupBox.Controls.Add(this.chamber4Select);
            this.selectionGroupBox.Controls.Add(this.chamber3Select);
            this.selectionGroupBox.Controls.Add(this.chamber2Select);
            this.selectionGroupBox.Controls.Add(this.chamber1Select);
            this.selectionGroupBox.Location = new System.Drawing.Point(12, 57);
            this.selectionGroupBox.Name = "selectionGroupBox";
            this.selectionGroupBox.Size = new System.Drawing.Size(142, 127);
            this.selectionGroupBox.TabIndex = 0;
            this.selectionGroupBox.TabStop = false;
            this.selectionGroupBox.Text = "Chamber Selection";
            // 
            // chamber1Select
            // 
            this.chamber1Select.AutoSize = true;
            this.chamber1Select.Location = new System.Drawing.Point(22, 42);
            this.chamber1Select.Name = "chamber1Select";
            this.chamber1Select.Size = new System.Drawing.Size(37, 21);
            this.chamber1Select.TabIndex = 0;
            this.chamber1Select.TabStop = true;
            this.chamber1Select.Text = "1";
            this.chamber1Select.UseVisualStyleBackColor = true;
            this.chamber1Select.CheckedChanged += new System.EventHandler(this.ChamberSelectChanged);
            // 
            // chamber2Select
            // 
            this.chamber2Select.AutoSize = true;
            this.chamber2Select.Location = new System.Drawing.Point(75, 42);
            this.chamber2Select.Name = "chamber2Select";
            this.chamber2Select.Size = new System.Drawing.Size(37, 21);
            this.chamber2Select.TabIndex = 1;
            this.chamber2Select.TabStop = true;
            this.chamber2Select.Text = "2";
            this.chamber2Select.UseVisualStyleBackColor = true;
            this.chamber2Select.CheckedChanged += new System.EventHandler(this.ChamberSelectChanged);
            // 
            // chamber3Select
            // 
            this.chamber3Select.AutoSize = true;
            this.chamber3Select.Location = new System.Drawing.Point(22, 83);
            this.chamber3Select.Name = "chamber3Select";
            this.chamber3Select.Size = new System.Drawing.Size(37, 21);
            this.chamber3Select.TabIndex = 2;
            this.chamber3Select.TabStop = true;
            this.chamber3Select.Text = "3";
            this.chamber3Select.UseVisualStyleBackColor = true;
            this.chamber3Select.CheckedChanged += new System.EventHandler(this.ChamberSelectChanged);
            // 
            // chamber4Select
            // 
            this.chamber4Select.AutoSize = true;
            this.chamber4Select.Location = new System.Drawing.Point(75, 83);
            this.chamber4Select.Name = "chamber4Select";
            this.chamber4Select.Size = new System.Drawing.Size(37, 21);
            this.chamber4Select.TabIndex = 3;
            this.chamber4Select.TabStop = true;
            this.chamber4Select.Text = "4";
            this.chamber4Select.UseVisualStyleBackColor = true;
            this.chamber4Select.CheckedChanged += new System.EventHandler(this.ChamberSelectChanged);
            // 
            // IPAddressBox
            // 
            this.IPAddressBox.Location = new System.Drawing.Point(160, 162);
            this.IPAddressBox.Name = "IPAddressBox";
            this.IPAddressBox.Size = new System.Drawing.Size(192, 22);
            this.IPAddressBox.TabIndex = 1;
            this.IPAddressBox.TextChanged += new System.EventHandler(this.IPAddressBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.phaseToolStripMenuItem1,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePhaseToolStripMenuItem,
            this.loadPhaseToolStripMenuItem,
            this.exportDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // savePhaseToolStripMenuItem
            // 
            this.savePhaseToolStripMenuItem.Name = "savePhaseToolStripMenuItem";
            this.savePhaseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.savePhaseToolStripMenuItem.Text = "Save Phase";
            this.savePhaseToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // loadPhaseToolStripMenuItem
            // 
            this.loadPhaseToolStripMenuItem.Name = "loadPhaseToolStripMenuItem";
            this.loadPhaseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadPhaseToolStripMenuItem.Text = "Load Phase";
            this.loadPhaseToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phaseToolStripMenuItem,
            this.interfaceToolStripMenuItem,
            this.queueToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // phaseToolStripMenuItem
            // 
            this.phaseToolStripMenuItem.Name = "phaseToolStripMenuItem";
            this.phaseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.phaseToolStripMenuItem.Text = "Phase";
            this.phaseToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // interfaceToolStripMenuItem
            // 
            this.interfaceToolStripMenuItem.Name = "interfaceToolStripMenuItem";
            this.interfaceToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.interfaceToolStripMenuItem.Text = "Interface";
            this.interfaceToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // queueToolStripMenuItem
            // 
            this.queueToolStripMenuItem.Name = "queueToolStripMenuItem";
            this.queueToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.queueToolStripMenuItem.Text = "Queue";
            this.queueToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // phaseToolStripMenuItem1
            // 
            this.phaseToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStopToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.previousToolStripMenuItem});
            this.phaseToolStripMenuItem1.Name = "phaseToolStripMenuItem1";
            this.phaseToolStripMenuItem1.Size = new System.Drawing.Size(61, 24);
            this.phaseToolStripMenuItem1.Text = "Phase";
            // 
            // startStopToolStripMenuItem
            // 
            this.startStopToolStripMenuItem.Name = "startStopToolStripMenuItem";
            this.startStopToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.startStopToolStripMenuItem.Text = "Start/Stop";
            this.startStopToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nextToolStripMenuItem.Text = "Next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.previousToolStripMenuItem.Text = "Previous";
            this.previousToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.SendCommand);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPAddressBox);
            this.Controls.Add(this.selectionGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Operant Chamber Control";
            this.selectionGroupBox.ResumeLayout(false);
            this.selectionGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox selectionGroupBox;
        private System.Windows.Forms.RadioButton chamber4Select;
        private System.Windows.Forms.RadioButton chamber3Select;
        private System.Windows.Forms.RadioButton chamber2Select;
        private System.Windows.Forms.RadioButton chamber1Select;
        private System.Windows.Forms.TextBox IPAddressBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePhaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPhaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

