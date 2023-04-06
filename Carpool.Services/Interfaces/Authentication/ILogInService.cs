using System;
using Carpool.Models;
using Carpool.Models.Authentication;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces.Authentication
{
	public interface ILogInService
	{
        Task<string> LogIn(LogIn model);
        string CreateJWT(User user);
        string VerifyPassword(LogIn model, User user);
    }
}

