using Drivers.BrowserEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecSauce.Drivers;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]

namespace SpecSauce.StepDefinitions
{
    [Binding]
    public class CrossBrowserPOCSteps
    {

        public BrowserEngine _browser;
        [BeforeScenario]
        [Obsolete]
        public static void BeforeScenario()
        {
            var scenarioInfo = ScenarioContext.Current.ScenarioInfo;

            var tags = scenarioInfo.Tags;
            var browser = scenarioInfo.Arguments["Browser"];

                if (!tags.Contains("CrossBrowser") && browser.ToString() != "CHROME")
                {
                    Console.WriteLine("SKIPPPP");
                    ScenarioContext.Current.Pending();
                }
                else
                {
                    Console.WriteLine("runnnnn Alll");
                }  
        }

       
        [Given(@"Launch the browser ""([^""]*)""")]
        
        public void GivenLaunchTheBrowser(string browser)
        {
            var scenarioInfo = ScenarioContext.Current.ScenarioInfo;
            var tags = scenarioInfo.Tags;
            ThreadManagement management = new ThreadManagement();
            management.RunInThreads(tags, (browser) =>
            {
                /*driver = webdriverinit.GetWebDriver(selectBrowser(browser), "Windows 10", "latest", browser, false);
                WhenOpenTheGoogle();*/
                this._browser = new BrowserEngine(selectBrowser(browser))
                    .LaunchOnSauceLabs("latest", "windows", "oauth-nimbusthenewt-f8984", "ca11bdb5-a575-4127-9115-c0c9b82b0058", "testbuild", "Title", 6000);
               
                
            });
        }

        [When(@"Open the google")]
        public void WhenOpenTheGoogle()
        {
            this._browser.Navigate("https://www.google.com/");
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            this._browser.WebDriver.Close();
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
