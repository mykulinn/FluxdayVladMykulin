using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Fluxday.Automation.Tests.PageObject.BaseObject;
using OpenQA.Selenium.Support.UI;
using System;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class UsersPage : BasePageObject
    {
        public UsersPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }
        protected IWebElement UsersLeftTab
        {
            get
            {
                return Driver.FindElement(By.XPath("//ul[@class = 'side-nav sidebar-links top-set']//a[@href = '/users']"));
            }
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

        public void ClickUsersLeftTab() => UsersLeftTab.Click();

        public void CreateUser(string name, string nickname, string email, string ID, string password, string role, string managers)
        {
            CreateUserSeNickName(nickname);
            CreateUserSetName(name);
            CreateUserSetEmail(email);
            CreateUserSetEmpCode(ID);
            CreateUserSetPassword(password);
            CreateUserSetConfirmPassword(password);
            ClickSaveBtn();
        }

        private IWebElement CreateUserNameField
        {
            get => DriverFindElementWithWait(By.XPath("//input[@id = 'user_name']"));
        }

        public void CreateUserSetName(string name) => CreateUserNameField.SendKeys(name);

        private IWebElement CreateUserNickNameField
        {
            get => DriverFindElementWithWait(By.XPath("//input[@id = 'user_nickname']"));
        }

        public void CreateUserSeNickName(string nickname) => CreateUserNickNameField.SendKeys(nickname);

        private IWebElement CreateUserEmailField
        {
            get => DriverFindElementWithWait(By.XPath("//input[@id = 'user_email']"));
        }
        public void CreateUserSetEmail(string email) => CreateUserEmailField.SendKeys(email);

        private IWebElement CreateUserEmpCodeField
        {
            get => DriverFindElementWithWait(By.XPath("//input[@id = 'user_employee_code']"));
        }
        public void CreateUserSetEmpCode(string empCode) => CreateUserEmpCodeField.SendKeys(empCode);

        private IWebElement CreateUserPasswordField
        {
            get => DriverFindElementWithWait(By.XPath("//input[@id = 'user_password']"));
        }
        public void CreateUserSetPassword(string password) => CreateUserPasswordField.SendKeys(password);

        private IWebElement CreateUserConfirmPasswordField
        {
            get => DriverFindElementWithWait(By.XPath("//input[@id = 'user_password_confirmation']"));
        }
        public void CreateUserSetConfirmPassword(string password) => CreateUserConfirmPasswordField.SendKeys(password);

        private IWebElement btnSave
        {
            get => DriverFindElementWithWait(By.XPath("//input[@value = 'Save']"));
        }

        private IWebElement getErrorMessage(string messageText)
            => DriverFindElementWithWait(By.XPath($"//div[@id = 'error_explanation']/li[text() = '{messageText}']"));


        public void ClickSaveBtn() => btnSave.Click();

        public void VerifyErrorMessageDisplayed(string messageText, bool shouldBeDisplayed)
        {
            if (getErrorMessage(messageText).Displayed != shouldBeDisplayed)
                throw new Exception("Element is in not expected state");
        }

        private IWebElement userSettingsButton
        {
            get => DriverFindElementWithWait(By.XPath("//div[@class = 'icon settings-link']"));
        }

        public void userSettingsButtonClick() => userSettingsButton.Click();

        private IWebElement userSettingsdeleteUserButton
        {
            get => DriverFindElementWithWait(By.XPath("//a[text() = 'Delete']"));
        }

        public void userSettingsdeleteUserButtonClick()
        {
            userSettingsdeleteUserButton.Click();
            Driver.SwitchTo().Alert().Accept();
        }
    }
}