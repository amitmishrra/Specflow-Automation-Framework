using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecSauce.Drivers;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]

namespace SpecSauce.StepDefinitions
{
    [Binding]
    public class NewFeatureWileStepDefinitions
    {
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

        public IWebDriver driver;
        WebDriverInit webdriverinit = new WebDriverInit();

       
        [Given(@"Launch the browser ""([^""]*)""")]
        
        public void GivenLaunchTheBrowser(string browser)
        {
            var scenarioInfo = ScenarioContext.Current.ScenarioInfo;
            var tags = scenarioInfo.Tags;
            ThreadManagement management = new ThreadManagement();
            management.RunInThreads(tags, (browser) =>
            {
                driver = webdriverinit.GetWebDriver(selectBrowser(browser), "Windows 10", "latest", browser, false);
                WhenOpenTheGoogle();
            });
        }

        [When(@"Open the google")]
        public void WhenOpenTheGoogle()
        {
           driver.Navigate().GoToUrl("https://www.google.com");
           Console.WriteLine(driver.Title + " : LAUNCHED IN : " );
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
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
