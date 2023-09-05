using Data;
using Data.Models;

using FluentAssertions;

using HomeSeeker.API.Models;
using HomeSeeker.API.Queries.HomeQueries.GetAllHomes;
using HomeSeeker.API.Repositories.HomeRepositories;
using HomeSeeker.Tests.Factories;
using HomeSeeker.Tests.Mocks;

using NSubstitute;

namespace HomeSeeker.Tests.HomesTests
{
    public class GetAllHomesTest
    {
        private readonly List<Home> _availableHomes = HomesFactory.GetAvailableHomes();
        private readonly List<Home> _archivedHomes = HomesFactory.GetArchivedHomes();
        private readonly List<Home> _allHomes = new List<Home>();

        public GetAllHomesTest()
        {
            _allHomes.AddRange(_availableHomes);
            _allHomes.AddRange(_archivedHomes);
        }

        [Fact]
        public async void GetAllHomes_ShouldReturnAllHomesFromDb()
        {
            var mockSet = DbSetMock.CreateMockDbSet(_allHomes);
            var mockContext = Substitute.For<IDbContext>();
            mockContext.Homes.Returns(mockSet);
            var repository = new GetHomeRepository(mockContext);

            var handler = new GetAllHomesQueryHandler(repository);
            var query = new GetAllHomesQuery();

            List<HomeModel> result = await handler.Handle(query, default);

            Assert.NotNull(result);
            result.Count.Should().Be(_allHomes.Count);
        }
    }
}
