using OpenQA.Selenium;
using SpecSauce.Drivers;

namespace SpecSauce.Page
{
    public class TestPage
    {
     
        public void VisitPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            Console.WriteLine("Page title  : " + driver.Title);
        }

        public void InputValues(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@id=\"username\"]")).SendKeys("student");
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys("Password123");
        }

        public void ClickSubmit(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@id=\"submit\"]")).Click();
            Console.WriteLine("Logged in Success");
        }
    }
}
