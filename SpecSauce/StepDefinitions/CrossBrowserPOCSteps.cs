using Drivers.BrowserEngine;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecSauce.Drivers;
using SpecSauce.Page;
using SpecSauce.Support;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace SpecSauce.StepDefinitions
{
    [Binding]
    public class CrossBrowserPOCSteps
    {

        public IWebDriver _browser;
        public IWebDriver driver;
        public bool runLocallyFlag = true;
        ThreadManagement management;
        CommonVariables variables;
        TestPage page;
        private BrowserEngine browser = null;
        private string epayUrl;
        private string username;
        private string password;
        private ScenarioContext _scenarioContext;
        private string sauceLabsUserName;
        private string sauceLabsAccessKey;
        private string sauceLabsbuild;
        private int sauceLabsCommandTimeout;
        private string chromeBrowserPlatform;
        private string chromeBrowserVersion;
        private string edgeBrowserPlatform;
        private string edgeBrowserVersion;
        private string safariBrowserPlatform;
        private string safariBrowserVersion;
        private bool crossBrowserTestingEnabled;
        private readonly IUnitTestRuntimeProvider _unitTestRuntimeProvider;
        private static readonly ILog log = LogManager.GetLogger(typeof(CrossBrowserPOCSteps));




        public CrossBrowserPOCSteps()
        {
            /*this.crossBrowserTestingEnabled = bool.Parse(ConfigurationManager.AppSettings["RunCrossBrowserTests"]);
            this.sauceLabsUserName = ConfigurationManager.AppSettings["SauceLabsUsername"];
            this.sauceLabsAccessKey = ConfigurationManager.AppSettings["SauceLabsAccessKey"];
            this.sauceLabsbuild = ConfigurationManager.AppSettings["SauceLabsbuild"];
            this.sauceLabsCommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["SauceLabsCommandTimeout"]);
            this.chromeBrowserPlatform = ConfigurationManager.AppSettings["ChromeBrowserPlatform"];
            this.chromeBrowserVersion = ConfigurationManager.AppSettings["ChromeBrowserVersion"];
            this.edgeBrowserPlatform = ConfigurationManager.AppSettings["EdgeBrowserPlatform"];
            this.edgeBrowserVersion = ConfigurationManager.AppSettings["EdgeBrowserVersion"];
            this.safariBrowserPlatform = ConfigurationManager.AppSettings["SafariBrowserPlatform"];
            this.safariBrowserVersion = ConfigurationManager.AppSettings["SafariBrowserVersion"];
            this.chromeBrowserPlatform = ConfigurationManager.AppSettings["ChromeBrowserPlatform"];*/
            this.variables = new CommonVariables();
            this.management = new ThreadManagement(this.variables);
            this.page = new TestPage();
        }

        [BeforeScenario]
        [Obsolete]
        public void BeforeScenario()
        {
            var scenarioInfo = ScenarioContext.Current.ScenarioInfo;
            if (!scenarioInfo.Tags.Contains("CROSSBROWSER") && !this.crossBrowserTestingEnabled)
            {
                variables.browsersArray.Clear();
                variables.browsersArray.Add("CHROME");
                this.runLocallyFlag = true;
            }
        }

       
        [Given(@"Launch the browser ""([^""]*)""")]
        public void GivenLaunchTheBrowser(string browser)
        {
            management.RunInThreads(variables.browsersArray, (browser) =>
            {
                this._browser = new BrowserEngine(management.selectBrowser(browser))
                     .LaunchBrowser("latest", browser == "SAFARI" ? "macOS 13" : "Windows 10", this.sauceLabsUserName, this.sauceLabsAccessKey, "testbuild", "Title", this.sauceLabsCommandTimeout, runLocallyFlag);
                /*var _driver = this._browser;*/
                variables.driversList.Add(this._browser);
            });
        }

        [When(@"Open the google")]
        public void WhenOpenTheGoogle()
        {
            management.ThreadWrapper((driver) =>{page.VisitPage(driver);});
            log.Info("Open the google");

        }

        [When(@"Input values")]
        public void InputValues()
        {
            management.ThreadWrapper((driver) =>{page.InputValues(driver);});
            log.Info("Input values");
        }

        [When(@"Perform Login")]
        public void Login()
        {
            management.ThreadWrapper((driver) =>{page.ClickSubmit(driver);});
            log.Info("Perform Login");

        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            management.ThreadWrapper( (driver) =>{driver.Close(); });
            log.Info("Close the Browser");
        }

       
    }
}
