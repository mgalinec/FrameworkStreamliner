using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FrameworkStreamliner
{
    /// <summary>Useful constants and static methods from non static classes or methods.</summary>
    public static class StaticEx
    {
        public const string EngLettersLower = "abcdefghijklmnopqrstuvwxyz";
        public const string EngLettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string CroLettersLower = "abcčćdđefghijklmnoprsštuvzž";
        public const string CroLettersUpper = "ABCČĆDĐEFGHIJKLMNOPRSŠTUVZŽ";

        [ThreadStatic]
        private static Random _rng;

        public static Random Rng
        {
            get
            {
                if (_rng == null)
                {
                    _rng = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
                }
                return _rng;
            }
        }

        public static List<string> GetLocalIpAddresses()
        {
            List<string> result = new List<string>();
            // First get the host name of local machine.
            String strHostName = Dns.GetHostName();

            // Then using host name, get the IP address list..
            var addresses = Dns.GetHostEntry(strHostName).AddressList;

            // address must be IpV4 (for our appl.) and not the loopback address
            for (int i = 0; i < addresses.Length; i++)
            {
                if (addresses[i].AddressFamily != AddressFamily.InterNetworkV6 && !IPAddress.IsLoopback(addresses[i]))
                {
                    result.Add(addresses[i].ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// Returns tuple of stdout and stderror
        /// </summary>
        public static Tuple<byte[], string> StartProcess(string fileName, string arguments = null, Dictionary<string, string> environmentVars = null, byte[] stdIn = null, bool captureOutput = true, bool captureError = true, int waitForExitMs = 15000)
        {
            byte[] stdOut = null;
            string stdError = null;
            ProcessStartInfo startInfo = new ProcessStartInfo(fileName, arguments);
            if (environmentVars != null)
            {
                foreach (var currentEnvironmentVar in environmentVars)
                {
                    startInfo.Environment[currentEnvironmentVar.Key] = currentEnvironmentVar.Value;
                }
            }
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            if (captureOutput)
            {
                startInfo.RedirectStandardOutput = true;
            }
            else
            {
                startInfo.RedirectStandardOutput = false;
            }
            if (captureError)
            {
                startInfo.RedirectStandardError = true;
            }
            else
            {
                startInfo.RedirectStandardError = false;
            }
            if (stdIn == null)
            {
                startInfo.RedirectStandardInput = false;
            }
            else
            {
                startInfo.RedirectStandardInput = true;
            }
            using (Process process = Process.Start(startInfo))
            {
                if (stdIn != null)
                {
                    process.StandardInput.BaseStream.Write(stdIn, 0, stdIn.Length);
                }
                if (captureError)
                {
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            stdError += e.Data;
                        }
                    };
                    process.BeginErrorReadLine();
                }
                if (captureOutput)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int count = 0;
                        do
                        {
                            byte[] buf = new byte[1024];
                            count = process.StandardOutput.BaseStream.Read(buf, 0, 1024);
                            ms.Write(buf, 0, count);
                        } while (process.StandardOutput.BaseStream.CanRead && count > 0);
                        stdOut = ms.ToArray();
                    }
                }
                process.WaitForExit(waitForExitMs);
            }
            return new Tuple<byte[], string>(stdOut, stdError);
        }
    }
}
