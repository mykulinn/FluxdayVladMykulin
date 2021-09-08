using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Fluxday.Automation.Tests.Scenarios.DriverSet
{
    public static class BrowserDriver
    {
        private static IWebDriver browser;
        private static WebDriverWait browserWait;

        public static IWebDriver Browser
        {
            get
            {
                if (browser == null)
                {
                    throw new NullReferenceException("The IWebDriver browser instance was not initialized."
                        + " You should first call the method StartBrowser().");
                }
                return browser;
            }
            private set
            {
                browser = value;
            }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (browserWait == null
                       || browser == null)
                {
                    throw new NullReferenceException("The IWebDriver browser instance or WebDriverWait browserWait instance was not initialized."
                        + " You should first call the method StartBrowser().");
                }
                return browserWait;
            }
            private set
            {
                browserWait = value;
            }
        }

        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Chrome, int defaultTimeOutSec = 5)
        {
            switch (browserType)
            {
                case BrowserTypes.Firefox:
                    Browser = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case BrowserTypes.InternetExplorer:
                    Browser = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                default:
                    Browser = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
            }
            Browser.Manage().Window.Maximize();
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOutSec));
        }

        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }
    }
}
