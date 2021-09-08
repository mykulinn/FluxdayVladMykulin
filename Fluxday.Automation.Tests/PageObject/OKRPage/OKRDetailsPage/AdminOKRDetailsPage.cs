using OpenQA.Selenium;
using System.Collections.Generic;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.OKRDetailsPage
{
    public class AdminOKRDetailsPage : OKRDetailsPage
    {
        public AdminOKRDetailsPage(IWebDriver driver) : base(driver) { }

        protected IWebElement MenuList
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#drop1"));
            }
        }

        protected IWebElement MenuGearButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".right.options>.dropdown.right"));
            }
        }

        protected IWebElement ApproveButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".okr-approval"));
            }
        }

        protected IReadOnlyCollection<IWebElement> MenuItems
        {
            get
            {
                return Driver.FindElements(By.CssSelector("#drop1>li"));
            }
        }

        public void ApproveButtonClick()
        {
            ApproveButton.Click();
        }

        public GearOptionsComponent MenuGearButtonClick()
        {
            MenuGearButton.Click();
            return new GearOptionsComponent(MenuList);
        }
    }
}
