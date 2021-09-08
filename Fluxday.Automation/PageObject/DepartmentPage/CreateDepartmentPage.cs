using Fluxday.Automation.Tests.PageObject.Models.DepartmentModels;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Fluxday.Automation.Tests.PageObject.DepartmentPage
{
    public class CreateDeparmentPage : BasePageObject
    {
        public CreateDeparmentPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement CancelButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[@class='btn cancel-btn']"));
            }
        }

        protected IWebElement SaveButton
        {
            get
            {
                return Driver.FindElement(By.Name("commit"));
            }
        }

        protected IWebElement TitleField
        {
            get
            {
                return Driver.FindElement(By.Id("project_name"));
            }
        }

        protected IWebElement CodeField
        {
            get
            {
                return Driver.FindElement(By.Id("project_code"));
            }
        }

        protected IWebElement UrlField
        {
            get
            {
                return Driver.FindElement(By.Id("project_website"));
            }
        }

        protected IWebElement DescriptionField
        {
            get
            {
                return Driver.FindElement(By.Id("project_description"));
            }
        }

        protected IWebElement SelectManagersUser
        {
            get
            {
                return Driver.FindElement(By.Id("project_user_ids"));
            }
        }

        protected IReadOnlyCollection<IWebElement> ManagersCloseButtonsList
        {
            get
            {
                return Driver.FindElements(By.XPath("//li[@class='select2-search-choice']//a"));
            }
        }

        public bool IsDisplayed()
        {
            return DriverWait.Until(d => TitleField.Displayed);
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        public void ClearManagersField()
        {
            foreach (var managersCloseButton in ManagersCloseButtonsList)
            {
                managersCloseButton.Click();
                DriverWait.Until(SeleniumExtras.WaitHelpers
                                               .ExpectedConditions
                                               .StalenessOf(managersCloseButton));
            }
        }

        public void SelectManagers(List<string> managers)
        {
            var selectElement = new SelectElement(SelectManagersUser);
            foreach (var manager in managers)
            {
                selectElement.SelectByText(manager);
            }
        }

        public void FillDepartmentForm(DepartmentFormModel departmentFormModel)
        {
            FillInInput(TitleField, departmentFormModel.Title);
            FillInInput(CodeField, departmentFormModel.Code);
            FillInInput(UrlField, departmentFormModel.Url);
            FillInInput(DescriptionField, departmentFormModel.Description);
            ClearManagersField();
            SelectManagers(departmentFormModel.Managers);
        }

        public void CreateDepartment(DepartmentFormModel departmentFormModel)
        {
            FillDepartmentForm(departmentFormModel);
            ClickSaveButton();
        }
    }
}