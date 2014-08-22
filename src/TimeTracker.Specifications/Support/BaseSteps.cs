using System;
using OpenQA.Selenium;
using TimeTracker.Specifications.Support.WebApplication;

namespace TimeTracker.Specifications.Support
{
    public abstract class BaseSteps
    {
        private readonly Lazy<IWebDriver> LazyWebDriver;
        private readonly IWebApplicationManager WebApplicationManager;
        private readonly IWebDriverManager WebDriverManager;

        protected BaseSteps()
            : this(new WebApplicationManager(), new WebDriverManager())
        {
        }

        protected BaseSteps(IWebApplicationManager webApplicationManager, IWebDriverManager webDriverManager)
        {
            WebApplicationManager = webApplicationManager;
            WebDriverManager = webDriverManager;

            LazyWebDriver = new Lazy<IWebDriver>(() =>
            {
                WebApplicationManager.WebServer.StartIfNotRunning();

                return WebDriverManager.Instance;
            });
        }

        protected string ExpectedUrl { get; set; }
        protected string RequestedUrl { get; set; }

        protected IWebDriver WebDriver
        {
            get { return LazyWebDriver.Value; }
        }

        protected string GoToRelativeUrl(string relativeUrl)
        {
            return GoToRelativeUrl(relativeUrl, true);
        }

        protected string GoToRelativeUrl(string relativeUrl, bool useHTTPS)
        {
            RequestedUrl = WebApplicationManager.BaseUri.FullUrl(relativeUrl, useHTTPS);
            ExpectedUrl = WebApplicationManager.BaseUri.FullUrl(relativeUrl, true);

            WebDriver.Navigate().GoToUrl(RequestedUrl);

            return RequestedUrl;
        }
    }
}