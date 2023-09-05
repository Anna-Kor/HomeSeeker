using Data.Models;

using FluentAssertions;

using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Commands.UserCommands.RegisterUser;
using HomeSeeker.API.Models;
using HomeSeeker.API.Models.CustomResults;
using HomeSeeker.API.Repositories;

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

        private readonly IGetRepositoryBase<UserModel> _getUserRepositoryMock;
        private readonly IEntityOperationsRepositoryBase<User> _userOperationsRepositoryMock;
        private readonly IPasswordHelper _passwordHelperMock;

        public RegisterUserTest()
        {
            _getUserRepositoryMock = Substitute.For<IGetRepositoryBase<UserModel>>();
            _userOperationsRepositoryMock = Substitute.For<IEntityOperationsRepositoryBase<User>>();
            _passwordHelperMock = Substitute.For<IPasswordHelper>();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void RegisterUser_WhereDataAreCorrect_ShouldReturnOk(RegisterUserCommand command)
        {
            var handler = new RegisterUserCommandHandler(_getUserRepositoryMock, _userOperationsRepositoryMock, _passwordHelperMock);

            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            result.Success.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void RegisterUser_WhereUsernameExists_ShouldReturnError(RegisterUserCommand command)
        {
            _getUserRepositoryMock.GetAll(default).ReturnsForAnyArgs(new List<UserModel> { new UserModel { Username = command.Username } });
            var handler = new RegisterUserCommandHandler(_getUserRepositoryMock, _userOperationsRepositoryMock, _passwordHelperMock);

            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<OperationResult>(result);
            result.Success.Should().BeFalse();
        }
    }
}
