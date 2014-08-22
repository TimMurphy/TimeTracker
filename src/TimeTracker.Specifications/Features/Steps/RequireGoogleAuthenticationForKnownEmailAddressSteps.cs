using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TimeTracker.Specifications.Support;
using TimeTracker.Specifications.Support.WebApplication;

namespace TimeTracker.Specifications.Features.Steps
{
    [Binding]
    public class RequireGoogleAuthenticationForKnownEmailAddressSteps : BaseSteps
    {
        [Given(@"I am not authenticated")]
        public void GivenIAmNotAuthenticated()
        {
            Logout();
        }

        [Given(@"I am authenticated with a known email addresses")]
        public void GivenIAmAuthenticatedWithAKnownEmailAddresses()
        {
            Login();
        }

        [Given(@"I am authenticated with an unknown email addresses")]
        public void GivenIAmAuthenticatedWithAnUnknownEmailAddresses()
        {
            Login("unknown-email-address@example.com");
        }

        [When(@"I goto any url")]
        public void WhenIGotoAnyUrl()
        {
            GoToRelativeUrl("/");
        }

        [Then(@"I am redirected to the log in page")]
        public void ThenIAmRedirectedToTheLogInPage()
        {
            WebDriver.Url.Should().Be(GetFullUrl("/account/login"));
        }

        [Then(@"I can view the requested page")]
        public void ThenICanViewTheRequestedPage()
        {
            WebDriver.Url.Should().Be(ExpectedUrl);
        }

        [Then(@"the log in page says I am an unknown user")]
        public void ThenTheLogInPageSaysIAmAnUnknownUser()
        {
            WebDriver.FindElement(By.Id("unknown-user")).Displayed.Should().BeTrue();
        }
    }
}
