using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.OKRDetailsPage
{
    public class OKRDetailsPage : BasePageObject
    {
        public OKRDetailsPage(IWebDriver driver) : base(driver) { }

        protected IWebElement OKRDetailsName
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".okr-details>.name"));
            }
        }

        protected IWebElement OKRDetailsPeriod
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".okr-details>.period"));
            }
        }

        protected IReadOnlyCollection<IWebElement> Objectives
        {
            get
            {
                return Driver.FindElements(By.CssSelector(".objectives>li"));
            }
        }

        protected IReadOnlyCollection<IWebElement> KeyResults
        {
            get
            {
                return Driver.FindElements(By.CssSelector(".key_results>li"));
            }
        }

        public List<string> GetAllObjectiveNames()
        {
            return Objectives.Select(x => x.Text)
                             .ToList();
        }

        public List<string> GetAllKeyResultNames()
        {
            return KeyResults.Select(x => x.Text)
                       .ToList();
        }

        public string GetOKRPeriod()
        {
            return OKRDetailsPeriod.Text;
        }

        public string GetOKRDetailsName()
        {
            return OKRDetailsName.Text;
        }

        public int GetObjectivesCount()
        {
            return Objectives.Count;
        }

        public int GetKeyResultCount()
        {
            return KeyResults.Count;
        }
    }
}
