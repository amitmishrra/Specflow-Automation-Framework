namespace Drivers.BrowserEngine
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Safari;
    using OpenQA.Selenium.Support.UI;
    using SpecSauce.Drivers;

    /// <summary>
    /// Class for BrowserEngine.
    /// </summary>
    public class BrowserEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserEngine"/> class.
        /// </summary>
        public BrowserEngine(BrowserType browserType)
        {
            this.ChromeOptions = new ChromeOptions();
            this.FireFoxProfile = new FirefoxProfile();
            this.FirefoxOptions = new FirefoxOptions();
            this.EdgeOptions = new EdgeOptions();
            this.SafariOptions = new SafariOptions();
            this.BrowserType = browserType;
        }

        /// <summary>
        /// Gets or sets the web driver.
        /// </summary>
        /// <value>
        /// The web driver.
        /// </value>
        public IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Gets or sets the wait time.
        /// </summary>
        /// <value>
        /// The wait time.
        /// </value>
        public WebDriverWait WaitTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is browser launched.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is browser launched; otherwise, <c>false</c>.
        /// </value>
        public bool IsBrowserLaunched { get; set; }

        /// <summary>
        /// Gets or sets the type of the browser.
        /// </summary>
        /// <value>
        /// The type of the browser.
        /// </value>
        public BrowserType BrowserType { get; set; }

        /// <summary>
        /// Gets or sets the chrome options.
        /// </summary>
        /// <value>
        /// The chrome options.
        /// </value>
        public ChromeOptions ChromeOptions { get; set; }

        /// <summary>
        /// Gets or sets the firefox options.
        /// </summary>
        /// <value>
        /// The firefox options.
        /// </value>
        public FirefoxOptions FirefoxOptions { get; set; }

        /// <summary>
        /// Gets or sets the fire fox profile.
        /// </summary>
        /// <value>
        /// The fire fox profile.
        /// </value>
        public FirefoxProfile FireFoxProfile { get; set; }

        /// <summary>
        /// Gets or sets the download path.
        /// </summary>
        /// <value>
        /// The download path.
        /// </value>
        public string DownloadPath { get; set; }

        /// <summary>
        /// Gets or sets the Edge options.
        /// </summary>
        /// <value>
        /// The Edge options.
        /// </value>
        public EdgeOptions EdgeOptions { get; set; }

        /// <summary>
        /// Gets or sets the Safari options.
        /// </summary>
        /// <value>
        /// The Safari options.
        /// </value>
        public SafariOptions SafariOptions { get; set; }


        /// <summary>
        /// Gets the value of URI
        /// </summary>
        /// <value>
        /// Saucelab URI
        /// </value>
        public Uri uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");

        public List<IWebDriver> driversList = new List<IWebDriver>();


    }
}