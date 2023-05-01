using System;
using Carpool.Data.DbModels;
using Carpool.Utilities;
using Carpool.Models.ServiceModels.Authentication;

namespace Carpool.Services.Contracts.Authentication
{
	public interface ILogInService
	{
        Task<string> LogIn(LogIn model);
        string CreateJWT(User user);
        string VerifyPassword(LogIn model, User user);
    }
}

