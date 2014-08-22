using System;

namespace TimeTracker.Specifications.Support.MoveToNuGetPackage
{
    public class BaseUri
    {
        private readonly Uri HTTP;
        private readonly Uri HTTPS;

        public BaseUri(string http, string https)
        {
            HTTP = new Uri(http);
            HTTPS = new Uri(https);
        }

        public string FullUrl(string relativeUrl)
        {
            return FullUrl(relativeUrl, true);
        }

        public string FullUrl(string relativeUrl, bool useHTTPS)
        {
            return (useHTTPS ? HTTPS.Combine(relativeUrl) : HTTP.Combine(relativeUrl)).ToString();
        }
    }
}