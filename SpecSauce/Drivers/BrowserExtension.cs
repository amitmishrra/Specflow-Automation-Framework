using Drivers.BrowserEngine;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecSauce.Drivers
{
    public static class BrowserExtension
    {
        public static BrowserEngine LaunchOnSauceLabs(this BrowserEngine browser, string browserVersion, string platform, string username, string accessKey, string build, string name, int commnadTimeout)
        {
            if (browser.BrowserType == BrowserType.Chrome)
            {
                browser.ChromeOptions.BrowserVersion = browserVersion;
                browser.ChromeOptions.PlatformName = platform;
                var sauceOptions = SetSauceLabsOptions(username, accessKey, build, name, commnadTimeout);
                browser.ChromeOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                browser.WebDriver = new RemoteWebDriver(uri, browser.ChromeOptions);

                browser.IsBrowserLaunched = true;
            }
            else if (browser.BrowserType == BrowserType.Edge)
            {
                browser.EdgeOptions.BrowserVersion = browserVersion;
                browser.EdgeOptions.PlatformName = platform;
                var sauceOptions = SetSauceLabsOptions(username, accessKey, build, name, commnadTimeout);
                browser.EdgeOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                browser.WebDriver = new RemoteWebDriver(uri, browser.EdgeOptions);

                browser.IsBrowserLaunched = true;
            }
            else if (browser.BrowserType == BrowserType.Safari)
            {
                browser.SafariOptions.BrowserVersion = browserVersion;
                browser.SafariOptions.PlatformName = platform;
                var sauceOptions = SetSauceLabsOptions(username, accessKey, build, name, commnadTimeout);
                browser.SafariOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                browser.WebDriver = new RemoteWebDriver(uri, browser.SafariOptions);

                browser.IsBrowserLaunched = true;
            }

            return browser;
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
