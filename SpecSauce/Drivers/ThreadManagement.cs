using Drivers.BrowserEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SpecSauce.Support;
using System;
using System.Threading.Tasks;

namespace SpecSauce.Drivers
{
    public class ThreadManagement
    {
        public BrowserEngine _browser;
        CommonVariables variables;
         
        public ThreadManagement(CommonVariables variables)
        {
            this.variables = variables;
        }


        public void RunInThreads(List<String> browserNames, Action<String> callback)
        {
            Parallel.ForEach(browserNames, browserName =>
            {
                callback(browserName);
            });
        }
        public BrowserType selectBrowser(string Browser)
        {
            if (Browser == "CHROME")
            {
                return BrowserType.Chrome;
            }
            else if (Browser == "EDGE")
            {
                return BrowserType.Edge;
            }
            else if (Browser == "FIREFOX")
            {
                return BrowserType.Firefox;
            }
            else if (Browser == "SAFARI")
            {
                return BrowserType.Safari;
            }
            else
            {
                return BrowserType.Chrome;
            }
        }

        public void ThreadWrapper(Action<IWebDriver> callback)
        {
            Parallel.ForEach(variables.driversList, driver =>
            {
                string browserName = ((IHasCapabilities)driver).Capabilities.GetCapability("browserName").ToString();

                try
                {
                    callback(driver);
                }
                catch (Exception e)
                {
                    driver.Close();
                    Console.WriteLine($"Error occurred in browser '{browserName}': {e.Message}");
                }
            });
        }
    }
   
}
