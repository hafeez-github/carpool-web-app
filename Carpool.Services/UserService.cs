using System;
using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Data;
using db=Carpool.Data.DbModels;
using Carpool.Services.Contracts;
using Carpool.Utilities;
using Carpool.Models.ServiceModels;

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
        public async Task<User> AddUser(User newUser)
        {
            try
            {
                db.User user = this.mapper.Map<db.User>(newUser);
             
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<User>(user);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        //Get All
        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                List<db.User> users = dbContext.Users.Select(u=>u).ToList();
                List<User> userModels = this.mapper.Map<List<User>>(users);
                return userModels;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get by Id
        public async Task<User> GetUser(int id)
        {
            try
            {
                db.User user = await dbContext.Users.FindAsync(id);
                if (user == null)
                {
                    throw new DataNotFoundException("The required user doesn't exist");
                }
                return this.mapper.Map<User>(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update
        public async Task<User> UpdateUser(User editedUser)
        {
            try
            {
                db.User user = await dbContext.Users.FindAsync(editedUser.Id);

                if (user == null)
                {
                    throw new DataNotFoundException("User corresponding to specified ID doesn't exist");
                }
                user =this.mapper.Map(editedUser, user);
                await dbContext.SaveChangesAsync();
                User result = this.mapper.Map<User>(user);

                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        //Delete
        public async Task<User> DeleteUser(int id)
        {
            try
            {
                db.User user = dbContext.Users.Find(id);
                if (user==null)
                {
                    throw new DataNotFoundException("User corresponding to specified id doesn't exist");
                }
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
                return this.mapper.Map<User>(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

