using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Security.Policy;
using OpenQA.Selenium.Safari;

namespace SpecSauce.Drivers
{
    public class DriverHandler
    {
        public IWebDriver driver;
        private readonly Uri gridUrl =  new Uri("http://localhost:4444/wd/hub");


        public IWebDriver RemoteDriverInitializer(string browser)
        {
            switch (browser.ToUpper())
            {
                case "CHROME":
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--start-maximized");
                        driver = new RemoteWebDriver(gridUrl, options);
                        break;
                    }
                case "FIREFOX":
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddArgument("--start-maximized");
                        driver = new RemoteWebDriver(gridUrl, options);
                        break;
                    }
                case "EDGE":
                    {
                        EdgeOptions options = new EdgeOptions();
                        options.AddArgument("--start-maximized");
                        driver = new RemoteWebDriver(gridUrl, options);
                        break;
                    }

                case "SAUCELAB":
                    {
                        var browserOptions = new SafariOptions();
                        browserOptions.PlatformName = "macOS 11.00";
                        browserOptions.BrowserVersion = "latest";
                        var sauceOptions = new Dictionary<string, object>();
                        sauceOptions.Add("username", "oauth-g.krishna-d5186");
                        sauceOptions.Add("accessKey", "d4844ea3-f950-40d7-a088-d5ab9c37b1ed");
                        sauceOptions.Add("build", "selenium-build-3PN5U");
                        sauceOptions.Add("name", "<your test name>");
                        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                        var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                        driver = new RemoteWebDriver(uri, browserOptions);
                        break;
                    }
                default:
                    {
                        driver = new ChromeDriver();
                        break;
                    }
            }

            return driver;
        }


        public void QuitDriver()
        {
            driver?.Quit();
/*            driver = null;*/
        }
    }
}
