using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum FloorsQuantity
    {
        [Display(Name = "Parterowy")]
        GroundStory = 1,

        [Display(Name = "Parterowy z użytkowym poddaszem")]
        GroundStoryOneWithUsableAttic = 2,

        [Display(Name = "Jednopiętrowy")]
        SingleStory = 3,

        [Display(Name = "Dwupiętrowy i więcej")]
        TwoStoryAndMore = 4
    }
}
