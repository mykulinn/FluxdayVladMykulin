using OpenQA.Selenium;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium.Support.UI;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class DetailsUserPage : BasePageObject
    {
        public DetailsUserPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }

        protected IWebElement MenuGearButton
        {
            get
            {
                return DriverFindElementWithWait(By.CssSelector("div.right.options"));
            }
        }

        protected IWebElement MenuItemEdit
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='drop1']/li/a[contains(text(),'Edit')]"));
            }
        }

        protected IWebElement MenuItemChangePassword
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='drop1']/li/a[contains(text(),'Change password')]"));
            }
        }

        protected IWebElement MenuItemDelete
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='drop1']/li/a[contains(text(),'Delete')]"));
            }
        }

        protected IWebElement UserName
        {
            get
            {
                return DriverFindElementWithWait(By.XPath("//*[@id='pane3']/div/div[1]/div[4]/div"));
            }
        }

        protected IWebElement UserNickName
        {
            get
            {
                return DriverFindElementWithWait(By.CssSelector(".pane3 .nickname"));
            }
        }

        protected IWebElement UserEmail
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='pane3']/div/div[1]/div[5]/a"));
            }
        }

        protected IWebElement UserEmployeeCode
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='pane3']/div/div[1]/div[1]/strong"));
            }
        }

        protected IWebElement UserManagers
        {
            get
            {
                return DriverFindElementWithWait(By.XPath("//*[@id='pane3']/div/div[1]/div[6]"));
            }
        }

        // The UserName text parameter returns a string consisting of the user's name and nickname,
        // like "Employee 1 (emp1)". We have to separate the user name from this string.
        public string GetCurrentUserName()
        {
            return UserName.Text.Replace(UserNickName.Text, "").Trim();
        }

        public string GetCurrentUserEmail()
        {
            return UserEmail.Text;
        }

        public string GetCurrentUserCode()
        {
            return UserEmployeeCode.Text;
        }

        public string GetCurrentUserManager()
        {
            return UserManagers.Text;
        }

        public EditUserPage ClickOnEditMenuItem()
        {
            MenuGearButton.Click();
            MenuItemEdit.Click();
            return new EditUserPage(Driver, DriverWait);
        }

        public ChangePasswordUserPage ClickOnChangePasswordMenuItem()
        {
            MenuGearButton.Click();
            MenuItemChangePassword.Click();
            return new ChangePasswordUserPage(Driver, DriverWait);
        }

        public void ClickOnDeleteMenuItemWithConfirmation()
        {
            MenuGearButton.Click();
            MenuItemDelete.Click();
            AcceptAllert();
        }
    }
}