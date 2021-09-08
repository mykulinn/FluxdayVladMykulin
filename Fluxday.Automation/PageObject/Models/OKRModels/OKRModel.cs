using System.Collections.Generic;

namespace Fluxday.Automation.Tests.PageObject.Models.OKRModels
{
    public class OKRModel
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<ObjectiveModel> ObjectivesList { get; set; }
    }
}
