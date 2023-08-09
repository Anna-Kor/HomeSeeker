using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum Floor
    {
        [Display(Name = "Suterena")]
        Basement = 0,

        [Display(Name = "Parter")]
        GroundFloor = 0,

        [Display(Name = "1")]
        FirstFloor = 1,

        [Display(Name = "2")]
        SecondFloor = 2,

        [Display(Name = "3")]
        ThirdFloor = 3,

        [Display(Name = "4")]
        FourthFloor = 4
    }
}
