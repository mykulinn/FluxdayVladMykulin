using Fluxday.Automation.Tests.PageObject.Models.OKRModels;
using System.Collections.Generic;

namespace Fluxday.Automation.Tests.Data
{
    public static class E2EOKRTestData
    {
        public const int ExpectedEmployee1OKRCount = 2;
        public const int ExpectedEmployee1NewOKRCount = 3;
        public const int ExpectedAdminTabsCount = 8;
        public const string OKRTabTitle = "OKR";
        public const string Employee1Name = "Employee 1";
        public const string BaseUrl = "https://app.fluxday.io/users/sign_in";
        public const string Employee1Email = "emp1@fluxday.io";
        public const string AdminEmail = "admin@fluxday.io";
        public const string Password = "password";
        public const string ExpectedNewOKRTitle = "NewOKRForEmployee1";
        public const string ExpectedNewOKRTimePeriod = "01 October 2019 - 10 February 2020";
        public const string EditedNewOKRTitle = "EditedOKRForEmployee1";
        public const string EidtedNewOKRTimePeriod = "10 October 2019 - 20 March 2020";

        public static List<string> Employee1Objectives
        {
            get
            {
                return new List<string>()
                {
                    "TestObjective1",
                    "TestObjective2"
                };
            }
        }

        public static List<string> Employee1OKRs
        {
            get
            {
                return new List<string>()
                {
                    "TestKeyResult1",
                    "TestKeyResult2",
                    "TestKeyResult3",
                    "TestKeyResult4"
                };
            }
        }

        public static List<string> EditedEmployee1Objectives
        {
            get
            {
                return new List<string>()
                {
                    "EditedTestObjective1",
                    "EditedTestObjective2",
                    "TestObjective3"
                };
            }
        }

        public static List<string> EditedEmployee1OKRs
        {
            get
            {
                return new List<string>()
                {
                    "EditedTestKeyResult1",
                    "EditedTestKeyResult2",
                    "EditedTestKeyResult3",
                    "EditedTestKeyResult4",
                    "TestKeyResult5",
                    "TestKeyResult6",
                    "TestKeyResult7",
                    "TestKeyResult8"
                };
            }
        }

        public static OKRModel NewOKRForEmployee1
        {
            get
            {
                return new OKRModel()
                {
                    Name = ExpectedNewOKRTitle,
                    StartDate = "2019-10-01",
                    EndDate = "2020-02-10",
                    ObjectivesList = new List<ObjectiveModel>()
                    {
                        new ObjectiveModel()
                        {
                            Name = "TestObjective1",
                            OKRList = new List<string>()
                            {
                                "TestKeyResult1",
                                "TestKeyResult2"
                            }
                        },
                        new ObjectiveModel()
                        {
                            Name = "TestObjective2",
                            OKRList = new List<string>()
                            {
                                "TestKeyResult3",
                                "TestKeyResult4"
                            }
                        },
                    }
                };
            }
        }

        public static OKRModel EditedOKRForEmployee1
        {
            get
            {
                return new OKRModel()
                {
                    Name = EditedNewOKRTitle,
                    StartDate = "2019-10-10",
                    EndDate = "2020-03-20",
                    ObjectivesList = new List<ObjectiveModel>()
                    {
                        new ObjectiveModel()
                        {
                            Name = "EditedTestObjective1",
                            OKRList = new List<string>()
                            {
                                "EditedTestKeyResult1",
                                "EditedTestKeyResult2"
                            }
                        },
                        new ObjectiveModel()
                        {
                            Name = "EditedTestObjective2",
                            OKRList = new List<string>()
                            {
                                "EditedTestKeyResult3",
                                "EditedTestKeyResult4",
                                "TestKeyResult5"
                            }
                        },
                        new ObjectiveModel()
                        {
                            Name = "TestObjective3",
                            OKRList = new List<string>()
                            {
                                "TestKeyResult6",
                                "TestKeyResult7",
                                "TestKeyResult8"
                            }
                        },
                    }
                };
            }
        }
    }
}
