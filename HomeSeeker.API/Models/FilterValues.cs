namespace HomeSeeker.API.Models
{
    public class FilterValues
    {
        public string Name { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public string City { get; set; }
    }
}
