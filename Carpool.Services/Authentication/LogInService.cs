using System;
using AutoMapper;
using Carpool.Data;
using Carpool.Models.Authentication;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces.Authentication;
using Carpool.Utilities;
using Carpool.Utilities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carpool.Services.AuthenticationServices
{
	public class LogInService:ILogInService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public LogInService(ApplicationDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserModel> LogIn(LogIn model)
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
                        User user1 = VerifyPassword(model, user);
                        return this.mapper.Map<UserModel>(user1);
                    }
                }

                else if (!String.IsNullOrEmpty(model.Email))
                {
                    User user = await dbContext.Users.FirstOrDefaultAsync(n => n.Email == model.Email);

                    if (user == null)
                    {
                        throw new Exception("Error! Incorect Email.");
                    }
                    else
                    {
                        return this.mapper.Map<UserModel>(VerifyPassword(model, user));
                    }
                }

                else
                {
                    throw new Exception("Error! Username(or Email) cannot be empty");
                }

            }

            catch (Exception ex)
            {
                throw;
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

