using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.NavigatePanel
{
    public class NavigatePanelPage : BasePageObject
    {
        public NavigatePanelPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }

        protected IWebElement SearchInput
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='search_keyword']"));
            }
        }

        protected IWebElement CurrentUser
        {
            get
            {
                return DriverFindElementWithWait(By.XPath("/html/body/div/div[1]/ul[3]/li[1]/a"));
            }
        }

        protected IWebElement LogoutButton
        {
            get
            {
                return DriverFindElementWithWait(By.XPath("/html/body/div/div[1]/ul[3]/li[2]/a[contains(text(),'Logout')]"));
            }
        }

        protected IWebElement CreateNewTaskButton
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/nav/section/ul[1]/li"));
            }
        }

        protected IReadOnlyCollection<IWebElement> SectionList
        {
            get
            {
                return DriverFindElementsWithWait(By.XPath("html/body/div[2]/div[1]/ul[2]/li/a"));
            }
        }

        public int SectionListCount()
        {
            return SectionList.Count;
        }

        public string CurrentUserName()
        {
            return CurrentUser.Text;
        }

        public void ClickOnCreateNewTaskButton()
        {
            CreateNewTaskButton.Click();
        }

        public void FillInSearchInputAndPressEnter(string searchedText)
        {
            FillInInput(SearchInput, searchedText);
            SearchInput.SendKeys(Keys.Return);
        }

        public void ClickOnLogoutButton()
        {
            LogoutButton.Click();
        }

        public void SelectDesiredSectionAndClickOnIt(string sectionTitle)
        {
            var searchSection = SectionList.FirstOrDefault(x => x.Text.ToUpper() == sectionTitle.ToUpper())
                ?? throw new NoSuchElementException($"No such section found: {sectionTitle}");
            searchSection.Click();
        }
    }
}
