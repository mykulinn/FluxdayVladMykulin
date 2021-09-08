using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using Fluxday.Automation.Tests.PageObject.Models.UserModels;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class EditUserPage : BasePageObject
    {
        public EditUserPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }

        public SaveCancelButtonsComponent SaveCancelButtonsComponent
        {
            get
            {
                return new SaveCancelButtonsComponent(ParentElement, DriverWait);
            }
        }

        public AdminUserInfoComponent AdminUserInfoComponent
        {
            get
            {
                return new AdminUserInfoComponent(ParentElement, DriverWait);
            }
        }

        public ManagersListComponent ManagersListComponent
        {
            get
            {
                return new ManagersListComponent(ParentElement);
            }
        }

        protected IWebElement ParentElement
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".pane3"));
            }
        }

        public void SetUserInfo(UserModelForEdit userModel)
        {
            AdminUserInfoComponent adminUserInfoComponent = AdminUserInfoComponent;
            ManagersListComponent managersListComponent = ManagersListComponent;
            adminUserInfoComponent.FillInName(userModel.Name);
            adminUserInfoComponent.FillInEmail(userModel.Email);
            adminUserInfoComponent.FillInEmployeeCode(userModel.EmployeeCode);
            adminUserInfoComponent.FillInRole(userModel.Role);
            adminUserInfoComponent.ClickOnManagersField();
            managersListComponent.FillInManager(userModel.Managers);
        }
    }
}