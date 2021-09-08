using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using Fluxday.Automation.Tests.PageObject.Models.UserModels;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class AddUserPage : BasePageObject
    {
        public AddUserPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
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

        protected IWebElement NickNameField
        {
            get
            {
                return ParentElement.FindElement(By.CssSelector("#user_nickname"));
            }
        }

        public void FillInNickName(string nickName)
        {
            NickNameField.FillInInput(nickName);
        }

        public void SetUserInfo(UserModelForEdit userModel)
        {
            AdminUserInfoComponent adminUserInfoComponent = new AdminUserInfoComponent(ParentElement, DriverWait);
            PasswordInfoComponent passwordInfoComponent = new PasswordInfoComponent(ParentElement);
            ManagersListComponent managersListComponent = new ManagersListComponent(ParentElement);
            adminUserInfoComponent.FillInName(userModel.Name);
            FillInNickName(userModel.NickName);
            adminUserInfoComponent.FillInEmail(userModel.Email);
            adminUserInfoComponent.FillInEmployeeCode(userModel.EmployeeCode);
            adminUserInfoComponent.FillInRole(userModel.Role);
            passwordInfoComponent.FillInPassword(userModel.Password);
            passwordInfoComponent.FillInConfirmPassword(userModel.ConfirmPassword);
            adminUserInfoComponent.ClickOnManagersField();
            managersListComponent.FillInManager(userModel.Managers);
        }
    }
}