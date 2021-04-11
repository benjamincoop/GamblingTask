using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Remote_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] IPAddresses = { "", "", "", "" };
        int index = 0;

        Socket socket = new TcpClient().Client;
        byte[] buffer = new byte[64];

        private void ChamberSelectChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                index = Convert.ToInt32(((RadioButton)sender).Text) - 1;
                Controls.Find("IPAddressBox", false)[0].Text = IPAddresses[index];
            }
        }

        private void IPAddressBox_TextChanged(object sender, EventArgs e)
        {
            IPAddresses[index] = ((TextBox)sender).Text;
        }

        private void SendCommand(object sender, EventArgs e)
        {

            string cmd;
            switch(((ToolStripMenuItem)sender).Text)
            {
                case "Save Phase":
                    cmd = "save_phase";
                    break;
                case "Load Phase":
                    cmd = "load_phase";
                    break;
                case "Export Data":
                    cmd = "export_data";
                    break;
                case "Phase":
                    cmd = "edit_phase";
                    break;
                case "Interface":
                    cmd = "edit_interface";
                    break;
                case "Queue":
                    cmd = "edit_queue";
                    break;
                case "Start/Stop":
                    cmd = "start_stop";
                    break;
                case "Next":
                    cmd = "next_phase";
                    break;
                case "Previous":
                    cmd = "prev_phase";
                    break;
                case "Exit":
                    cmd = "exit";
                    break;
                default:
                    cmd = "error";
                    break;
            }
            if (socket.Connected)
            {
                // attempt to send
                try
                {
                    socket.Send(Encoding.UTF8.GetBytes(cmd));
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            else
            {
                // attempt to connect and send
                try
                {
                    IPAddress address = IPAddress.Parse(IPAddresses[index]);
                    socket.Connect(address, 80);
                    socket.Send(Encoding.UTF8.GetBytes(cmd));
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/benjamincoop/GamblingTask/wiki");
        }
    }
}
