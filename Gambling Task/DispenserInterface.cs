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
            string pathToScript = "C:\\Users\\nebab\\Desktop\\Dispense.py";
            char[] splitter = { '\r' };

            Process proc = new Process();
            proc.StartInfo.FileName = "python.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;

            proc.StartInfo.Arguments = string.Concat(pathToScript, " ", amount.ToString());
            proc.Start();

            StreamReader sReader = proc.StandardOutput;
            string[] output = sReader.ReadToEnd().Split(splitter);

            foreach (string s in output)
                Console.WriteLine(s);

            proc.WaitForExit();
        }
    }
}
