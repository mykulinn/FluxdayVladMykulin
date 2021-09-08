using System.Collections.Generic;

namespace Fluxday.Automation.Tests.PageObject.Models.DepartmentModels
{
    public class DepartmentFormModel
    {
        public DepartmentFormModel(string title, string code, string url, string description, List<string> managers)
        {
            Title = title;
            Code = code;
            Url = url;
            Description = description;
            Managers = managers;
        }

        public string Title { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public List<string> Managers { get; set; }
    }
}