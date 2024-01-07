using CVProjekt1._0.Models;
using System.ComponentModel.DataAnnotations;

namespace CVProjekt1._0.ViewModels
{
    public enum DesiredManpowerEnum
    {
        [Display(Name = "1")]
        One = 1,

        [Display(Name = "2")]
        Two = 2,

        [Display(Name = "5+")]
        FivePlus = 5,

        [Display(Name = "15+")]
        FifteenPlus = 15,

        [Display(Name = "30+")]
        ThirtyPlus = 30,

        [Display(Name = "50+")]
        FiftyPlus = 50
    }

    public class CreateProjectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DesiredManpowerEnum DesiredManpower { get; set; }
    }
}
