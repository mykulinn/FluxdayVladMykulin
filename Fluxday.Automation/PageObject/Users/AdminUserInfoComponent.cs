using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class AdminUserInfoComponent
    {
        private IWebElement ParentElement { get; }
        private WebDriverWait DriverWait { get; }

        public AdminUserInfoComponent(IWebElement parentElement,
                                      WebDriverWait driverWait)
        {
            ParentElement = parentElement;
            DriverWait = driverWait;
        }

        protected IWebElement UserNameField
        {
            get
            {
                return DriverWait.Until(d => ParentElement.FindElement(By.CssSelector("#user_name")));
            }
        }

        protected IWebElement EmailField
        {
            get
            {
                return ParentElement.FindElement(By.CssSelector("#user_email"));
            }
        }

        protected IWebElement EmployeeCodeField
        {
            get
            {
                return ParentElement.FindElement(By.CssSelector("#user_employee_code"));
            }
        }

        protected IWebElement RoleField
        {
            get
            {
                return ParentElement.FindElement(By.CssSelector("#s2id_user_role"));
            }
        }

        protected IWebElement RoleFieldInput
        {
            get
            {
                return DriverWait.Until(d => d.FindElement(By.CssSelector("#select2-drop > div > input")));
            }
        }

        protected IWebElement ManagersField
        {
            get
            {
                return ParentElement.FindElement(By.CssSelector("li.select2-search-field"));
            }
        }

        public void FillInName(string name)
        {
            UserNameField.FillInInput(name);
        }

        public void FillInEmail(string email)
        {
            EmailField.FillInInput(email);
        }

        public void FillInEmployeeCode(string employeeCode)
        {
            EmployeeCodeField.FillInInput(employeeCode);
        }

        public void FillInRole(string role)
        {
            RoleField.Click();
            RoleFieldInput.SendKeys(role);
            RoleFieldInput.SendKeys(Keys.Return);
        }

        public void ClickOnManagersField()
        {
            ManagersField.Click();
        }
    }
}