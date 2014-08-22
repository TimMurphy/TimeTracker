using System;

namespace TimeTracker.Specifications.Support.MoveToNuGetPackage
{
    public static class UriExtensions
    {
        public static Uri Combine(this Uri uri, string relativeUrl)
        {
            return new Uri(uri, relativeUrl);
        }
    }
}
