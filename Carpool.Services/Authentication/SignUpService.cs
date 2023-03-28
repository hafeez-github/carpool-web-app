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

        public async Task<User> SignUp(SignUp model)
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
                    
                    await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync();

                    return user;
                }
                
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

