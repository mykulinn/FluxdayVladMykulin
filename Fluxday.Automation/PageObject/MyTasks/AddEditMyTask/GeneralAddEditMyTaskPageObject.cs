using OpenQA.Selenium;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium.Support.UI;

namespace Fluxday.Automation.Tests.PageObject.MyTasks.AddEditMyTask
{
    public class GeneralAddEditMyTaskPageObject : BasePageObject
    {
        public GeneralAddEditMyTaskPageObject(IWebDriver driver) : base(driver) { }

       

        protected virtual IWebElement CancelButton
        {
            get;
        }

        protected virtual IWebElement SaveChangesButton
        {
            get;
        }

        protected IWebElement TitleField
        {
            get
            {
                return Driver.FindElement(By.Id("task_name"));
            }
        }

        protected IWebElement CreateTaskButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//input[@class = 'button alert right']"));
            }
        }

        protected IWebElement DescriptionField
        {
            get
            {
                return Driver.FindElement(By.Id("task_description"));
            }
        }

        protected IWebElement StartDateField
        {
            get
            {
                return Driver.FindElement(By.Id("task_start_date"));
            }
        }

        protected IWebElement EndDateField
        {
            get
            {
                return Driver.FindElement(By.Id("task_end_date"));
            }
        }

        protected IWebElement TeamField
        {
            get
            {
                return Driver.FindElement(By.Id("s2id_task_team_id"));
            }
        }

        protected IWebElement PriorityField
        {
            get
            {
                return Driver.FindElement(By.Id("s2id_task_priority"));
            }
        }

        protected IWebElement SearchPriorityFieldInput
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='select2-drop']/div/input"));
            }
        }

        public void SetTitle(string titleValue)
        {
            DriverWait.Until(ExpectedConditions.ElementExists(By.Id("task_name")));
            FillInInput(TitleField, titleValue);
        }

        public void SetDescription(string descriptionValue)
        {
            FillInInput(DescriptionField, descriptionValue);
        }

        public void SetStartDate(string startDateValue)
        {
            FillInInput(StartDateField, startDateValue);
        }

        public void SetEndDate(string endDateValue)
        {
            FillInInput(EndDateField, endDateValue);
        }

        public void SetPriority(string priorityInputValue)
        {
            PriorityField.Click();
            SearchPriorityFieldInput.Clear();
            SearchPriorityFieldInput.SendKeys(priorityInputValue);
            SearchPriorityFieldInput.SendKeys(Keys.Return);
        }

        public void ClickOnSaveChangesButton()
        {
            SaveChangesButton.Click();
        }

        public void ClickOnCancelButton()
        {
            CancelButton.Click();
        }

        public void ClickCreateTaskButton()
        {
            CreateTaskButton.Click();
        }

        public TeamDropDownComponent ClickOnTeamField()
        {
            TeamField.Click();
            return new TeamDropDownComponent(Driver);
        }
    }
}
