using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject.MyTasks.AddEditMyTask
{
    public class EditMyTaskPageObject : GeneralAddEditMyTaskPageObject
    {
        public EditMyTaskPageObject(IWebDriver driver) : base(driver) { }
        
        protected override IWebElement CancelButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='edit_task_1463']/div[3]/div[2]/a/span"));
            }
        }

        protected override IWebElement SaveChangesButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='edit_task_1463']/div[3]/div[2]/input"));
            }
        }  
    }
}
