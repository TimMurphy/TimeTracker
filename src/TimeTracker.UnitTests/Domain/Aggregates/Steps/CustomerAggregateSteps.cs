using TechTalk.SpecFlow;

namespace TimeTracker.UnitTests.Domain.Aggregates.Steps
{
    [Binding]
    public class CustomerAggregateSteps
    {
        [When(@"I send a CreateCustomer command")]
        public void WhenISendACreateCustomerCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"CustomerAggregate is created")]
        public void ThenCustomerAggregateIsCreated()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"CustomerView is created")]
        public void ThenCustomerViewIsCreated()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
