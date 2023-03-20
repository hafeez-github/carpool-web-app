using System;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class UserTypeService:IUserTypeService
	{
        private readonly ApplicationDbContext dbContext;

        public UserTypeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Post
        public async Task<UserType> AddUserType(UserTypeRequest newUserType)
        {
            try
            {
                UserType userType = new UserType()
                {
                    Type = newUserType.Type
                };

                await dbContext.UserTypes.AddAsync(userType);
                await dbContext.SaveChangesAsync();
                return userType;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Get All
        public async Task<IEnumerable<UserType>> GetUserTypes()
        {
            
            try
            {
                return dbContext.UserTypes;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Get by Id
        public async Task<UserType> GetUserType(int id)
        {
            try
            {
                UserType userType=dbContext.UserTypes.Find(id);
                if (userType == null)
                {
                    throw new DataNotFoundException("The required userType doesn't exist");
                }
                return userType;
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
        public async Task<UserType> UpdateUserType(int id, UserTypeRequest editedUserType)
        {
            ApiResponse<UserType> response;

            try
            {
                UserType userType = dbContext.UserTypes.Find(id);
                if (userType == null)
                {
                    throw new DataNotFoundException("UserType corresponding to specified id doesn't exist");
                }
                userType.Type = editedUserType.Type;

                await dbContext.SaveChangesAsync();
                return userType;
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


        //Delete
        public async Task<UserType> DeleteUserType(int id)
        {
            ApiResponse<UserType> response;

            try
            {
                UserType userType = await dbContext.UserTypes.FindAsync(id);
                if (userType == null)
                {
                    throw new DataNotFoundException("UserType corresponding to specified id doesn't exist");
                }

                dbContext.UserTypes.Remove(userType);
                await dbContext.SaveChangesAsync();
                return userType;
                
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

