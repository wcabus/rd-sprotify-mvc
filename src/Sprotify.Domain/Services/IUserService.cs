using System;
using System.Threading.Tasks;
using Sprotify.Domain.Models;

namespace Sprotify.Domain.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid id);

        Task<User> RegisterUser(Guid id, string name);
    }
}