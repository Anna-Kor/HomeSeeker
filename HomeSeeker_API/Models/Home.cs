using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSeeker_API.Models
{
    public class Home
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("rent")]
        public decimal Rent { get; set; }

        [Required]
        [Column("lon")]
        public decimal Lon { get; set; }

        [Required]
        [Column("lat")]
        public decimal Lat { get; set; }

        [Required]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [Column("living_area")]
        public int LivingArea { get; set; }

        [Column("lot_area")]
        public int? LotArea { get; set; }

        [Required]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }

        [Required]
        [Column("type_id")]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual Type Types { get; set; }

        [Column("floor_id")]
        public int? FloorId { get; set; }

        [ForeignKey("FloorId")]
        public virtual Floor Floors { get; set; }

        [Column("floors_number_id")]
        public int? FloorsNumberId { get; set; }

        [ForeignKey("FloorsNumberId")]
        public virtual FloorsNumbers FloorsNumbers { get; set; }

        [Required]
        [Column("furniture")]
        public string Furniture { get; set; }

        [Column("rooms_number_id")]
        public int? RoomsNumberId { get; set; }

        [ForeignKey("RoomsNumberId")]
        public virtual Room Rooms { get; set; }

        [Column("bathrooms_id")]
        public int? BathroomsId { get; set; }

        [ForeignKey("BathroomsId")]
        public virtual Bathroom Bathrooms { get; set; }

        [Required]
        [Column("status_id")]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Statuses { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }
    }
}
