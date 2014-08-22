using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public class IISExpressWebServer : IWebServer
    {
        private readonly string BaseUrl;
        private readonly string IISExpressExe;
        private readonly string IndexPageTitle;
        private readonly string WebsiteName;

        private Process Process;

        public IISExpressWebServer(string websiteName, string baseUrl, string indexPageTitle)
            : this(GetIISExpressExe(), websiteName, baseUrl, indexPageTitle)
        {
        }

        public IISExpressWebServer(string iisExpressExe, string websiteName, string baseUrl, string indexPageTitle)
        {
            if (!File.Exists(iisExpressExe))
            {
                throw new FileNotFoundException(string.Format("Cannot start IIS Express because '{0}' cannot be found.", iisExpressExe), iisExpressExe);
            }

            IISExpressExe = iisExpressExe;
            WebsiteName = websiteName;
            BaseUrl = baseUrl;
            IndexPageTitle = indexPageTitle;
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var response = client.GetAsync("/").Result;

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var content = response.Content.ReadAsStringAsync().Result;

                return content.Contains(string.Format("<title>{0}</title>", IndexPageTitle));
            }
        }

        private void Stop()
        {
            if (Process == null)
            {
                return;
            }

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