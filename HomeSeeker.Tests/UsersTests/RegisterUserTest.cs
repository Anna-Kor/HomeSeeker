using FluentAssertions;

using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Commands;
using HomeSeeker.API.Commands.UserCommands;
using HomeSeeker.API.Models;
using HomeSeeker.API.Models.CustomResults;
using HomeSeeker.API.Repositories.UserRepositories;

using NSubstitute;

namespace HomeSeeker.Tests.UsersTests
{
    public class RegisterUserTest
    {
        public static IEnumerable<object[]> Data =>
           new List<object[]>
           {
                new object[] { new RegisterUserCommand("name", "lastName", "user1", "password") }
           };

        private readonly IUserRepository _userRepositoryMock;
        private readonly IPasswordHelper _passwordHelperMock;

        public RegisterUserTest()
        {
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _passwordHelperMock = Substitute.For<IPasswordHelper>();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void RegisterUser_WhereDataAreCorrect_ShouldReturnOk(RegisterUserCommand command)
        {
            var handler = new UsersCommandHandler(_userRepositoryMock, _passwordHelperMock);

            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            result.Success.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void RegisterUser_WhereUsernameExists_ShouldReturnError(RegisterUserCommand command)
        {
            _userRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = command.Username } });
            var handler = new UsersCommandHandler(_userRepositoryMock, _passwordHelperMock);

            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<OperationResult>(result);
            result.Success.Should().BeFalse();
        }
    }
}
