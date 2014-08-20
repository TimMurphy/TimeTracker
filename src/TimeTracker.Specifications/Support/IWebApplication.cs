using System;

namespace TimeTracker.Specifications.Support
{
    public interface IWebApplication
    {
        Uri FullUri(string resource);
        Uri FullUri(string resource, bool useHTTPS);
    }
}