using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum Category
    {
        [Display(Name = "Dom")]
        House = 0,

        [Display(Name = "Mieszkanie")]
        Flat = 1
    }
}
