using OpenQA.Selenium;

namespace TimeTracker.Specifications.Support.WebApplication
{
    public interface IWebDriverManager
    {
        IWebDriver Instance { get; }
    }
}