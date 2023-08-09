using Data.Enums;

using MediatR;

namespace HomeSeeker.API.Commands.HomeCommands
{
    public class AddHomeCommand : IRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Rent { get; set; }

        public decimal Lon { get; set; }

        public decimal Lat { get; set; }

        public string City { get; set; }

        public int LivingArea { get; set; }

        public int? LotArea { get; set; }

        public Category Category { get; set; }

        public HomeType Type { get; set; }

        public Floor? Floor { get; set; }

        public FloorsQuantity? FloorsQuantity { get; set; }

        public bool HasFurniture { get; set; }

        public RoomsQuantity? RoomsQuantity { get; set; }

        public BathroomsQuantity? BathroomsQuantity { get; set; }

        public string Description { get; set; }
    }
}
