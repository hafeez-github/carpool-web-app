using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Models.Authentication;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces.Authentication
{
	public interface ILogInService
	{
        ApiResponse<User> LogIn(LogIn model);

    }
}

