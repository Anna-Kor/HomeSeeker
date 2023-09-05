using Data.Enums;
using Data.Models;

namespace HomeSeeker.Tests.Factories
{
    public static class HomesFactory
    {
        public static List<Home> GetAvailableHomes()
        {
            return new List<Home> {
                new Home { Id = 1, Name = "Home1 test", Price = 111, Rent = null, Lon = 111.111111m, Lat = 11.111111m, City = "Warsaw", LivingArea = 450, LotArea = null, Category = Category.House, Type = HomeType.ForRent, Floor = null, FloorsQuantity = FloorsQuantity.GroundStoryOneWithUsableAttic, HasFurniture = true, RoomsQuantity = RoomsQuantity.Two, BathroomsQuantity = BathroomsQuantity.One, Status = HomeStatus.Available, Description = "Description1", CreatedUserId = 1 },
                new Home { Id = 2, Name = "Home2", Price = 222.22m, Rent = null, Lon = 222.222222m, Lat = 22.222222m, City = "Warsaw", LivingArea = 350, LotArea = null, Category = Category.House, Type = HomeType.ForRent, Floor = null, FloorsQuantity = FloorsQuantity.SingleStory, HasFurniture = true, RoomsQuantity = RoomsQuantity.Three, BathroomsQuantity = BathroomsQuantity.One, Status = HomeStatus.Available, Description = "Description2", CreatedUserId = 1 },
                new Home { Id = 3, Name = "Home3 test value", Price = 3333333333333.33m, Rent = null, Lon = 333.333333m, Lat = 33.333333m, City = "Warsaw", LivingArea = 400, LotArea = null, Category = Category.House, Type = HomeType.ForSale, Floor = null, FloorsQuantity = FloorsQuantity.SingleStory, HasFurniture = false, RoomsQuantity = RoomsQuantity.Three, BathroomsQuantity = BathroomsQuantity.Two, Status = HomeStatus.Available, Description = "Description3", CreatedUserId = 1 },
            };
        }

        public static List<Home> GetArchivedHomes()
        {
            return new List<Home> {
                new Home { Id = 4, Name = "Home4", Price = 111, Status = HomeStatus.Archived, CreatedUserId = 1 },
                new Home { Id = 5, Name = "Home5", Price = 222, Status = HomeStatus.Archived, CreatedUserId = 1 },
                new Home { Id = 6, Name = "Home6", Price = 333, Status = HomeStatus.Archived, CreatedUserId = 1 },
            };
        }

        public static List<Home> GetReservedHomes()
        {
            return new List<Home> {
                new Home { Id = 7, Name = "Home", Price = 111, Status = HomeStatus.Reserved, CreatedUserId = 1 },
                new Home { Id = 8, Name = "Reserved Home", Price = 222, Status = HomeStatus.Reserved, CreatedUserId = 1 },
                new Home { Id = 9, Name = "Home", Price = 333, Status = HomeStatus.Reserved, CreatedUserId = 1 },
            };
        }
    }
}
