using System;
using System.Diagnostics;
using System.IO;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public class IISExpressWebServer : IWebServer
    {
        private readonly string IISExpressExe;
        private readonly string WebsiteName;

        private Process Process;

        public IISExpressWebServer(string websiteName)
            : this(GetIISExpressExe(), websiteName)
        {
        }

        public IISExpressWebServer(string iisExpressExe, string websiteName)
        {
            if (!File.Exists(iisExpressExe))
            {
                throw new FileNotFoundException(string.Format("Cannot start IIS Express because '{0}' cannot be found.", iisExpressExe), iisExpressExe);
            }

            IISExpressExe = iisExpressExe;
            WebsiteName = websiteName;
        }

        public void StartIfNotRunning()
        {
            if (IsRunning())
            {
                return;
            }

            Start();
        }

        private void Start()
        {
            Bindings.AfterTestRunTasks.Add(Stop);

            var processStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = String.Format("/site:\"{0}\"", WebsiteName),
                FileName = IISExpressExe
            };

            Process = Process.Start(processStartInfo);
        }

        private bool IsRunning()
        {
            // todo: test via ping?
            return Process != null;
        }

        private void Stop()
        {
            if (!Process.HasExited)
            {
                Process.Kill();
            }

            Process.Dispose();
            Process = null;
        }

        public static string GetIISExpressExe()
        {
            var key = Environment.Is64BitOperatingSystem ? "programfiles(x86)" : "programfiles";
            var programfiles = Environment.GetEnvironmentVariable(key);
            var iisExpressExe = Path.Combine(programfiles, @"IIS Express\iisexpress.exe");

            return iisExpressExe;
        }
    }
}