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
            ProcessStartInfo procInfo = new ProcessStartInfo("/bin/bash", "python /home/Desktop/GamblingTask-main/Gambling Task/PythonTest.py " + amount.ToString());
            procInfo.RedirectStandardOutput = true;
            procInfo.UseShellExecute = false;
            procInfo.CreateNoWindow = true;
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procInfo;
            proc.Start();
        }
    }
}
