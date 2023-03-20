using System;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models.Authentication;
using Carpool.Services.Interfaces.Authentication;
using Carpool.Utilities;
using Carpool.Utilities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carpool.Services.AuthenticationServices
{
	public class LogInService:ILogInService
	{
        private readonly ApplicationDbContext dbContext;
        public LogInService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        public async Task<User> LogIn(LogIn model)
        {
            try
            {
                if (!String.IsNullOrEmpty(model.Username))
                {
                    User user = await dbContext.Users.SingleOrDefaultAsync(n => n.Username == model.Username);

                    if (user == null)
                    {
                        throw new Exception("Error! Incorect Username.");
                    }

                    else 
                    {
                        return VerifyPassword(model, user);
                    }
                }

                else if (!String.IsNullOrEmpty(model.Email))
                {
                    User user = await dbContext.Users.SingleOrDefaultAsync(n => n.Email == model.Email);

                    if (user == null)
                    {
                        throw new Exception("Error! Incorect Email.");
                    }
                    else
                    {
                        return VerifyPassword(model, user);
                    }
                }

                else
                {
                    throw new Exception("Error! Username(or Email) cannot be empty");
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        //helper function
        private User VerifyPassword(LogIn model, User user)
        {
            if (model.Password == user.Password)
            {
                return user;
            }

            else
            {
                Exception ex = new Exception("Error! Incorect Password.");
                throw ex;
            }

        }

    }
}

