using Fluxday.Automation.Tests.PageObject.Models.UserModels;
using Fluxday.Automation.Tests.Scenarios.Utils;
using System.Collections.Generic;

namespace Fluxday.Automation.Tests.Data
{
    public static class UsersTestData
    {
        public static UserModelForCredentials AdminUser
        {
            get
            {
                return new UserModelForCredentials("Admin User", "admin@fluxday.io", "password");
            }
        }

        public static UserModelForCredentials Employee1User
        {
            get
            {
                return new UserModelForCredentials("Employee 1", "emp1@fluxday.io", "password");
            }
        }

        public static UserModelForEdit NewUserToAddEmployee
        {
            get
            {
                return new UserModelForEdit(StringDateTime.AppendDateTimeString("TestEmployee"),
                                            StringDateTime.AppendDateTimeString("testEmployee"),
                                            $"testemployee{StringDateTime.GenerateDateTimeString()}@fluxday.io",
                                            StringDateTime.AppendDateTimeString("FTest1"),
                                            "Employee", "password", "password", "Team Lead");
            }
        }

        public static UserModelForEdit NewUserToAddManager
        {
            get
            {
                return new UserModelForEdit(StringDateTime.AppendDateTimeString("TestManager"),
                                            StringDateTime.AppendDateTimeString("testManager"),
                                            $"testmanager{StringDateTime.GenerateDateTimeString()}@fluxday.io",
                                            StringDateTime.AppendDateTimeString("FTest2"),
                                            "Manager", "password", "password", "Team Lead");
            }
        }

        public static IEnumerable<UserModelForEdit> TestDataToAddNewUser()
        {
            yield return NewUserToAddEmployee;
            yield return NewUserToAddManager;
        }

        public static UserModelForEdit DataToEditUserManager
        {
            get
            {
                return new UserModelForEdit(StringDateTime.AppendDateTimeString("TestManagerEdit"), "",
                                            $"testmanageredit{StringDateTime.GenerateDateTimeString()}@fluxday.io",
                                            StringDateTime.AppendDateTimeString("FEdit2"),
                                            "Employee", "", "", "Employee 1");
            }
        }

        public static UserModelForEdit DataToChangeUserPassword
        {
            get
            {
                return new UserModelForEdit("", "", "", "", "", "passwordTest123", "passwordTest123", "");
            }
        }

        public static string UrlAfterLoginWithNewCredentials(string employeeCode)
        {
            return $"https://app.fluxday.io/users/{employeeCode}#pane3";
        }

        public static string PartialNameOfAddedTestManagerUserForEdit
        {
            get
            {
                return "TestManager";
            }
        }

        public static string PartialNameOfAddedTestEmployeeUserForDelete
        {
            get
            {
                return "TestEmployee";
            }
        }
    }
}
