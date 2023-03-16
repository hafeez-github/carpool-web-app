using System;
using System.Linq;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models.Authentication;
using Carpool.Services.Interfaces.Authentication;
using Carpool.Utilities;

namespace Carpool.Services.Authentication
{
	public class SignUpService: ISignUpService
    {
        private readonly ApplicationDbContext dbContext;
        public SignUpService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApiResponse<User> SignUp(SignUp model)
        {
            ApiResponse<User> response;
            User user = new User()
            {
                Username = "defaultUsername",
                UserType = 3,
                IsActive=true,
                Mobile="defaultMobile",
                FirstName="defaultFirstName",
                LastName="defaultLastName"

            };

            try
            {

                if (String.IsNullOrEmpty(model.Email) && String.IsNullOrEmpty(model.Password))
                     //&& String.IsNullOrEmpty(model.Username)
                {
                    throw new Exception("Credentials can't be empty");
                }
               
                else
                {
                    if (!String.IsNullOrEmpty(model.Email))
                    {
                        user.Email = model.Email;
                        
                    }
                    else
                    {
                        throw new Exception("Email can't be empty");
                    }

                    if (!String.IsNullOrEmpty(model.Password))
                    {
                        user.Password = model.Password;
                        
                    }
                    else
                    {
                        throw new Exception("Password can't be empty");
                    }

                    //if (!String.IsNullOrEmpty(model.Username))
                    //{
                    //    var result=dbContext.Users.Where(n => n.Username == model.Username).ToList();
                    //    if (result.Count==0)
                    //    {
                    //        user.Username = model.Username;
                    //    }
                    //    else
                    //    {
                    //        throw new Exception("Username already exists. Try another one.");
                    //    }
                    //}
                    //else
                    //{
                    //    throw new Exception("Username can't be empty");
                    //}

                    response = new(200, "Success", true);
                    response.Message = "Successful SignUp";
                    response.Data = user;

                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
                
            }

            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }
            //Console.WriteLine(user);
            return response;
        }
    }
}

