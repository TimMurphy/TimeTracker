using TimeTracker.Specifications.Support.MoveToNuGetPackage;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public interface IWebApplicationManager
    {
        BaseUri BaseUri { get; }
        IWebServer WebServer { get; }
    }
}