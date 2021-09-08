using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject.DepartmentPage
{
    public class AdminDepartmentPage : DepartmentPage
    {
        public AdminDepartmentPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement CreateDepartment
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".pane2-content .dashed_link"));
            }
        }
        
        public void AddDepartment()
        {
            CreateDepartment.Click();
        }
    }
}