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
    public partial class QueueConfigForm : Form
    {
        MainForm parent;

        public QueueConfigForm(MainForm sender)
        {
            InitializeComponent();
            parent = sender;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            parent.CurrentPhase = (int)PositionSelector.Value;
            Close();
        }
    }
}
