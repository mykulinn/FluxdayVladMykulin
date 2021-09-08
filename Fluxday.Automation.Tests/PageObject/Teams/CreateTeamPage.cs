using Fluxday.Automation.Tests.PageObject.BaseObject;
using Fluxday.Automation.Tests.PageObject.Models.TeamModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Fluxday.Automation.Tests.PageObject.Teams
{
    public class CreateTeamPage : BasePageObject
    {
        public CreateTeamPage(IWebDriver driver) : base(driver)
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

        protected IWebElement NameField
        {
            get
            {
                return Driver.FindElement(By.Id("team_name"));
            }
        }

        protected IWebElement CodeField
        {
            get
            {
                return Driver.FindElement(By.Id("team_code"));
            }
        }

        protected IWebElement DescriptionField
        {
            get
            {
                return Driver.FindElement(By.Id("team_description"));
            }
        }

        protected IWebElement SelectDepartmentDropDown
        {
            get
            {
                return Driver.FindElement(By.Id("team_project_id"));
            }
        }

        protected IReadOnlyCollection<IWebElement> TeamLeadsCloseButtonsList
        {
            get
            {
                return Driver.FindElements(By.XPath("//li[@class='select2-search-choice']//a"));
            }
        }

        protected IWebElement SelectTeamLeadsDropDown
        {
            get
            {
                return Driver.FindElement(By.Id("team_team_lead_ids"));
            }
        }

        public bool IsDisplayed()
        {
            return DriverWait.Until(d => NameField.Displayed);
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        public void ClearTeamLeadsField()
        {
            foreach (var teamLeadsCloseButton in TeamLeadsCloseButtonsList)
            {
                teamLeadsCloseButton.Click();
                DriverWait.Until(SeleniumExtras.WaitHelpers
                                               .ExpectedConditions
                                               .StalenessOf(teamLeadsCloseButton));
            }
        }

        public void SelectDepartment(string department)
        {
            var selectElement = new SelectElement(SelectDepartmentDropDown);
            selectElement.SelectByText(department);
        }

        public void SelectTeamLeads(List<string> teamLeads)
        {
            var selectElement = new SelectElement(SelectTeamLeadsDropDown);
            foreach (var teamLead in teamLeads)
            {
                selectElement.SelectByText(teamLead);
            }
        }

        public void FillTeamForm(TeamFormModel teamFormModel)
        {
            FillInInput(NameField, teamFormModel.Name);
            FillInInput(CodeField, teamFormModel.Code);
            FillInInput(DescriptionField, teamFormModel.Description);
            SelectDepartment(teamFormModel.Department);
            ClearTeamLeadsField();
            SelectTeamLeads(teamFormModel.TeamLeads);
        }

        public void CreateDepartment(TeamFormModel teamFormModel)
        {
            FillTeamForm(teamFormModel);
            ClickSaveButton();
        }
    }
}