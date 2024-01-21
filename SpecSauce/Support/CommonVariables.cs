using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecSauce.Support
{
    public class CommonVariables
    {
        public List<string> browsersArray = new List<string> { "CHROME", "EDGE" };
        public List<IWebDriver> driversList = new List<IWebDriver>();
    }
}
