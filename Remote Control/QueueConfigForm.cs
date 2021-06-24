using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Control
{
    public partial class QueueConfigForm : Form
    {
        ControlForm parent;

        public QueueConfigForm(ControlForm sender)
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
