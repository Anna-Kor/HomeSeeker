using Data.Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Home
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Rent { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,6)")]
        public decimal Lon { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,6)")]
        public decimal Lat { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int LivingArea { get; set; }

        public int? LotArea { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [Required]
        public virtual HomeType Type { get; set; }

        public virtual Floor? Floor { get; set; }

        public virtual FloorsQuantity? FloorsQuantity { get; set; }

        [Required]
        public bool HasFurniture { get; set; }

        public virtual RoomsQuantity? RoomsQuantity { get; set; }

        public virtual BathroomsQuantity? BathroomsQuantity { get; set; }

        [Required]
        public HomeStatus Status { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
