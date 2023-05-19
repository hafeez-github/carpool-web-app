using System;
using System.Linq;
using AutoMapper;
using Carpool.Data;
using db = Carpool.Data.DbModels;
using Carpool.Services.Contracts.Authentication;
using Carpool.Models.ServiceModels;
using Carpool.Models.ServiceModels.Authentication;
using Carpool.Utilities;
using Carpool.Utilities.Classes;
using Carpool.Utilities.Enums;

namespace Carpool.Services.Authentication
{
    public class SignUpService : ISignUpService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public SignUpService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<User> SignUp(SignUp model)
        {
            db.User user = new db.User()
            {
                Username = "defaultUsername",
                Type = UserType.AppUser,
                IsActive = true,
                Mobile = "defaultMobile",
                FirstName = "defaultFirstName",
                LastName = "defaultLastName"

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
                        user.Password = PasswordEncryption.EncryptPassword(model.Password);
                    }
                    else
                    {
                        throw new Exception("Password can't be empty");
                    }

                    await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync();

                    return this.mapper.Map<User>(user);
                }

            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

