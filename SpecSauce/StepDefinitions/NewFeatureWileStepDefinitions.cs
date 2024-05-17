using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Saucelabs;
using SpecSauce.Drivers;
using System;
using TechTalk.SpecFlow;
using WebDriverInit = Saucelabs.WebDriverInit;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace SpecSauce.StepDefinitions
{
    [Binding]
    [TestFixture]
    public class NewFeatureWileStepDefinitions
    {

        public IWebDriver driver;
        WebDriverInit webDriverInit = new WebDriverInit();
        private readonly ILog logger = LogManager.GetLogger(typeof(NewFeatureWileStepDefinitions));

        [Given(@"Launch the browser ""([^""]*)""")]
        
        public void GivenLaunchTheBrowser(string browser)
        {
            driver = WebDriverInit.GetWebDriver(selectBrowser(browser), "Windows 10", "latest", browser);
            logger.Info("This is test");
        }

        [When(@"Open the google")]
        public void WhenOpenTheGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            logger.Info("This is test 2");

        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            logger.Info("This is test 3");
            driver.Quit();
        }

        public BrowserType selectBrowser(string Browser)
        {
            if(Browser == "CHROME")
            {
                return BrowserType.Chrome;
            }
            else if(Browser == "EDGE")
            {
                return BrowserType.Edge;
            }else if(Browser == "FIREFOX")
            {
                return BrowserType.Firefox;
            }else if(Browser == "SAFARI")
            {
                return BrowserType.Safari;
            }
            else
            {
                return BrowserType.Chrome;
            }
        }
    }
}
