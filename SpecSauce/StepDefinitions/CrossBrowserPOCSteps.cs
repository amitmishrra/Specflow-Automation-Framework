using Drivers.BrowserEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecSauce.Drivers;
using SpecSauce.Page;
using SpecSauce.Support;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]

namespace SpecSauce.StepDefinitions
{
    [Binding]
    public class CrossBrowserPOCSteps
    {

        public IWebDriver _browser;
        public IWebDriver driver;
        public bool runLocallyFlag = true;
        CommonVariables variables = new CommonVariables();
        ThreadManagement management = new ThreadManagement();
        List<IWebDriver> driversList = new List<IWebDriver>();
        ThreadLocal<IWebDriver> driverThread = new ThreadLocal<IWebDriver> ();
        TestPage page = new TestPage();

        [BeforeScenario]
        [Obsolete]
        public static void BeforeScenario()
        {
            var scenarioInfo = ScenarioContext.Current.ScenarioInfo;
        }

       
        [Given(@"Launch the browser ""([^""]*)""")]
        public void GivenLaunchTheBrowser(string browser)
        {
            management.RunInThreads(variables.browsersArray, (browser) =>
            {
                driverThread.Value = new BrowserEngine(management.selectBrowser(browser))
                     .LaunchBrowser("latest", browser == "SAFARI" ? "macOS 13" : "Windows 10", "oauth-nimbusthenewt-f8984", "ca11bdb5-a575-4127-9115-c0c9b82b0058", "testbuild", "Title", 6000, runLocallyFlag);
                /*var _driver = this._browser;*/
               /* driversList.Add(_driver);*/
            });
        }

        [When(@"Open the google")]
        public void WhenOpenTheGoogle()
        {
            /*management.ThreadWrapper(driversList, (driver) =>
            {
               
            });*/
            page.VisitPage(driverThread.Value);
        }

        [When(@"Input values")]
        public void InputValues()
        {
            /*management.ThreadWrapper(driversList, (driver) =>
            {
            });*/
            page.InputValues(driverThread.Value);

        }

        [When(@"Perform Login")]
        public void Login()
        {
            /*management.ThreadWrapper(driversList, (driver) =>
            {
            });*/
            page.ClickSubmit(driverThread.Value);

        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            /*management.ThreadWrapper(driversList, (driver) =>
            {
                driver.Close();
            });*/
            driverThread.Value.Quit();
        }

       
    }
}
