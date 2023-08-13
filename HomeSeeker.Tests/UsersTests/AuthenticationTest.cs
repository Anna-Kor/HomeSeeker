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
        public static IEnumerable<object[]> Data =>
          new List<object[]>
          {
                new object[] { new AuthenticateQuery("user", "password") }
          };

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
        [MemberData(nameof(Data))]
        public async void AuthencticateUser_WhereUsernameAndPasswordIsCorrect_ShouldReturnOk(AuthenticateQuery query)
        {
            _passwordHelperMock.VerifyPassword(default, default, default).ReturnsForAnyArgs(true);
            _userRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = query.Username, Password = query.Password } });
            
            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void AuthencticateUser_WhereThereIsNotAnyUserInDb_ShouldReturnNull(AuthenticateQuery query)
        {  
            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.Null(result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void AuthencticateUser_WhereUsernameIsNotCorrect_ShouldReturnNull(AuthenticateQuery query)
        {
            _passwordHelperMock.VerifyPassword(default, default, default).ReturnsForAnyArgs(true);
            _userRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = query.Username + "somethingelse", Password = query.Password } });

            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.Null(result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void AuthencticateUser_WherePasswordIsNotCorrect_ShouldReturnNull(AuthenticateQuery query)
        {
            _passwordHelperMock.VerifyPassword(default, default, default).ReturnsForAnyArgs(false);
            _userRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = query.Username, Password = query.Password } });

            var handler = new UsersQueryHandler(_userRepositoryMock, _jwtUtils, _passwordHelperMock);

            var result = await handler.Handle(query, default);

            Assert.Null(result);
        }
    }
}
