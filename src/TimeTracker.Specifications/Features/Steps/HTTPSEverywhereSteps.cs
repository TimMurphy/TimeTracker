using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TimeTracker.Specifications.Support;

namespace TimeTracker.Specifications.Features.Steps
{
    [Binding]
    public class HTTPSEverywhereSteps
    {
        private readonly IWebDriver WebDriver;
        private readonly IWebApplication WebApplication;
        private string GoToResource;

        public HTTPSEverywhereSteps(IWebDriver webDriver, IWebApplication webApplication)
        {
            WebDriver = webDriver;
            WebApplication = webApplication;
        }

        [When(@"I go to any HTTP url")]
        public void WhenIGoToAnyHTTPUrl()
        {
            GoToResource = "/";
            WebDriver.Navigate().GoToUrl(WebApplication.FullUri(GoToResource, false));
        }

        [Then(@"I am redirected to the equivalent HTTPS url")]
        public void ThenIAmRedirectedToTheEquivalentHTTPSUrl()
        {
            WebDriver.Url.Should().Be(WebApplication.FullUri(GoToResource).ToString(), "because the Web Application should only serve HTTPS urls");
        }
    }
}
