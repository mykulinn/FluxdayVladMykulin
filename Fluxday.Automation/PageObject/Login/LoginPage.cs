using OpenQA.Selenium;
using Fluxday.Automation.Tests.PageObject.NavigatePanel;
using Fluxday.Automation.Tests.PageObject.Models.UserModels;
using OpenQA.Selenium.Support.UI;

namespace Fluxday.Automation.Tests.PageObject.Login
{
    public class LoginPage : BaseObject.BasePageObject
    {
        public LoginPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }

        protected IWebElement EmailInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#user_email"));
            }
        }

        protected IWebElement PasswordInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#user_password"));
            }
        }

        protected IWebElement LoginButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".btn-login"));
            }
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void SetEmail(string email)
        {
            FillInInput(EmailInput, email);
        }

        public void SetPassword(string password)
        {
            FillInInput(PasswordInput, password);
        }

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }

        public NavigatePanelPage Login(UserModelForCredentials userModel)
        {
            SetEmail(userModel.Email);
            SetPassword(userModel.Password);
            ClickOnLoginButton();
            return new NavigatePanelPage(Driver, DriverWait);
        }
    }
}
