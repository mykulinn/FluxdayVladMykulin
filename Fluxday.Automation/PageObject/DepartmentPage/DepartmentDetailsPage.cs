using Fluxday.Automation.Tests.PageObject.BaseObject;
using Fluxday.Automation.Tests.PageObject.Teams;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.DepartmentPage
{
    public class DepartmentDetailsPage : BasePageObject
    {
        public DepartmentDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement TitleLabel
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='main-title']"));
            }
        }

        protected IWebElement CodeLabel
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='main-title-helper']"));
            }
        }

        protected IWebElement UrlLabel
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='website']"));
            }
        }

        protected IWebElement DescriptionLabel
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='description']"));
            }
        }

        protected IWebElement SettingsIcon
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='icon settings-link']"));
            }
        }

        protected IReadOnlyCollection<IWebElement> SettingsList
        {
            get
            {
                return Driver.FindElements(By.XPath("//ul[@class='f-dropdown drop-left open']"));
            }
        }

        protected IReadOnlyCollection<IWebElement> PanelsList
        {
            get
            {
                return Driver.FindElements(By.XPath("//div[contains(@id,'pane')]"));
            }
        }

        protected IWebElement EditTaskButton
        {
            get
            {
                return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                      .ExpectedConditions
                                                      .ElementIsVisible(By.XPath(String.Format("//a[text()='Edit' and ancestor-or-self:: ul[contains(@id,'drop')]]"))));
            }
        }

        protected IWebElement DeleteTaskButton
        {
            get
            {
                return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                      .ExpectedConditions
                                                      .ElementIsVisible(By.XPath(String.Format("//a[text()='Delete' and ancestor-or-self:: ul[contains(@id,'drop')]]"))));
            }
        }

        protected IWebElement NewTeamButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[text()='New team']"));
            }
        }

        protected IWebElement ManagersTab
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[contains(.,'Managers')]"));
            }
        }

        public bool IsTitleDisplayed()
        {
            return DriverWait.Until(d => TitleLabel.Displayed);
        }

        public CreateTeamPage ClickNewTeamButton()
        {
            NewTeamButton.Click();
            return new CreateTeamPage(Driver);
        }

        public CreateDeparmentPage ClickOnEditTaskMenuItem()
        {
            SettingsIcon.Click();
            EditTaskButton.Click();
            DriverWait.Until(d => !SettingsList.Any()
                                  && PanelsList.Any());
            return new CreateDeparmentPage(Driver);
        }

        public void ClickOnDeleteTaskMenuItem()
        {
            SettingsIcon.Click();
            DeleteTaskButton.Click();
            DriverWait.Until(SeleniumExtras.WaitHelpers
                                           .ExpectedConditions
                                           .AlertIsPresent())
                                           .Accept();
            DriverWait.Until(d => !SettingsList.Any()
                                  && PanelsList.Any());
        }

        public string GetTitle()
        {
            return TitleLabel.Text;
        }

        public string GetCode()
        {
            return CodeLabel.Text.Substring(1, CodeLabel.Text.Length - 2);
        }

        public string GetUrl()
        {
            return UrlLabel.Text;
        }

        public string GetDescription()
        {
            return DescriptionLabel.Text;
        }

        public ManagersTabPage ClickOnManagersTab()
        {
            ManagersTab.Click();
            return new ManagersTabPage(Driver);
        }
    }
}