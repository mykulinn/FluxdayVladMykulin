using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class PasswordInfoComponent
    {
        private IWebElement ParentElement { get; }

        public PasswordInfoComponent(IWebElement parentElement)
        {
            ParentElement = parentElement;
        }

        protected IWebElement PasswordField
        {
            get
            {
                return ParentElement.FindElement(By.CssSelector("#user_password"));
            }
        }
        
        protected IWebElement ConfirmPasswordField
        {
            get
            {
                return ParentElement.FindElement(By.CssSelector("#user_password_confirmation"));
            }
        }

        public void FillInPassword(string password)
        {
            PasswordField.FillInInput(password);
        }

        public void FillInConfirmPassword(string confirmPassword)
        {
            ConfirmPasswordField.FillInInput(confirmPassword);
        }
    }
}