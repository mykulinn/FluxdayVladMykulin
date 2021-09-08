using Fluxday.Automation.Tests.Data;
using Fluxday.Automation.Tests.PageObject.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Fluxday.Automation.Tests.PageObject.Models.UserModels;
using Fluxday.Automation.Tests.PageObject.NavigatePanel;
using Fluxday.Automation.Tests.PageObject.MyTasks.AddEditMyTask;
using Fluxday.Automation.Tests.PageObject.MyTaskViewPage;

namespace Fluxday.Automation.Tests.Test_Scenarios
{
    public class VerifyTaskTestScenario
    {
        private IWebDriver browser;
        private WebDriverWait driverWait;
        private LoginPage LoginPage;
        private NavigatePanelPage NavigatePanelPage;
        private GeneralAddEditMyTaskPageObject addMyNewTask;
        private MyTasksViewPage myTasksViewPage;

        [SetUp]
        public void SetUp()
        {
            browser = new ChromeDriver("C:\\Users\\vmyku\\Desktop\\chromedriver_win32");
            driverWait = new WebDriverWait(browser, new System.TimeSpan(0,0, 5));
            NavigatePanelPage = new NavigatePanelPage(browser, driverWait);
            LoginPage = new LoginPage(browser, driverWait);
            addMyNewTask = new GeneralAddEditMyTaskPageObject(browser);
            myTasksViewPage = new MyTasksViewPage(browser);

            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(CommonTestData.UrlForLoginPage);
        }

        [Test]
        public void VerifyBasicFlow()
        {
            LoginPage.Login(new UserModelForCredentials("", E2EOKRTestData.AdminEmail, E2EOKRTestData.Password));
            NavigatePanelPage.ClickOnCreateNewTaskButton();
            addMyNewTask.SetTitle("TestAutomationTask_1");
            addMyNewTask.SetDescription("TestAutomationTask_1_Description");
            addMyNewTask.SetPriority("Medium");
            addMyNewTask.ClickCreateTaskButton();
            myTasksViewPage.ClickOnMyTasksTab();
            myTasksViewPage.VerifyMyTaskExist("TestAutomationTask_1", "DevOps");
        }

        [TearDown]
        public void LogOut()
        {
            myTasksViewPage.clickEditTaskButton("TestAutomationTask_1");
            myTasksViewPage.clickTaskSettingsButton();
            myTasksViewPage.clickDeleteTaskButton();
            NavigatePanelPage.ClickOnLogoutButton();
            browser.Quit();
        }
    }
}