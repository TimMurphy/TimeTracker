using System;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public class WebDriverManager : IWebDriverManager
    {
        private static readonly Lazy<IWebDriver> LazyInstance = new Lazy<IWebDriver>(() => new SimpleBrowserDriver());

        public IWebDriver Instance { get { return LazyInstance.Value; } }
    }
}