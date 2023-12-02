using NUnit.Framework;
using SpecSauce.Drivers;
using SpecSauce.Page;
using SpecSauce.Utils;
[assembly : Parallelizable(ParallelScope.Fixtures)]


namespace SpecSauce.StepDefinitions
{
    [Binding]
    [Parallelizable(ParallelScope.All)]


    public class StepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        DriverHandler driverHandler = new DriverHandler();


        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var tags = _scenarioContext.ScenarioInfo.Tags;

            driverHandler.RemoteDriverInitializer(tags[0]);
            
        }

        [Given(@"Multiple browsers at same time ""(.*)""")]
        public void MultipleBrowsers(String browser)
        {
          TestPage page = new TestPage(driverHandler);
            page.TestMethod();

        }
    }
}