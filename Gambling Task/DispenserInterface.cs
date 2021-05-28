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
            string cmd = "ls";
            string args = "";
            //string args = "'/home/Desktop/GamblingTask-main/Gambling Task/PythonTest.py' " + amount.ToString();
            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.FileName = cmd;
            procInfo.Arguments = args;
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardOutput = true;
            Process.Start(procInfo);

            //Process proc = new Process();
            //proc.StartInfo.FileName = "python ;
            //proc.StartInfo.Arguments = amount.ToString();
            //proc.StartInfo.UseShellExecute = false;
            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.Start();
        }
    }
}
