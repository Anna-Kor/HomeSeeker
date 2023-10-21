using Data.Enums;

using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HomeSeeker.API.Commands.HomeCommands.AddHome
{
    public class AddHomeCommand : IRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? Rent { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int LivingArea { get; set; }

        public int? LotArea { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public HomeType Type { get; set; }

        public Floor? Floor { get; set; }

        public FloorsQuantity? FloorsQuantity { get; set; }

        [Required]
        public bool HasFurniture { get; set; }

        public RoomsQuantity? RoomsQuantity { get; set; }

        public BathroomsQuantity? BathroomsQuantity { get; set; }

        public string Description { get; set; }

        [Required]
        public int CreatedUserId { get; set; }
    }
}
