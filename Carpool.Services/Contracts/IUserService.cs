using System;
using Carpool.Models.ServiceModels;

namespace Carpool.Services.Contracts
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User editedUser);
        Task<User> DeleteUser(int id);

    }
}

