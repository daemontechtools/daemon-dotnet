using System;
using System.Diagnostics;

namespace BuildChain
{
    public static class Util
    { 
        public static string FindBin(string BinName)
        {
            var binPath = String.Empty;
            ProcessStartInfo startInfo;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                startInfo = new ProcessStartInfo("where", BinName)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
            }
            else
            {
                startInfo = new ProcessStartInfo("command", "-v " + BinName)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
            }
            var process = Process.Start(startInfo);

            if (process == null)
            {
                throw new Exception("Unable to find binary path; Failed to start process");
            }

            binPath = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return binPath;
        }
    }
}