using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using SpecSauce.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucelabs
{


    public class WebDriverInit
    {
        public static IWebDriver GetWebDriver(BrowserType browserType, string platform, string version, string name)
        {

            var browserOptions = GetBrowserOptions(browserType);
            //var browserOptions = new ChromeOptions();
            browserOptions.PlatformName = platform;
            browserOptions.BrowserVersion = version;
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("username", "oauth-nimbusthenewt-f8984");
            sauceOptions.Add("accessKey", "ca11bdb5-a575-4127-9115-c0c9b82b0058");
            sauceOptions.Add("build", "ParallelExecution");
            sauceOptions.Add("name", name);
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
            var driver = new EdgeDriver();

           /* driver.Navigate().GoToUrl("https://www.selenium.dev/");*/

            return driver;
        }

        public static dynamic GetBrowserOptions(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeOptions();
                case BrowserType.Firefox:
                    return new FirefoxOptions();
                case BrowserType.Edge:
                    return new EdgeOptions();
                case BrowserType.Safari:
                    return new SafariOptions();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
    }
}