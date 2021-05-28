﻿using System;
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
            Process proc = new Process();
            proc.StartInfo.FileName = "/home/Desktop/GamblingTask-main/Gambling Task/PythonTest.py";
            proc.StartInfo.Arguments = amount.ToString();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
        }
    }
}
