using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TimeTracker.Specifications.Support
{
    [Binding]
    public class CommonContextInjection
    {
        private readonly IObjectContainer ObjectContainer;

        public CommonContextInjection(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeAllScenarios()
        {
            ObjectContainer.RegisterInstanceAs(WebDriverManager.Instance);
            ObjectContainer.RegisterTypeAs<WebApplication, IWebApplication>();
        }
    }
}
