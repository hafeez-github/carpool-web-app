using System;
using System.Security.Claims;
using Carpool.Models.ServiceModels;

namespace Carpool.API.User
{
    public class UserContextBuilder
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private UserContext Context;

        public UserContextBuilder(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public UserContext BuildContext()
        {
            UserContext user = new UserContext();
            user.Id = Convert.ToInt32(this.httpContextAccessor.HttpContext.User.FindFirst("id").Value);
            user.FirstName = this.httpContextAccessor.HttpContext.User.FindFirst("firstName").Value;
            user.LastName = this.httpContextAccessor.HttpContext.User.FindFirst("lastName").Value;
            user.Username = this.httpContextAccessor.HttpContext.User.FindFirst("username").Value;
            user.Mobile = this.httpContextAccessor.HttpContext.User.FindFirst("mobile").Value;
            user.IsActive = Convert.ToBoolean(this.httpContextAccessor.HttpContext.User.FindFirst("isActive").Value);

            return user;
        }
    }
}
