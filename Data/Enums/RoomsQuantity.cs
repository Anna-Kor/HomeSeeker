using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum RoomsQuantity
    {
        [Display(Name = "1 pokój")]
        One = 1,

        [Display(Name = "2 pokoje")]
        Two = 2,

        [Display(Name = "3 pokoje")]
        Three = 3,

        [Display(Name = "4 i więcej")]
        FourAndMore = 4
    }
}
