using Fluxday.Automation.Tests.PageObject.Models.OKRModels;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.AddNewOKR
{
    public class AddNewOKRPageObject : BaseObject.BasePageObject
    {
        private const string StartDateSelector = "#okr_start_date";
        private const string EndDateSelector = "#okr_end_date";

        public AddNewOKRPageObject(IWebDriver driver) : base(driver) { }

        protected IWebElement CancelButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='new_okr']/div[3]/div[2]/a/span"));
            }
        }

        protected IWebElement SaveButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#pane3 .right>input"));
            }
        }

        protected IWebElement NameInput
        {
            get
            {
                return Driver.FindElement(By.Id("okr_name"));
            }
        }

        protected IWebElement StartDateInput
        {
            get
            {
                return Driver.FindElement(By.Id("okr_start_date"));
            }
        }

        protected IWebElement EndDateInput
        {
            get
            {
                return Driver.FindElement(By.Id("okr_end_date"));
            }
        }

        protected IReadOnlyCollection<IWebElement> AllObjectivesDivs
        {
            get
            {
                return Driver.FindElements(By.CssSelector("#objectives>.nested-fields"));
            }
        }

        protected IWebElement AddNewObjectiveButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#objectives>.links>a"));
            }
        }

        public List<ObjectiveComponent> GetAllObjectives()
        {
            return AllObjectivesDivs.Select(x => new ObjectiveComponent(x))
                                    .ToList();
        }

        public ObjectiveComponent ClickOnAddNewObjectiveButton()
        {
            AddNewObjectiveButton.Click();
            return GetAllObjectives().Last();
        }

        public List<ObjectiveComponent> DeleteObjectiveByIndex(int indexOfObjective)
        {
            var allObjectives = GetAllObjectives();
            if (indexOfObjective >= 0 && indexOfObjective < allObjectives.Count && allObjectives.Count != 0)
            {
                allObjectives[indexOfObjective].ClickOnDeleteObjectiveButton();
                return GetAllObjectives();
            }
            else
            {
                throw new IndexOutOfRangeException($"Index {indexOfObjective} is out of range");
            }
        }

        public void SetOKRByIndexOfObjective(int indexOfObjective,
                                             string nameOKR,
                                             string startDate,
                                             string endDate,
                                             string objectiveName,
                                             string[] keyResultsNames)
        {
            FillInInput(NameInput, nameOKR);
            FillInInput(StartDateInput, startDate);
            FillInInput(EndDateInput, endDate);
            var objectiveComponents = GetAllObjectives();
            objectiveComponents[indexOfObjective].SetObjective(objectiveName, keyResultsNames);
        }

        private void SetDatepicker(string cssSelector, string date)
        {
            (Driver as IJavaScriptExecutor).ExecuteScript(string.Format("$('{0}').attr('value','{1}')", cssSelector, date));
        }

        public void SetOKR(OKRModel okrModel)
        {
            DeleteAllObjectives();
            FillInInput(NameInput, okrModel.Name);
            if (okrModel.StartDate != null)
            {
                SetDatepicker(StartDateSelector, okrModel.StartDate);
            }
            if (okrModel.EndDate != null)
            {
                SetDatepicker(EndDateSelector, okrModel.EndDate);
            }
            okrModel.ObjectivesList
                    .ForEach(x => ClickOnAddNewObjectiveButton()
                    .SetNewObjectiveWithKeyResults(x.Name, x.OKRList));
            SaveButtonClick();
        }

        public void DeleteAllObjectives()
        {
            GetAllObjectives().ForEach(x => x.ClickOnDeleteObjectiveButton());
        }

        public void CancelButtonClick()
        {
            CancelButton.Click();
        }

        public void SaveButtonClick()
        {
            SaveButton.Click();
        }
    }
}
