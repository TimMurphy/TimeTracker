using FluentAssertions;
using TechTalk.SpecFlow;
using TimeTracker.Specifications.Support;

namespace TimeTracker.Specifications.Features.Steps
{
    [Binding]
    public class HTTPSEverywhereSteps : BaseSteps
    {
        [When(@"I go to any HTTP url")]
        public void WhenIGoToAnyHTTPUrl()
        {
            GoToRelativeUrl("/", false);
        }

        [Then(@"I am redirected to the equivalent HTTPS url")]
        public void ThenIAmRedirectedToTheEquivalentHTTPSUrl()
        {
            WebDriver.Url.Should().Be(ExpectedUrl, "because the Web Application should only serve HTTPS urls");
        }
    }
}