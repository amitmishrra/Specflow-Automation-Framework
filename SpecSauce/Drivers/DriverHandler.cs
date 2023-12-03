using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Security.Policy;

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
