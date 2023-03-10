using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IUserTypeService
	{
        ApiResponse<UserType> AddUserType(UserTypeRequest userType);
        ApiResponse<IEnumerable<UserType>> GetUserTypes();
        ApiResponse<UserType> GetUserType(int id);
        ApiResponse<UserType> UpdateUserType(int id, UserTypeRequest editedUserType);
        ApiResponse<UserType> DeleteUserType(int id);
    }
}

