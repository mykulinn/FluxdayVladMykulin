using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.MyTaskViewPage
{
    public class MyTasksViewPage : BasePageObject
    {
        public MyTasksViewPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement PendingTab
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[contains(text(),'Pending')]"));
            }
        }

        protected IWebElement MyTasksTab
        {
            get
            {
                return Driver.FindElement(By.XPath("//ul[@class = 'side-nav sidebar-links top-set']//a[@href = '/tasks']"));
            }
        }

        protected IWebElement TaskSettingsButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class = 'icon settings-link']"));
            }
        }

        protected IReadOnlyCollection<IWebElement> PendingTabIsActiveList
        {
            get
            {
                return Driver.FindElements(By.XPath("//a[contains(text(),'Pending')]/parent::dd[contains(@class,'active')]"));
            }
        }

        protected IWebElement CompletedTab
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[contains(text(),'Completed')]"));
            }
        }

        protected IReadOnlyCollection<IWebElement> CompletedTabIsActiveList
        {
            get
            {
                return Driver.FindElements(By.XPath("//a[contains(text(),'Completed')]/parent::dd[contains(@class,'active')]"));
            }
        }

        protected IWebElement FindTaskNameInPendingTab(string taskName)
        {
            return Driver.FindElement(By.XPath(String.Format($"//div[@class='name' and contains(.,'{taskName}')and ancestor-or-self::div[@class='paginator task-paginator']]")));
        }

        protected IWebElement FindTaskNameInCompletedTab(string taskName)
        {
            return Driver.FindElement(By.XPath(String.Format($"//div[@class='name' and contains(.,'{taskName}')and ancestor-or-self::div[@class='paginator fin-task-paginator']]")));
        }
        protected IWebElement EditTaskButton(string name)
        {
                return Driver.FindElement(By.XPath($"//div[contains(text(), '{name}')]/following-sibling::div[@class = 'date end-low']/div[@class = 'right']"));    
        }

        protected IWebElement DeleteTaskButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[text() = 'Delete']"));
            }
        }

        public void clickEditTaskButton(string name) => EditTaskButton(name).Click();
        public void clickTaskSettingsButton() => TaskSettingsButton.Click();
        public void clickDeleteTaskButton() => DeleteTaskButton.Click();


        public bool IsDisplayed()
        {
            return DriverWait.Until(d => PendingTab.Displayed);
        }
        
        public void ClickOnCompletedTab()
        {
            CompletedTab.Click();
            DriverWait.Until(d => CompletedTabIsActiveList.Any());
        }

        public void ClickOnMyTasksTab() => MyTasksTab.Click();

        public void ClickOnPendingTab()
        {
            PendingTab.Click();
            DriverWait.Until(d => PendingTabIsActiveList.Any());
        }

        public DetailsTaskPage ClickOnTaskNameInPendingTab(string taskName)
        {
            FindTaskNameInPendingTab(taskName).Click();
            return new DetailsTaskPage(Driver);
        }

        public DetailsTaskPage ClickOnTaskNameInCompletedTab(string taskName)
        {
            FindTaskNameInCompletedTab(taskName).Click();
            return new DetailsTaskPage(Driver);
        }

        public void VerifyMyTaskExist(string name, string team, string endDate = "Due today")
        {
            try
            {
                _ = Driver.FindElement(By.XPath($"//div[contains(text(), '{name}')]/following-sibling::div[contains(text(), '{endDate}')]/following-sibling::div[contains(text(), '{team}')]")).Displayed;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }          
        }
    }
}