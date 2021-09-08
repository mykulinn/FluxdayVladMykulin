using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Fluxday.Automation.Tests.PageObject.Teams
{
    public class TeamsPage : BasePageObject
    {
        public TeamsPage(IWebDriver driver) : base(driver) { }

        protected IReadOnlyCollection<IWebElement> AllTeamsElements
        {
            get
            {
                return Driver.FindElements(By.ClassName(".team-card"));
            }
        }

        public List<TeamsElementPageObject> GetAllTeamsElements()
        {
            var getAllTeams = new List<TeamsElementPageObject>();
            foreach (IWebElement team in AllTeamsElements)
            {
                getAllTeams.Add(new TeamsElementPageObject(Driver, team));
            }
            return getAllTeams;
        }

        public void ClickOnTeamElementTeamDetails(string teamName)
        {
            List<TeamsElementPageObject> allTeams = GetAllTeamsElements();
            var teamsElement = allTeams.Find(t => t.IsElementPresentByTeamName(teamName) == true) 
                ?? throw new NoSuchElementException($"{teamName} element not found!");
            teamsElement.TeamDetailsClick();
        }

        public void ClickOnTeamElementTeamDepartment(string teamName)
        {
            List<TeamsElementPageObject> allTeams = GetAllTeamsElements();
            var teamsElement = allTeams.Find(t => t.IsElementPresentByTeamName(teamName) == true) 
                ?? throw new NoSuchElementException($"{teamName} element not found!");
            teamsElement.TeamDepartmentDetailsСlick();
        }

        public void ClickOnTeamElementAddMyTaskButton(string teamName)
        {
            List<TeamsElementPageObject> allTeams = GetAllTeamsElements();
            var teamsElement = allTeams.Find(t => t.IsElementPresentByTeamName(teamName) == true) 
                ?? throw new NoSuchElementException($"{teamName} element not found!");
            teamsElement.AddTaskButtonClick();
        }
    }
}