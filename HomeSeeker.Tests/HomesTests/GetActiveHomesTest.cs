using Data;
using Data.Models;

using FluentAssertions;

using HomeSeeker.API.Models;
using HomeSeeker.API.Queries.HomeQueries.GetActiveHomes;
using HomeSeeker.API.Repositories.HomeRepositories;
using HomeSeeker.Tests.Factories;
using HomeSeeker.Tests.Mocks;

using NSubstitute;

namespace HomeSeeker.Tests.HomesTests
{
    public class GetActiveHomesTest
    {
        private readonly List<Home> _availableHomes = HomesFactory.GetAvailableHomes();
        private readonly List<Home> _archivedHomes = HomesFactory.GetArchivedHomes();
        private readonly List<Home> _allHomes = new List<Home>();

        public static TheoryData<decimal?, decimal?> PriceData =>
           new()
           {
               { null, null },
               { 0m, null },
               { 0m, 100000m }
           };

        public GetActiveHomesTest()
        {
            _allHomes.AddRange(_availableHomes);
            _allHomes.AddRange(_archivedHomes);
        }

        [Fact]
        public async void GetActiveHomes_WithoutQueryParameters_ShouldReturnOnlyActiveHomesFromDb()
        {
            var mockSet = DbSetMock.CreateMockDbSet(_allHomes);
            var mockContext = Substitute.For<IDbContext>();
            mockContext.Homes.Returns(mockSet);
            var repository = new GetHomeRepository(mockContext);

            var handler = new GetActiveHomesQueryHandler(repository);
            var query = new GetActiveHomesQuery();

            List<HomeModel> result = await handler.Handle(query, default);

            Assert.NotNull(result);
            result.Count.Should().Be(_availableHomes.Count);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("somethingNotInTheName")]
        [InlineData("")]
        [InlineData(null)]
        public async void GetActiveHomes_WithNameFilter_ShouldReturnActiveHomesWhichNamesContainGivenValue(string name)
        {
            var mockSet = DbSetMock.CreateMockDbSet(_allHomes);
            var mockContext = Substitute.For<IDbContext>();
            mockContext.Homes.Returns(mockSet);
            var repository = new GetHomeRepository(mockContext);

            var handler = new GetActiveHomesQueryHandler(repository);
            var query = new GetActiveHomesQuery { FilterValues = new FilterValues { Name = name } };

            List<HomeModel> result = await handler.Handle(query, default);

            List<Home> matchingMockValues = _availableHomes.Where(x => name == null || x.Name.Contains(name)).ToList();

            Assert.NotNull(result);
            result.Count.Should().Be(matchingMockValues.Count);
            result.TrueForAll(x => name == null || x.Name.Contains(name));
        }

        [Theory]
        [MemberData(nameof(PriceData))]
        public async void GetActiveHomes_WithPriceFilter_ShouldReturnActiveHomesWhichPricesAreInRange(decimal? priceFrom, decimal? priceTo)
        {
            var mockSet = DbSetMock.CreateMockDbSet(_allHomes);
            var mockContext = Substitute.For<IDbContext>();
            mockContext.Homes.Returns(mockSet);
            var repository = new GetHomeRepository(mockContext);

            var handler = new GetActiveHomesQueryHandler(repository);
            var query = new GetActiveHomesQuery { FilterValues = new FilterValues { PriceFrom = priceFrom, PriceTo = priceTo } };

            List<HomeModel> result = await handler.Handle(query, default);

            List<Home> matchingMockValues = _availableHomes.Where(x => (priceFrom == null || x.Price >= priceFrom) && (priceTo == null || x.Price <= priceTo)).ToList();

            Assert.NotNull(result);
            result.Count.Should().Be(matchingMockValues.Count);
            result.TrueForAll(x => (priceFrom == null || x.Price >= priceFrom) && (priceTo == null || x.Price <= priceTo));
        }

        [Theory]
        [InlineData("Warszawa")]
        [InlineData("London")]
        [InlineData("")]
        [InlineData(null)]
        public async void GetActiveHomes_WithCityFilter_ShouldReturnActiveHomesWhichCitiesAreGivenValue(string city)
        {
            var mockSet = DbSetMock.CreateMockDbSet(_allHomes);
            var mockContext = Substitute.For<IDbContext>();
            mockContext.Homes.Returns(mockSet);
            var repository = new GetHomeRepository(mockContext);

            var handler = new GetActiveHomesQueryHandler(repository);
            var query = new GetActiveHomesQuery { FilterValues = new FilterValues { City = city } };

            List<HomeModel> result = await handler.Handle(query, default);

            List<Home> matchingMockValues = _availableHomes.Where(x => city == null || x.City.Equals(city)).ToList();

            Assert.NotNull(result);
            result.Count.Should().Be(matchingMockValues.Count);
            result.TrueForAll(x => city == null || x.City.Equals(city));
        }
    }
}
