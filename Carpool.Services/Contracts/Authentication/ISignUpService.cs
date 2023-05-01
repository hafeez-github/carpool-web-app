using System;
using Carpool.Models.ServiceModels;
using Carpool.Models.ServiceModels.Authentication;
using Carpool.Utilities;

namespace Carpool.Services.Contracts.Authentication
{
	public interface ISignUpService
	{
        Task<User> SignUp(SignUp model);
    }
}