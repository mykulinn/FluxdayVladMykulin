namespace Fluxday.Automation.Tests.PageObject.Models.UserModels
{
    public class UserModelForCredentials
    {
        public UserModelForCredentials(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
