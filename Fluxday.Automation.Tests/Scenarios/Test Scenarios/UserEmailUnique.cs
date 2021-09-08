using Fluxday.Automation.Tests.Data;
using Fluxday.Automation.Tests.PageObject.Login;
using Fluxday.Automation.Tests.PageObject.Models.UserModels;
using Fluxday.Automation.Tests.PageObject.NavigatePanel;
using Fluxday.Automation.Tests.PageObject.Users;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Fluxday.Automation.Tests.Test_Scenarios
{
    // Unique e-mail can be assigned to one user 
    public class UserEmailUnique
    {
        private IWebDriver browser;

        private WebDriverWait driverWait;
        private LoginPage LoginPage;
        private UsersPage usersPage;
        private NavigatePanelPage NavigatePanelPage;

        private string timeStamp = DateTime.Now.ToString("HHmmss");
        private string email = "qwerty@gmail.com";
        private string errorMessage = "Email has already been taken";
        private string nicknameOne = "qwertyone";
        private string nicknameTwo = "qwertytwo";

        [SetUp]
        public void SetUp()
        {
            email = timeStamp + email;
            nicknameOne = timeStamp + nicknameOne;
            nicknameTwo = timeStamp + nicknameTwo;

            browser = new ChromeDriver("C:\\Users\\vmyku\\Desktop\\chromedriver_win32");
            driverWait = new WebDriverWait(browser, new System.TimeSpan(0, 0, 5));
            NavigatePanelPage = new NavigatePanelPage(browser, driverWait);
            LoginPage = new LoginPage(browser, driverWait);
            usersPage = new UsersPage(browser, driverWait);

            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(CommonTestData.UrlForLoginPage);
        }

        [Test]
        public void UserEmailIsUnique()
        {
            LoginPage.Login(new UserModelForCredentials("", E2EOKRTestData.AdminEmail, E2EOKRTestData.Password));
            usersPage.ClickUsersLeftTab();
            usersPage.ClickOnAddUser();
            usersPage.CreateUser(nicknameOne, nicknameOne, email, "aaaaaa", "12345678", String.Empty, String.Empty);
            usersPage.ClickUsersLeftTab();
            usersPage.ClickOnAddUser();
            usersPage.CreateUser(nicknameTwo, nicknameTwo, email, "bbbbbb", "12345678", String.Empty, String.Empty);
            usersPage.VerifyErrorMessageDisplayed(errorMessage, true);
        }

        [TearDown]
        public void LogOut()
        {
            usersPage.ClickUsersLeftTab();
            usersPage.GoToUserDetails(nicknameOne);
            usersPage.userSettingsButtonClick();
            usersPage.userSettingsdeleteUserButtonClick();
            NavigatePanelPage.ClickOnLogoutButton();
            browser.Quit();
        }
    }
}