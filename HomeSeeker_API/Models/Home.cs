using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSeeker_API.Models
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
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }

        [Required]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual Type Types { get; set; }

        public int? FloorId { get; set; }

        [ForeignKey("FloorId")]
        public virtual Floor Floors { get; set; }

        public int? FloorsNumberId { get; set; }

        [ForeignKey("FloorsNumberId")]
        public virtual FloorsNumbers FloorsNumbers { get; set; }

        [Required]
        public string Furniture { get; set; }

        public int? RoomsNumberId { get; set; }

        [ForeignKey("RoomsNumberId")]
        public virtual Room Rooms { get; set; }

        public int? BathroomsId { get; set; }

        [ForeignKey("BathroomsId")]
        public virtual Bathroom Bathrooms { get; set; }

        [Required]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Statuses { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
