using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium.Support.UI;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class UsersPage : BasePageObject
    {
        public UsersPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }

        protected IWebElement AddUser
        {
            get
            {
                return DriverFindElementWithWait(By.XPath("//*[@id='pane2']/div/a[contains(text(),'Add user')]"));
            }
        }

        public bool IsUserPageTitleWithTextUsersPresent
        {
            get
            {
                return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                      .ExpectedConditions
                                                      .TextToBePresentInElementLocated(By.XPath("//*[@id='pane2']/div[1]/div"), "Users"));
            }
        }

        // All relevant elements in the «old» and «new» pages have the same locators.
        // To avoid loading the list from the «old» page, we are forced to wait
        // until the loading of the «new» page and only then form the list.
        // An indicator of completion of loading a new page is checking the loading
        // of a web element with the desired name.
        protected IReadOnlyCollection<IWebElement> ListOfUsers
        {
            get
            {
                return IsUserPageTitleWithTextUsersPresent
                           ? DriverFindElementsWithWait(By.CssSelector(".pane2-content .name"))
                           : new List<IWebElement>();
            }
        }

        public bool IsListOfUsersNotEmpty
        {
            get
            {
                return ListOfUsers.Any();
            }
        }

        public AddUserPage ClickOnAddUser()
        {
            AddUser.Click();
            return new AddUserPage(Driver, DriverWait);
        }

        public bool IsUserPresentInTheUsersList(string userName)
        {
            return ListOfUsers.Any(x => x.Text == userName);
        }

        public void GoToUserDetails(string userName)
        {
            var searchUser = ListOfUsers.FirstOrDefault(x => x.Text == userName)
                ?? throw new NoSuchElementException($"No such user found: \"{userName}\"!");
            searchUser.Click();
        }

        public void GoToUserDetailsUsingPartialUserName(string partialUserName)
        {
            var searchUser = ListOfUsers.FirstOrDefault(x => x.Text.Contains(partialUserName))
                ?? throw new NoSuchElementException($"No such user found that name contains \"{partialUserName}\"!");
            searchUser.Click();
        }
    }
}