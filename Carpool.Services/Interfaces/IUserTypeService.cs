using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IUserTypeService
	{
        Task<UserType> AddUserType(UserTypeRequest userType);
        Task<IEnumerable<UserType>> GetUserTypes();
        Task<UserType> GetUserType(int id);
        Task<UserType> UpdateUserType(int id, UserTypeRequest editedUserType);
        Task<UserType> DeleteUserType(int id);
    }
}

