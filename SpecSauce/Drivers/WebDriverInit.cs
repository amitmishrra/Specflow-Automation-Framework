using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;

namespace SpecSauce.Drivers
{
    public class WebDriverInit
    {
        public IWebDriver GetWebDriver(BrowserType browserType, string platform, string version, string name, bool useRemoteWebDriver)
        {
            if (useRemoteWebDriver)
            {
                var browserOptions = GetBrowserOptions(browserType);
                browserOptions.PlatformName = platform;
                browserOptions.BrowserVersion = version;

                var sauceOptions = new Dictionary<string, object>
                {
                    { "username", "oauth-nimbusthenewt-f8984" },
                    { "accessKey", "ca11bdb5-a575-4127-9115-c0c9b82b0058" },
                    { "build", "ParallelExection" },
                    { "name", name },
                };

                browserOptions.AddAdditionalChromeOption("sauce:options", sauceOptions);

                var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                var driver = new RemoteWebDriver(uri, browserOptions);

                return driver;
            }
            else
            {
                var localDriver = GetLocalWebDriver(browserType);
                localDriver.Manage().Window.Maximize();
                return localDriver;
            }
        }

        public dynamic GetBrowserOptions(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    return chromeOptions;
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

        private IWebDriver GetLocalWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                case BrowserType.Edge:
                    return new EdgeDriver();
                case BrowserType.Safari:
                    return new SafariDriver();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
    }

}
