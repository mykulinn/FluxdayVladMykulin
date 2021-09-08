using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.BaseObject
{
    public class BasePageObject
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait DriverWait;

        public BasePageObject(IWebDriver driver, WebDriverWait driverWait)
        {
            Driver = driver;
            DriverWait = driverWait;
        }

        public BasePageObject(IWebDriver driver)
        {
            Driver = driver;
            DriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        protected IWebElement DriverFindElementWithWait(By by)
        {
            return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                  .ExpectedConditions
                                                  .ElementToBeClickable(by));
        }
        
        protected IReadOnlyCollection<IWebElement> DriverFindElementsWithWait(By by)
        {
            return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                  .ExpectedConditions
                                                  .PresenceOfAllElementsLocatedBy(by));
        }

        protected bool IsElementPresent(By by)
        {
            return DriverWait.Until(Driver => Driver.FindElements(by).Any());
        }

        protected void FillInInput(IWebElement iWebElement, string inputText)
        {
            iWebElement.Click();
            iWebElement.Clear();
            iWebElement.SendKeys(inputText);
        }

        public void AcceptAllert()
        {
            Driver.SwitchTo()
                  .Alert()
                  .Accept();
        }

        public void DismissAllert()
        {
            Driver.SwitchTo()
                  .Alert()
                  .Dismiss();
        }
    }
}