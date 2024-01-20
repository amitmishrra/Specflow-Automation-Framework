using Drivers.BrowserEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;

namespace SpecSauce.Drivers
{
    public class ThreadManagement
    {
        public BrowserEngine _browser;

        public void RunInThreads(string[] browserNames, Action<String> callback)
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

        public void ThreadWrapper(IList<IWebDriver> drivers, Action<IWebDriver> callback)
        {
            Parallel.ForEach(drivers, driver =>
            {
                callback(driver);
            });
        }
    }
   
}
