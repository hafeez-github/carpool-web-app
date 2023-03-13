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
        public ApiResponse<UserType> AddUserType(UserTypeRequest newUserType)
        {
            ApiResponse<UserType> response;

            try
            {
                UserType userType = new UserType()
                {
                    Type = newUserType.Type
                };

                dbContext.UserTypes.Add(userType);
                dbContext.SaveChanges();

                response = new(201, "Success", true);
                response.Message = "UserType succesfully added";
                response.Data = userType;

            }
            catch
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition";
                response.Data = null;
            }
            return response;
        }

        //Get All
        public ApiResponse<IEnumerable<UserType>> GetUserTypes()
        {
            ApiResponse<IEnumerable<UserType>> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched userTypes";
                response.Data = dbContext.UserTypes;

            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of userTypes;\n{ex.Message}";
                response.Data = null;
            }

            return response;
        }

        //Get by Id
        public ApiResponse<UserType> GetUserType(int id)
        {
            ApiResponse<UserType> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched userType";
                response.Data = dbContext.UserTypes.Find(id);
                if (response.Data == null)
                {
                    throw new DataNotFoundException("The required userType doesn't exist");
                }
            }
            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsucceful retrieval of userType";
                response.Data = null;
            }

            return response;
        }

        //Update
        public ApiResponse<UserType> UpdateUserType(int id, UserTypeRequest editedUserType)
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

                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully updated userType";
                response.Data = userType;
            }

            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful edit of the existing userType";
                response.Data = null;
            }

            return response;
        }


        //Delete
        public ApiResponse<UserType> DeleteUserType(int id)
        {
            ApiResponse<UserType> response;

            try
            {
                UserType userType = dbContext.UserTypes.Find(id);
                if (userType == null)
                {
                    throw new DataNotFoundException("UserType corresponding to specified id doesn't exist");
                }

                dbContext.UserTypes.Remove(userType);
                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully deleted userType";
                response.Data = userType;
            }

            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful deletion of the existing userType";
                response.Data = null;
            }

            return response;
        }
    }
}

