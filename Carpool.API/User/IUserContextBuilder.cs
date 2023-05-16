using System;
namespace Carpool.API.User
{
	public interface IUserContextBuilder
	{
        UserContext BuildContext();
    }
}

