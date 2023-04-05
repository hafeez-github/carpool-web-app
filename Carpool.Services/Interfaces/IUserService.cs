using System;
using Carpool.Models;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserModel> AddUser(UserRequest user);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(int id);
        Task<UserModel> UpdateUser(UserModel editedUser);
        Task<UserModel> DeleteUser(int id);

    }
}

