namespace Fluxday.Automation.Tests.PageObject.Models.UserModels
{
    public class UserModelForEdit : UserModelForCredentials
    {
        public UserModelForEdit(string name, string nickName, string email, string employeeCode,
                                string role, string password, string confirmPassword, string managers)
                                : base (name, email, password)
        {
            this.NickName = nickName;
            this.EmployeeCode = employeeCode;
            this.Role = role;
            this.ConfirmPassword = confirmPassword;
            this.Managers = managers;
        }

        public string NickName { get; set; }

        public string EmployeeCode { get; set; }

        public string Role { get; set; }

        public string ConfirmPassword { get; set; }

        public string Managers { get; set; }
    }
}
