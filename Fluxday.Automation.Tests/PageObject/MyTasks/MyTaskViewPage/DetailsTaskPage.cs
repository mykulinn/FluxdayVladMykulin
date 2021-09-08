using Fluxday.Automation.Tests.PageObject.BaseObject;
using Fluxday.Automation.Tests.PageObject.MyTasks.AddEditMyTask;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.MyTaskViewPage
{
    public class DetailsTaskPage : BasePageObject
    {
        public DetailsTaskPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement NameOfTask
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='task-name']"));
            }
        }

        protected IWebElement DescriptionOfTask
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='descr']"));
            }
        }

        protected IWebElement PriorityOfTask
        {
            get
            {
                return Driver.FindElement(By.XPath("//span[contains(@class,'task-priority')]"));
            }
        }

        protected IWebElement AddSubTaskButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[text()='Add subtask']]"));
            }
        }

        protected IWebElement StartDate
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='info' and contains(.,'Start date:')]/child::em[contains(text.,'')][1]"));
            }
        }

        protected IWebElement EndDate
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='info' and contains(.,'End date:')]/child::em[contains(text.,'')][2]"));
            }
        }

        protected IWebElement NameOfTeam
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[contains(@class,'active')]//div[@class='team']"));
            }
        }

        protected IWebElement AddCommentField
        {
            get
            {
                return Driver.FindElement(By.XPath("//input[@id='comment_body']"));
            }
        }

        protected IReadOnlyCollection<IWebElement> ListOfComments
        {
            get
            {
                return Driver.FindElements(By.XPath("//div[@class='comment-body']"));
            }
        }

        protected IWebElement SettingsIcon
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='icon settings-link']"));
            }
        }

        protected IReadOnlyCollection<IWebElement> SettingsList
        {
            get
            {
                return Driver.FindElements(By.XPath("//ul[@class='f-dropdown drop-left open']"));
            }
        }

        protected IReadOnlyCollection<IWebElement> PanelsList
        {
            get
            {
                return Driver.FindElements(By.XPath("//div[contains(@id,'pane')]"));
            }
        }

        protected IWebElement EditTaskButton
        {
            get
            {
                return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                      .ExpectedConditions
                                                      .ElementIsVisible(By.XPath(String.Format("//a[text()='Edit' and ancestor-or-self:: ul[contains(@id,'drop')]]"))));
            }
        }

        protected IWebElement DeleteTaskButton
        {
            get
            {
                return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                      .ExpectedConditions
                                                      .ElementIsVisible(By.XPath(String.Format("//a[text()='Delete' and ancestor-or-self:: ul[contains(@id,'drop')]]"))));
            }
        }

        protected IWebElement StatusOfTaskAlert
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[@class='button alert right status']"));
            }
        }

        protected IWebElement DoneStatusOfTaskButton
        {
            get
            {
                return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                      .ExpectedConditions
                                                      .ElementIsVisible(By.XPath("//button[text()='Done']")));
            }
        }

        protected IWebElement ExpandCommentButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[contains(text(),'comment')]"));
            }
        }

        public bool IsDisplayed()
        {
            return DriverWait.Until(d => NameOfTask.Displayed);
        }

        public string GetNameOfTask()
        {
            return NameOfTask.Text;
        }

        public string GetDescriptionOfTask()
        {
            return DescriptionOfTask.Text;
        }

        public string GetTeamOfTask()
        {
            return NameOfTeam.Text;
        }

        protected string TransformMonthsFromWordToNumber(string date)
        {
            date = date.Trim(new char[] { ',', ' ' }).ToLower();
            if (date.Contains("january"))
            {
                date = date.Replace("january", "01");
            }
            else if (date.Contains("february"))
            {
                date = date.Replace("february", "02");
            }
            else if (date.Contains("march"))
            {
                date = date.Replace("march", "03");
            }
            else if (date.Contains("april"))
            {
                date = date.Replace("april", "04");
            }
            else if (date.Contains("may"))
            {
                date = date.Replace("may", "05");
            }
            else if (date.Contains("june"))
            {
                date = date.Replace("june", "06");
            }
            else if (date.Contains("july"))
            {
                date = date.Replace("july", "07");
            }
            else if (date.Contains("august"))
            {
                date = date.Replace("august", "08");
            }
            else if (date.Contains("september"))
            {
                date = date.Replace("september", "09");
            }
            else if (date.Contains("october"))
            {
                date = date.Replace("october", "10");
            }
            else if (date.Contains("november"))
            {
                date = date.Replace("november", "11");
            }
            else if (date.Contains("december"))
            {
                date = date.Replace("december", "12");
            }
            return date;
        }

        public string GetStartDate()
        {
            return TransformMonthsFromWordToNumber(StartDate.Text);
        }

        public string GetEndDate()
        {
            return TransformMonthsFromWordToNumber(EndDate.Text);
        }

        public string GetPriorityOfTask()
        {
            return PriorityOfTask.Text;
        }

        public void MoveTaskToDone()
        {
            StatusOfTaskAlert.Click();
            DoneStatusOfTaskButton.Click();
        }

        public void AddComment(string text)
        {
            AddCommentField.Click();
            AddCommentField.Clear();
            AddCommentField.SendKeys(text);
            AddCommentField.SendKeys(Keys.Enter);
        }

        public void ExpandComments()
        {
            ExpandCommentButton.Click();
            DriverWait.Until(d => ListOfComments.Any());
        }

        public List<string> GetListOfComments()
        {
            var commentsList = new List<string>();
            foreach (var comment in ListOfComments)
            {
                commentsList.Add(comment.Text);
            }
            return commentsList;
        }

        public GeneralAddEditMyTaskPageObject AddSubtask()
        {
            AddSubTaskButton.Click();
            return new GeneralAddEditMyTaskPageObject(Driver);
        }

        public void ClickOnEditTaskMenuItem()
        {
            SettingsIcon.Click();
            EditTaskButton.Click();
            DriverWait.Until(d => !SettingsList.Any()
                                  && PanelsList.Any());
        }

        public void ClickOnDeleteTaskMenuItem()
        {
            SettingsIcon.Click();
            DeleteTaskButton.Click();
            DriverWait.Until(d => !SettingsList.Any()
                                  && PanelsList.Any());
        }
    }
}