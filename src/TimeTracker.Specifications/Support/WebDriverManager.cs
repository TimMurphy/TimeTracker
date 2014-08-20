using System;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;

namespace TimeTracker.Specifications.Support
{
    public class WebDriverManager
    {
        private static readonly Lazy<IWebDriver> LazyInstance = new Lazy<IWebDriver>(() => new SimpleBrowserDriver());
 
        public static IWebDriver Instance { get { return LazyInstance.Value; } }
    }
}