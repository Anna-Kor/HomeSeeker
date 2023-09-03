﻿using Data.Enums;
using Data.Models;

using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Commands.UserCommands;
using HomeSeeker.API.Models;
using HomeSeeker.API.Models.CustomResults;
using HomeSeeker.API.Repositories;

using MediatR;

using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Commands
{
    public class UsersCommandHandler : IRequestHandler<RegisterUserCommand, OperationResult>
    {
        private readonly IGetRepositoryBase<UserModel> _getUserRepository;
        private readonly IEntityOperationsRepositoryBase<User> _userOperationsRepository;
        private readonly IPasswordHelper _passwordHelper;

        public UsersCommandHandler(IGetRepositoryBase<UserModel> getUserRepository, IEntityOperationsRepositoryBase<User> userOperationsRepository, IPasswordHelper passwordHelper)
        {
            _getUserRepository = getUserRepository;
            _userOperationsRepository = userOperationsRepository;
            _passwordHelper = passwordHelper;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUsers = await _getUserRepository.GetAll(cancellationToken);

            if (existingUsers != null && existingUsers.Any(user => user.Username == request.Username))
            {
                return OperationResult.FailureResult("Username already exists.");
            }

            var hashedPassword = _passwordHelper.HashPassword(request.Password, out var salt);
            var user = new User { FirstName = request.FirstName, LastName = request.LastName, Role = Role.User, Username = request.Username, Password = hashedPassword, Salt = salt };
            await _userOperationsRepository.Add(user);
            return OperationResult.SuccessResult();
        }
    }
}
