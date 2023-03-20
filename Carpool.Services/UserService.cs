using System;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class UserService:IUserService
	{
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Post
        public async Task<User> AddUser(UserRequest newUser)
        {
            try
            {
                User user = new User()
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Username = newUser.Username,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    UserType= newUser.UserType,
                    Mobile= newUser.Mobile,
                    IsActive= newUser.IsActive
                };

                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        //Get All
        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return dbContext.Users;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Get by Id
        public async Task<User> GetUser(int id)
        {
            try
            {
                
                User user = await dbContext.Users.FindAsync(id);
                if (user == null)
                {
                    throw new DataNotFoundException("The required user doesn't exist");
                }
                return user;
            }
            catch (DataNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Update
        public async Task<User> UpdateUser(int id, UserRequest editedUser)
        {
            

            try
            {
                User user = await dbContext.Users.FindAsync(id);

                if (user == null)
                {
                    throw new DataNotFoundException("User corresponding to specified id doesn't exist");
                }

                user.FirstName = editedUser.FirstName;
                user.LastName = editedUser.LastName;
                user.Username = editedUser.Username;
                user.Email = editedUser.Email;
                user.Password = editedUser.Password;
                user.Mobile = editedUser.Mobile;
                user.UserType = editedUser.UserType;
                user.IsActive = editedUser.IsActive;

                await dbContext.SaveChangesAsync();

                return user;

            }

            catch (DataNotFoundException ex)
            {
                throw ex;
            }

            catch(Exception ex)
            {
                throw ex;
            }

        }


        //Delete
        public async Task<User> DeleteUser(int id)
        {
            ApiResponse<User> response;

            try
            {
                User user = dbContext.Users.Find(id);
                if (user==null)
                {
                    throw new DataNotFoundException("User corresponding to specified id doesn't exist");
                }

                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
                return user;

            }

            catch (DataNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

