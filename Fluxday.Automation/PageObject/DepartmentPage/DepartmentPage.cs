using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.DepartmentPage
{
    public class DepartmentPage : BaseObject.BasePageObject
    {

        public DepartmentPage(IWebDriver driver) : base(driver)
        {
        }

        protected IReadOnlyCollection<IWebElement> Departments
        {
            get
            {
                return Driver.FindElements(By.CssSelector(".card-transparent .title"));
            }
        }

        public int GetDepartmentCount()
        {
            return Departments.Count;
        }

        public string GetDepartmentsUrl()
        {
            return Driver.Url;
        }
        
        public void GoToDepartmentDetails(string departmentTitle)
        {
             var searchDepartment = Departments.FirstOrDefault(x => x.Text.ToUpper() == departmentTitle.ToUpper())
                 ?? throw new NoSuchElementException($"Department not found: {departmentTitle}");
            searchDepartment.Click();
        }
    }
}