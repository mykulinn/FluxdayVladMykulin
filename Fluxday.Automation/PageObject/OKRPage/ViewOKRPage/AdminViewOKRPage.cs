using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.ViewOKRPage
{
    public class AdminViewOKRPage: ViewOKRPage
    {
        public AdminViewOKRPage(IWebDriver driver) : base(driver) { }

        protected IWebElement TeamDropDown
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".select2-drop"));
            }
        }

        protected IWebElement DropDownVisibleField
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#s2id_okr_user_id"));
            }
        }

        public DropDownComponent TeamDropDownClick()
        {
            DropDownVisibleField.Click();
            return new DropDownComponent(TeamDropDown);
        }
    }
}
