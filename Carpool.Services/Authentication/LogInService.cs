using System;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models.Authentication;
using Carpool.Services.Interfaces.Authentication;
using Carpool.Utilities;
using Carpool.Utilities.Interfaces;

namespace Carpool.Services.AuthenticationServices
{
	public class LogInService:ILogInService
	{
        private readonly ApplicationDbContext dbContext;
        public LogInService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        public ApiResponse<User> LogIn(LogIn model)
        {
            ApiResponse<User> response = new();

            try
            {
                if (!String.IsNullOrEmpty(model.Username))
                {
                    User user = dbContext.Users.SingleOrDefault(n => n.Username == model.Username);

                    if (user == null)
                    {
                        response = new(400, "Failure", false);
                        response.Message = "Error! Incorect Username.";
                        response.Data = null;
                    }

                    else 
                    {
                        response=VerifyPassword(model, user, response);
                    }
                }

                else if (!String.IsNullOrEmpty(model.Email))
                {
                    User user = dbContext.Users.SingleOrDefault(n => n.Email == model.Email);

                    if (user == null)
                    {
                        response = new(400, "Failure", false);
                        response.Message = "Error! Incorect Email.";
                        response.Data = null;
                    }
                    else
                    {
                        response= VerifyPassword(model, user, response);
                    }
                }

                else
                {
                    response = new(400, "Failure", false);
                    response.Message = "Error! Username(or Email) cannot be empty";
                    response.Data = null;
                }

            }

            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            return response;
        }


        //helper function
        private ApiResponse<User> VerifyPassword(LogIn model, User user, ApiResponse<User> response)
        {
            if (model.Password == user.Password)
            {
                response = new(200, "Success", true);
                response.Message = "Successful LogIn";
                response.Data = user;
            }

            else
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Incorect Password.";
                response.Data = null;
            }

            return response;
        }

    }
}

