using System;
using TimeTracker.Specifications.Support.MoveToNuGetPackage;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public class WebApplicationManager : IWebApplicationManager
    {
        private const string WebsiteName = "TimeTracker.WebApplication"; // todo: get website name from project file?
        private const string IndexPageTitle = "TimeTracker";

        public WebApplicationManager()
            : this(GetUrl("http"), GetUrl("https"))
        {
        }

        public WebApplicationManager(string httpUrl, string httpsUrl)
            : this(WebsiteName, httpUrl, httpsUrl, IndexPageTitle)
        {
        }

        public WebApplicationManager(string websiteName, string httpUrl, string httpsUrl, string indexPageTitle)
            : this(new IISExpressWebServer(websiteName, httpUrl, indexPageTitle), new BaseUri(httpUrl, httpsUrl))
        {
        }

        private WebApplicationManager(IWebServer webServer, BaseUri baseUri)
        {
            WebServer = webServer;
            BaseUri = baseUri;
        }

        public BaseUri BaseUri { get; private set; }
        public IWebServer WebServer { get; private set; }

        private static string GetUrl(string protocol)
        {
            return string.Format("{0}://{1}/", protocol, Environment.MachineName);
        }
    }
}