using System;
using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class UserService:IUserService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        //Post
        public async Task<UserModel> AddUser(UserRequest newUser)
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
                    Type= newUser.Type,
                    Mobile= newUser.Mobile,
                    IsActive= newUser.IsActive
                };
             
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<UserModel>(user);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        //Get All
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                List<User> users = dbContext.Users.Select(u=>u).ToList();
                List<UserModel> userModels = new List<UserModel>();
                foreach (User u in users)
                {
                    userModels.Add(this.mapper.Map<UserModel>(u));
                }

                return userModels;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Get by Id
        public async Task<UserModel> GetUser(int id)
        {
            try
            {
                
                User user = await dbContext.Users.FindAsync(id);
                if (user == null)
                {
                    throw new DataNotFoundException("The required user doesn't exist");
                }
                return this.mapper.Map<UserModel>(user);
            }
            catch (DataNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Update
        public async Task<UserModel> UpdateUser(UserModel editedUser)
        {
            try
            {
                User user = await dbContext.Users.FindAsync(editedUser.Id);

                if (user == null)
                {
                    throw new DataNotFoundException("User corresponding to specified ID doesn't exist");
                }

                user.Id = editedUser.Id;
                user.FirstName = editedUser.FirstName;
                user.LastName = editedUser.LastName;
                user.Username = editedUser.Username;
                user.Email = editedUser.Email;
                user.Password = editedUser.Password;
                user.Mobile = editedUser.Mobile;
                user.Type = editedUser.Type;
                user.IsActive = editedUser.IsActive;

                //user =this.mapper.Map<User>(editedUser);

                await dbContext.SaveChangesAsync();

                UserModel result = this.mapper.Map<UserModel>(user);

                return result;

            }

            catch (DataNotFoundException ex)
            {
                throw;
            }

            catch(Exception ex)
            {
                throw;
            }

        }


        //Delete
        public async Task<UserModel> DeleteUser(int id)
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
                return this.mapper.Map<UserModel>(user);

            }

            catch (DataNotFoundException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }

        }

      

    }
}

