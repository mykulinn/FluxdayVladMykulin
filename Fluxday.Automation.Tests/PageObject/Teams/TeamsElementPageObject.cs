using Fluxday.Automation.Tests.PageObject.BaseObject;
using Fluxday.Automation.Tests.PageObject.MyTasks.AddEditMyTask;
using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject.Teams
{
    public class TeamsElementPageObject : BasePageObject
    {
        private IWebElement webElementFromParent { get; }

        public TeamsElementPageObject(IWebDriver webDriver, IWebElement webElementFromParent) : base(webDriver)
        {
           this.webElementFromParent = webElementFromParent;
        }

        protected IWebElement AddTaskButton
        {
            get
            {
                return webElementFromParent.FindElement(By.CssSelector(".team-glymplse > .btn"));
            }
        }

        protected IWebElement TeamNameLink
        {
            get
            {
                return webElementFromParent.FindElement(By.CssSelector(".team-name a"));
            }
        }

        protected IWebElement TeamDeparmentLink
        {
            get
            {
                return webElementFromParent.FindElement(By.CssSelector(".team-glymplse > .team-project"));
            }
        }

        public bool IsElementPresentByTeamName(string teamName)
        {
            return TeamNameLink.Text == teamName;
        }

        public AddMyTaskPageObject AddTaskButtonClick()
        {
            AddTaskButton.Click();
            return new AddMyTaskPageObject(Driver);
        }

        public void TeamDetailsClick()
        {
            TeamNameLink.Click();
        }

        public void TeamDepartmentDetailsСlick()
        {
            TeamDeparmentLink.Click();
        }
    }
}