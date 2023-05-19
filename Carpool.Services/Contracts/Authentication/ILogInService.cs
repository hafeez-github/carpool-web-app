using System;
using Carpool.Data.DbModels;
using Carpool.Utilities;
using Carpool.Models.ServiceModels.Authentication;

namespace Carpool.Services.Contracts.Authentication
{
    public interface ILogInService
    {
        Task<Boolean> LogIn(LogIn model);
        Task<string> GetJWT(LogIn model);
    }
}

