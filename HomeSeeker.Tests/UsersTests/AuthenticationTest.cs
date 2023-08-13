using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Authorization.Utils;
using HomeSeeker.API.Models;
using HomeSeeker.API.Queries;
using HomeSeeker.API.Queries.UserQueries;
using HomeSeeker.API.Repositories.UserRepositories;

using NSubstitute;

namespace HomeSeeker.Tests.UsersTests
{
    public class AuthenticationTest
    {
        private readonly IUserRepository _userRepositoryMock;
        private readonly IJwtUtils _jwtUtils;
        private readonly IPasswordHelper _passwordHelperMock;

        public AuthenticationTest()
        {
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _jwtUtils = Substitute.For<IJwtUtils>();
            _passwordHelperMock = Substitute.For<IPasswordHelper>();
        }

        [Theory]
        [InlineData("user", "password")]
        public async void AuthencticateUser_WhereUsernameAndPasswordIsCorrect_ShouldReturnOk(string username, string password)
        {
            var query = new AuthenticateQuery(username, password);

            _passwordHelperMock.VerifyPassword(default, default, default).ReturnsForAnyArgs(true);
            _userRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = query.Username, Password = query.Password } });
            
            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("user", "password")]
        public async void AuthencticateUser_WhereThereIsNotAnyUserInDb_ShouldReturnNull(string username, string password)
        {
            var query = new AuthenticateQuery(username, password);

            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("user", "password")]
        [InlineData(null, "password")]
        public async void AuthencticateUser_WhereUsernameIsNotCorrect_ShouldReturnNull(string username, string password)
        {
            var query = new AuthenticateQuery(username, password);

            _passwordHelperMock.VerifyPassword(default, default, default).ReturnsForAnyArgs(true);
            _userRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = "somethingelse", Password = query.Password } });

            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("user", "password")]
        [InlineData("user", null)]
        public async void AuthencticateUser_WherePasswordIsNotCorrect_ShouldReturnNull(string username, string password)
        {
            var query = new AuthenticateQuery(username, password);

            _passwordHelperMock.VerifyPassword(default, default, default).ReturnsForAnyArgs(false);
            _userRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = query.Username, Password = query.Password } });

            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.Null(result);
        }
    }
}
