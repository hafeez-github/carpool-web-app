using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IUserService
	{
		ApiResponse<User> AddUser(UserRequest user);
        ApiResponse<IEnumerable<User>> GetUsers();
        ApiResponse<User> GetUser(int id);
        ApiResponse<User> UpdateUser(int id, UserRequest editedUser);
        ApiResponse<User> DeleteUser(int id);

    }
}

