using Fluxday.Automation.Tests.PageObject.OKRPage.AddNewOKR;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.ViewOKRPage
{
    public class ViewOKRPage : BaseObject.BasePageObject
    {
        public ViewOKRPage(IWebDriver driver) : base(driver) { }

        protected IWebElement NewOKRButton
        {
            get
            {
                return Driver.FindElement(By.ClassName("dashed_link"));
            }
        }

        protected IReadOnlyCollection<IWebElement> AllOKRs
        {
            get
            {
                return Driver.FindElements(By.ClassName("card"));
            }
        }

        protected IReadOnlyCollection<IWebElement> AllNamesOfOKRs
        {
            get
            {
                return Driver.FindElements(By.XPath("//*[@id='pane2']/div/a/div/div[1]")); 
            }
        }

        protected IReadOnlyCollection<IWebElement> AllDatesOfOKRs
        {
            get
            {
                return Driver.FindElements(By.ClassName("//*[@id='pane2']/div/a/div/div[2]"));
            }
        }

        public AddNewOKRPageObject NewOKRButtonClick()
        {
            NewOKRButton.Click();
            return new AddNewOKRPageObject(Driver);
        }

        public void ClickNameOfOKR(string nameOKR)
        {
            var okr = AllNamesOfOKRs.FirstOrDefault(f => f.Text.ToLower() == nameOKR.ToLower())
                      ?? throw new NoSuchElementException($"No such name of OKR : {nameOKR}");
            okr.Click();
        }

        public int AllOKRsCount()
        {
            return AllOKRs.Count;
        }
    }
}
