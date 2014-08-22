using System;
using OpenMagic.Exceptions;
using OpenQA.Selenium;
using TimeTracker.Specifications.Support.WebApplication;

namespace TimeTracker.Specifications.Support
{
    public abstract class BaseSteps
    {
        private readonly Lazy<IWebDriver> LazyWebDriver;
        public readonly IWebApplicationManager WebApplication;
        private readonly IWebDriverManager WebDriverManager;

        protected BaseSteps()
            : this(new WebApplicationManager(), new WebDriverManager())
        {
        }

        protected BaseSteps(IWebApplicationManager webApplication, IWebDriverManager webDriverManager)
        {
            WebApplication = webApplication;
            WebDriverManager = webDriverManager;

            LazyWebDriver = new Lazy<IWebDriver>(() =>
            {
                WebApplication.WebServer.StartIfNotRunning();

                return WebDriverManager.Instance;
            });
        }

        protected string ExpectedUrl { get; set; }
        protected string RequestedUrl { get; set; }

        protected IWebDriver WebDriver
        {
            get { return LazyWebDriver.Value; }
        }

        protected string GetFullUrl(string relativeUrl)
        {
            return WebApplication.BaseUri.FullUrl(relativeUrl);
        }

        protected void Login()
        {
            Login("tim@26tp.com");
        }

        protected void Login(string emailAddress)
        {
            throw new ToDoException();
        }

        protected void Logout()
        {
            throw new ToDoException();
        }

        protected string GoToRelativeUrl(string relativeUrl)
        {
            return GoToRelativeUrl(relativeUrl, true);
        }

        protected string GoToRelativeUrl(string relativeUrl, bool useHTTPS)
        {
            RequestedUrl = WebApplication.BaseUri.FullUrl(relativeUrl, useHTTPS);
            ExpectedUrl = WebApplication.BaseUri.FullUrl(relativeUrl, true);

            WebDriver.Navigate().GoToUrl(RequestedUrl);

            return RequestedUrl;
        }
    }
}