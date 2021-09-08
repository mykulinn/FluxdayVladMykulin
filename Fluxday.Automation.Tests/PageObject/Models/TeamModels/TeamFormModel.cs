using System.Collections.Generic;

namespace Fluxday.Automation.Tests.PageObject.Models.TeamModels
{
    public class TeamFormModel
    {
        public TeamFormModel(string name, string code, string description, string department, List<string> teamLeads)
        {
            Name = name;
            Code = code;
            Description = description;
            Department = department;
            TeamLeads = teamLeads;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public List<string> TeamLeads { get; set; }
    }
}