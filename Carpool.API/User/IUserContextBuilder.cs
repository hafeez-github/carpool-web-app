using System;
using Carpool.Models.ServiceModels;

namespace Carpool.API.User
{
    public interface IUserContextBuilder
    {
        UserContext BuildContext();
    }
}

