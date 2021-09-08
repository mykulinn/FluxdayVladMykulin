using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using Fluxday.Automation.Tests.PageObject.Models.UserModels;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class ChangePasswordUserPage : BasePageObject
    {
        public ChangePasswordUserPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }

        public SaveCancelButtonsComponent SaveCancelButtonsComponent
        {
            get
            {
                return new SaveCancelButtonsComponent(ParentElement, DriverWait);
            }
        }

        protected IWebElement ParentElement
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".pane3"));
            }
        }

        public void FillPasswordAndConfirmPasswordInUserForm(UserModelForEdit userModel)
        {
            PasswordInfoComponent passwordInfoComponent = new PasswordInfoComponent(ParentElement);
            passwordInfoComponent.FillInPassword(userModel.Password);
            passwordInfoComponent.FillInConfirmPassword(userModel.ConfirmPassword);
        }
    }
}