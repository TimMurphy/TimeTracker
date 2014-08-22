using TechTalk.SpecFlow;
using TimeTracker.Specifications.Support;

namespace TimeTracker.Specifications.Features.Steps
{
    [Binding]
    public class RequireGoogleAuthenticationForKnownEmailAddressSteps : BaseSteps
    {
        [Given(@"I am not authenticated")]
        public void GivenIAmNotAuthenticated()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am authenticated with a known email addresses")]
        public void GivenIAmAuthenticatedWithAKnownEmailAddresses()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am authenticated with an unknown email addresses")]
        public void GivenIAmAuthenticatedWithAnUnknownEmailAddresses()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I goto any url")]
        public void WhenIGotoAnyUrl()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I am redirected to the sign in page")]
        public void ThenIAmRedirectedToTheSignInPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can view the requested page")]
        public void ThenICanViewTheRequestedPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the sign in page says I am an unknown user")]
        public void ThenTheSignInPageSaysIAmAnUnknownUser()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
