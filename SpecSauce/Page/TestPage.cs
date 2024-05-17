using OpenQA.Selenium;
using SpecSauce.Drivers;

namespace SpecSauce.Page
{
    public class TestPage
    {
        private readonly DriverHandler driverHandler;
        private IWebDriver driver;

        public TestPage(DriverHandler driverHandler)
        {
            this.driverHandler = driverHandler;
            this.driver = driverHandler.driver;
        }

        public void TestMethod()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Page title  : " + driver.Title);
            driver.Quit();
        }
    }
}
