using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class SaveCancelButtonsComponent
    {
        private IWebElement ParentElement { get; }
        private WebDriverWait DriverWait { get; }

        public SaveCancelButtonsComponent(IWebElement parentElement,
                                          WebDriverWait driverWait)
        {
            ParentElement = parentElement;
            DriverWait = driverWait;
        }

        protected IWebElement SaveButton
        {
            get
            {
                return DriverWait.Until(d => ParentElement.FindElement(By.CssSelector(".button.alert.right")));
            }
        }

        protected IWebElement CancelButton
        {
            get
            {
                return DriverWait.Until(d => ParentElement.FindElement(By.CssSelector(".btn.cancel-btn")));
            }
        }

        public void ClickOnSaveButton()
        {
            SaveButton.Click();
        }

        public void ClickOnCancelButton()
        {
            CancelButton.Click();
        }
    }
}