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
        public ApiResponse<User> AddUser(UserRequest newUser)
        {
            ApiResponse<User> response;

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

                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = user;

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
        public ApiResponse<IEnumerable<User>> GetUsers()
        {
            ApiResponse<IEnumerable<User>> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched users";
                response.Data = dbContext.Users;

            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of users;\n{ex.Message}";
                response.Data = null;
            }

            return response;
        }

        //Get by Id
        public ApiResponse<User> GetUser(int id)
        {
            ApiResponse<User> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched user";
                response.Data = dbContext.Users.Find(id);
                if (response.Data == null)
                {
                    throw new DataNotFoundException("The required user doesn't exist");
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
                response.Message = "Error! Unsucceful retrieval of user";
                response.Data = null;
            }

            return response;
        }

        //Update
        public ApiResponse<User> UpdateUser(int id, UserRequest editedUser)
        {
            ApiResponse<User> response;

            try
            {
                User user = dbContext.Users.Find(id);
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

                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully updated user";
                response.Data = user;
            }

            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! "+ ex.Message;
                response.Data = null;
            }

            catch(Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful edit of the existing user";
                response.Data = null;
            }

            return response;
        }


        //Delete
        public ApiResponse<User> DeleteUser(int id)
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
                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully deleted user";
                response.Data = user;
            }

            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! "+ ex.Message;
                response.Data = null;
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful deletion of the existing user";
                response.Data = null;
            }

            return response;
        }


    }
}

