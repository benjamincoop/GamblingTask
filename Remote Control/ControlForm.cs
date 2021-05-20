using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Remote_Control
{
    public partial class ControlForm : Form
    {
        public ControlForm()
        {
            InitializeComponent();
        }

        private string exportPath = ""; // the external location to save data to

        string[] IPAddresses = { "", "", "", "" };
        int index = 0;

        Socket socket = new TcpClient().Client;

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

        private void SendCmd(string cmd)
        {
            if (socket.Connected)
            {
                // attempt to send
                try
                {
                    SocketAsyncEventArgs sendArgs = new SocketAsyncEventArgs();
                    byte[] buffer = Encoding.ASCII.GetBytes(cmd);
                    sendArgs.SetBuffer(buffer, 0, buffer.Length);
                    sendArgs.Completed += SendCompleted;
                    socket.SendAsync(sendArgs);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            else
            {
                // attempt to connect and send
                try
                {
                    IPAddress address = IPAddress.Parse(IPAddresses[index]);
                    socket.Connect(address, 25565);
                    SocketAsyncEventArgs sendArgs = new SocketAsyncEventArgs();
                    byte[] buffer = Encoding.ASCII.GetBytes(cmd);
                    sendArgs.SetBuffer(buffer, 0, buffer.Length);
                    sendArgs.Completed += SendCompleted;
                    socket.SendAsync(sendArgs);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        private void SendCompleted(object sender, SocketAsyncEventArgs e)
        {
        }

        private void SendFile(string file)
        {
            Thread.Sleep(500); // give recieving machine a moment to catch up
            if (socket.Connected)
            {
                // attempt to send
                try
                {
                    socket.SendFile(file, null, null, TransmitFileOptions.WriteBehind);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            else
            {
                // attempt to connect and send
                try
                {
                    IPAddress address = IPAddress.Parse(IPAddresses[index]);
                    socket.Connect(address, 25565);
                    socket.SendFile(file, null, null, TransmitFileOptions.WriteBehind);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        /// <summary>
        /// Loads a config file, converts it into a byte array, and sends it to remote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadPhaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OpenDialog.ShowDialog() == DialogResult.OK)
            {
                SendCmd("load_phase!");
                SendFile(OpenDialog.FileName);
            }      
        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SaveDialog.ShowDialog() == DialogResult.OK)
            {
                string exportPath = SaveDialog.FileName;
                SendCmd("export_data!");
                byte[] lenBuff = new byte[sizeof(int)];
                socket.Receive(lenBuff);
                int len = BitConverter.ToInt32(lenBuff, 0);
                byte[] data = new byte[len];
                socket.Receive(data, len, SocketFlags.None);
                System.IO.File.AppendAllText(exportPath, Encoding.ASCII.GetString(data));
                MessageBox.Show("Data exported.");
            }
        }

        private void startStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCmd("start_stop!");
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCmd("next_phase!");
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCmd("prev_phase!");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/benjamincoop/GamblingTask/wiki");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCmd("exit!");
        }
    }
}
