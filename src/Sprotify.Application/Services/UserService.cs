using System;
using System.Threading.Tasks;
using Sprotify.DAL;
using Sprotify.Domain.Models;
using Sprotify.Domain.Repositories;
using Sprotify.Domain.Services;

namespace Sprotify.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UnitOfWork _unitOfWork;

        public UserService(
            IUserRepository userRepository,
            UnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<User> GetUserById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<User> RegisterUser(Guid id, string name)
        {
            var user = new User(id, name);
            _userRepository.Create(user);
            await _unitOfWork.SaveChanges().ConfigureAwait(false);

            return user;
        }
    }
}