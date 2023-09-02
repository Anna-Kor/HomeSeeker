using Data.Enums;
using Data.Models;

namespace HomeSeeker.API.Models
{
    public class HomeModel
    {
        public HomeModel(Home home)
        {
            Id = home.Id;
            Name = home.Name;
            Price = home.Price;
            Rent = home.Rent;
            Lon = home.Lon;
            Lat = home.Lat;
            City = home.City;
            LivingArea = home.LivingArea;
            LotArea = home.LotArea;
            Category = home.Category;
            Type = home.Type;
            Floor = home.Floor;
            FloorsQuantity = home.FloorsQuantity;
            HasFurniture = home.HasFurniture;
            RoomsQuantity = home.RoomsQuantity;
            BathroomsQuantity = home.BathroomsQuantity;
            Status = home.Status;
            Description = home.Description;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? Rent { get; set; }

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

        public HomeStatus Status { get; set; }

        public string Description { get; set; }
    }
}
