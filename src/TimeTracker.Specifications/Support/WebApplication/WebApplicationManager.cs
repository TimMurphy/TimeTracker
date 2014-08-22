using System;
using TimeTracker.Specifications.Support.MoveToNuGetPackage;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public class WebApplicationManager : IWebApplicationManager
    {
        public WebApplicationManager()
            : this(GetUrl("http"), GetUrl("https"))
        {
        }

        private static string GetUrl(string protocol)
        {
            return string.Format("{0}://{1}/", protocol, Environment.MachineName);
        }

        public WebApplicationManager(string httpUrl, string httpsUrl)
            : this(
                // todo: get website name from project file?
                "TimeTracker.WebApplication", httpUrl, httpsUrl)
        {
        }

        public WebApplicationManager(string websiteName, string httpUrl, string httpsUrl)
            : this(new IISExpressWebServer(websiteName), new BaseUri(httpUrl, httpsUrl))
        {
        }

        private WebApplicationManager(IWebServer webServer, BaseUri baseUri)
        {
            WebServer = webServer;
            BaseUri = baseUri;
        }

        public BaseUri BaseUri { get; private set; }
        public IWebServer WebServer { get; private set; }
    }
}