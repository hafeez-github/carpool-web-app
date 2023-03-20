using System;
using Carpool.Data.Entities;
using Carpool.Models.Authentication;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces.Authentication
{
	public interface ISignUpService
	{
        Task<User> SignUp(SignUp model);
    }
}

