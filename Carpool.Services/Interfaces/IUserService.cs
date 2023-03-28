using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IUserService
	{
		Task<User> AddUser(UserRequest user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(int id, UserRequest editedUser);
        Task<User> DeleteUser(int id);

    }
}

