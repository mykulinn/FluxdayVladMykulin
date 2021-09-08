using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.DepartmentPage
{
    public class ManagersTabPage : BasePageObject
    {
        public ManagersTabPage(IWebDriver driver) : base(driver)
        {
        }

        protected IReadOnlyCollection<IWebElement> ManagersList
        {
            get
            {
                return Driver.FindElements(By.XPath("//div[@id='project-managers']//a[@class='name' and contains(text(),'')]"));
            }
        }

        public List<string> GetManagesList()
        {
            return ManagersList.Select(manager => manager.Text).ToList();
        }
    }
}