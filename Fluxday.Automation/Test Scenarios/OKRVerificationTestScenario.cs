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
using Fluxday.Automation.Tests.PageObject.OKRPage.AddNewOKR;
using Fluxday.Automation.Tests.PageObject.Models.OKRModels;
using Fluxday.Automation.Tests.PageObject.Users;
using System.Collections.Generic;

namespace Fluxday.Automation.Tests.Test_Scenarios
{
    public class OKRVerificationTestScenario
    {
        private IWebDriver browser;

        private WebDriverWait driverWait;
        private LoginPage LoginPage;
        private UsersPage usersPage;
        private NavigatePanelPage NavigatePanelPage;
        private AddNewOKRPageObject OKRPage;
        private OKRModel okrModel_one;
        private OKRModel okrModel_two;

        [SetUp]
        public void SetUp()
        {
            browser = new ChromeDriver("C:\\Users\\vmyku\\Desktop\\chromedriver_win32");
            driverWait = new WebDriverWait(browser, new System.TimeSpan(0, 0, 5));
            LoginPage = new LoginPage(browser, driverWait);

            okrModel_one = new OKRModel()
            {
                Name = "OKR1",
                EndDate = "2021-09-30",
                StartDate = "2021-09-20",
                ObjectivesList = new List<ObjectiveModel>(){
                    new ObjectiveModel { Name = "Objective1", OKRList = new List<string>()
                    { "Objective1_OKR1", "Objective1_OKR2" } },
                    new ObjectiveModel { Name = "Objective2", OKRList = new List<string>()
                    {"Objective2_OKR1", "Objective1_OKR2" }  } }
            };

            okrModel_two = new OKRModel()
            {
                Name = "OKR2",
                EndDate = "2022-09-30",
                StartDate = "2022-09-20",
                ObjectivesList = new List<ObjectiveModel>(){
                    new ObjectiveModel { Name = "Objective1", OKRList = new List<string>()
                    { "Objective1_OKR1", "Objective1_OKR2" } },
                    new ObjectiveModel { Name = "Objective2", OKRList = new List<string>()
                    {"Objective2_OKR1", "Objective1_OKR2" }  } }
            };

            OKRPage = new AddNewOKRPageObject(browser);

            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(CommonTestData.UrlForLoginPage);
        }
            [Test]
            public void OKRTest()
            {
                LoginPage.Login(new UserModelForCredentials("", E2EOKRTestData.AdminEmail, E2EOKRTestData.Password));
                OKRPage.OKRLeftButtonClick();
                OKRPage.NewOKRButtonClick();
                OKRPage.SetOKR(okrModel_one);
                OKRPage.NewOKRButtonClick();
                OKRPage.SetOKR(okrModel_two);
                
        }

            [TearDown]
            public void LogOut()
            {

            }
        }
}