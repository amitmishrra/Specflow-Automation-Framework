using OpenQA.Selenium;
using Saucelabs;
using System;
using TechTalk.SpecFlow;

namespace SpecSauce.StepDefinitions
{
    [Binding]
    public class NewFeatureWileStepDefinitions
    {

        public IWebDriver driver;
        WebDriverInit webDriverInit = new WebDriverInit();

        [Given(@"Launch the browser ""([^""]*)""")]
        public void GivenLaunchTheBrowser(string cHROME)
        {
            driver = WebDriverInit.GetWebDriver(Drivers.BrowserType.Chrome, "Windows 10", "latest", "Chrome Test");
        }

        [When(@"Open the google")]
        public void WhenOpenTheGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            driver.Quit();
        }
    }
}
