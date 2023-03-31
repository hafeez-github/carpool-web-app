using System;
using Carpool.Models.Authentication;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces.Authentication
{
	public interface ISignUpService
	{
        Task<UserModel> SignUp(SignUp model);
    }
}