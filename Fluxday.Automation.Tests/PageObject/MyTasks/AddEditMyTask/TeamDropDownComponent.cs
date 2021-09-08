using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Fluxday.Automation.Tests.PageObject.MyTasks.AddEditMyTask
{
    public class TeamDropDownComponent : BaseObject.BasePageObject
    {
        public TeamDropDownComponent(IWebDriver driver) : base(driver) { }

        protected IWebElement SearchTeamInputField
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='select2-drop']/div/input"));
            }
        }

        protected IWebElement TeamDropDownItem
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='select2-drop']/ul/li/ul/li/div"));
            }
        }

        public void FindTeam(string teamInputValue)
        {
            SearchTeamInputField.Click();
            SearchTeamInputField.Clear();
            SearchTeamInputField.SendKeys(teamInputValue);
            SearchTeamInputField.SendKeys(Keys.Return);
        }

        public void SelectTeam(string teamInputValue)
        {
            var searchTeamDropDownListItem = new SelectElement(TeamDropDownItem);
            searchTeamDropDownListItem.SelectByText(teamInputValue);
        }
    }
}
