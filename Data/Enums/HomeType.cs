using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum HomeType
    {
        [Display(Name = "Na wynajem")]
        ForRent = 0,

        [Display(Name = "Na sprzedaż")]
        ForSale = 1
    }
}
