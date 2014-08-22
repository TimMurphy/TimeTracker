using TimeTracker.Specifications.Support.MoveToNuGetPackage;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public class WebApplicationManager : IWebApplicationManager
    {
        public WebApplicationManager()
            : this(
                // todo: get website name from project file?
                "TimeTracker.WebApplication",
                // todo: get url from project file or iis express
                "http://localhost:49700/",
                // todo: get url from project file or iis express
                "https://localhost:44301/")
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