using Drivers.BrowserEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecSauce.Drivers
{
    public static class BrowserExtension
    {
        public static IWebDriver LaunchBrowser(this BrowserEngine browser, string browserVersion, string platform, string username, string accessKey, string build, string name, int commnadTimeout, bool runLocally)
        {
            IWebDriver driver = null; // Declare a new variable

            if (runLocally)
            {
                switch (browser.BrowserType)
                {
                    case BrowserType.Chrome:
                        browser.ChromeOptions.BrowserVersion = browserVersion;
                        browser.ChromeOptions.PlatformName = platform;
                        driver = new ChromeDriver();
                        break;

                    case BrowserType.Edge:
                        browser.EdgeOptions.BrowserVersion = browserVersion;
                        browser.EdgeOptions.PlatformName = platform;
                        driver = new EdgeDriver();
                        break;

                    case BrowserType.Safari:
                        browser.SafariOptions.BrowserVersion = browserVersion;
                        browser.SafariOptions.PlatformName = platform;
                        driver = new SafariDriver();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(browser.BrowserType), browser.BrowserType, null);
                }
            }
            else
            {
                if (browser.BrowserType == BrowserType.Chrome)
                {
                    browser.ChromeOptions.BrowserVersion = browserVersion;
                    browser.ChromeOptions.PlatformName = platform;
                    var sauceOptions = SetSauceLabsOptions(username, accessKey, build, name, commnadTimeout);
                    browser.ChromeOptions.AddAdditionalOption("sauce:options", sauceOptions);
                    driver = new RemoteWebDriver(browser.uri, browser.ChromeOptions);
                }
                else if (browser.BrowserType == BrowserType.Edge)
                {
                    browser.EdgeOptions.BrowserVersion = browserVersion;
                    browser.EdgeOptions.PlatformName = platform;
                    var sauceOptions = SetSauceLabsOptions(username, accessKey, build, name, commnadTimeout);
                    browser.EdgeOptions.AddAdditionalOption("sauce:options", sauceOptions);
                    driver = new RemoteWebDriver(browser.uri, browser.EdgeOptions);
                }
                else if (browser.BrowserType == BrowserType.Safari)
                {
                    browser.SafariOptions.BrowserVersion = browserVersion;
                    browser.SafariOptions.PlatformName = platform;
                    var sauceOptions = SetSauceLabsOptions(username, accessKey, build, name, commnadTimeout);
                    browser.SafariOptions.AddAdditionalOption("sauce:options", sauceOptions);
                    driver = new RemoteWebDriver(browser.uri, browser.SafariOptions);
                }
            }

            browser.IsBrowserLaunched = true;
            return driver; // Return the new variable
        }


        private static Dictionary<string, object> SetSauceLabsOptions(string username, string accessKey, string build, string name, int commnadTimeout)
        {
            return new Dictionary<string, object>
                {
                    { "username", username },
                    { "accessKey", accessKey },
                    { "build", build },
                    { "name", name },
                    { "newCommandTimeout", commnadTimeout }
                };
        }

        public static BrowserEngine Navigate(this BrowserEngine browser, string url)
        {
            if (browser.IsBrowserLaunched)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        browser.WebDriver.Navigate().GoToUrl(url);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            return browser;
        }
    }
}
