using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum BathroomsQuantity
    {
        [Display(Name = "1 łazienka")]
        One = 1,

        [Display(Name = "2 łazienki")]
        Two = 2,

        [Display(Name = "3 łazienki")]
        Three = 3,

        [Display(Name = "4 i więcej")]
        FourAndMore = 4
    }
}
