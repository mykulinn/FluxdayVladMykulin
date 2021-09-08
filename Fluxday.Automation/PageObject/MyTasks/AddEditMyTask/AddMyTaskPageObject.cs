using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject.MyTasks.AddEditMyTask
{
    public class AddMyTaskPageObject : GeneralAddEditMyTaskPageObject
    {
        public AddMyTaskPageObject(IWebDriver driver) : base(driver) { }

        protected override IWebElement CancelButton
        {
            get
            {
                return Driver.FindElement(By.ClassName("translation_missing"));
            }
        }

        protected override IWebElement SaveChangesButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='new_task']/div[3]/div[2]/input"));
            }
        }
    }
}
