using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Gambling_Task
{
    public static class DispenserInterface
    {
        public static void Dispense(int amount)
        {
            string command = "python";
            string args = "/home/Desktop/GamblingTask-main/Gambling Task/bin/Debug/Dispense.py " + amount.ToString();

            //Process proc = new Process();
            //proc.StartInfo.FileName = "python.exe";
            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.UseShellExecute = false;

            //proc.StartInfo.Arguments = string.Concat(pathToScript, " ", amount.ToString());
            //proc.Start();

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.UseShellExecute = true;
            processInfo.FileName = command;
            processInfo.Arguments = args;

            Process.Start(processInfo);
        }
    }
}
