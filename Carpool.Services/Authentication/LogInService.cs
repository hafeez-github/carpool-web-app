using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Carpool.Data;
using db = Carpool.Data.DbModels;
using Carpool.Services.Contracts.Authentication;
using Carpool.Models.ServiceModels.Authentication;
using Carpool.Utilities;
using Carpool.Utilities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace Carpool.Services.AuthenticationServices
{
    public class LogInService : ILogInService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public LogInService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<string> LogIn(LogIn model)
        {
            try
            {
                db.User user = await this.dbContext.Users.FirstOrDefaultAsync(n => n.Email == model.Email);

                if (user == null)
                {
                    throw new Exception("Error! Incorrect Email");
                }
                else
                {
                    if (VerifyPassword(model, user) == true)
                    {
                        return CreateJWT(user);
                    }

                    throw new Exception("Error! Incorrect Password");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //helper function
        private Boolean VerifyPassword(LogIn model, db.User user)
        {
            if (Carpool.Utilities.Classes.PasswordEncryption.CheckPassword(model.Password, user.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper function
        private string CreateJWT(db.User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");

            List<Claim> claims = new List<Claim>
            {
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("email", user.Email),
                new Claim("mobile", user.Mobile),
                new Claim("password", user.Password),
                new Claim("username", user.Username),
                new Claim("isActive", user.IsActive.ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim("type", user.Type.ToString())
            };

            var identity = new ClaimsIdentity(claims);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}

