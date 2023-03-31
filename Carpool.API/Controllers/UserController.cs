using Carpool.API.Exceptions;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;
using Carpool.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ApiResponse<UserModel>> Post(UserRequest user)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();

            try
            {
                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = await this.userService.AddUser(user);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition";
                response.Data = null;
            }

            return response;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<UserModel>>> Get()
        {
            ApiResponse<IEnumerable<UserModel>> response= new ApiResponse<IEnumerable<UserModel>>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched users";
                response.Data = await this.userService.GetUsers();
            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of users;\n{ex.Message}";
                response.Data = null;
            }
            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResponse<UserModel>> Get([FromRoute] int id)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched user";
                response.Data = await this.userService.GetUser(id);
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

        [HttpPut("{id:int}")]
        public async Task<ApiResponse<UserModel>> Put([FromRoute] int id, [FromBody] UserRequest editedUser)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated user";
                response.Data = await this.userService.UpdateUser(id, editedUser);
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
                response.Message = "Error! Unsuccessful edit of the existing user";
                response.Data = null;
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ApiResponse<UserModel>> Delete([FromRoute] int id)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted user";
                response.Data = await this.userService.DeleteUser(id);
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
                response.Message = "Error! Unsuccessful deletion of the existing user";
                response.Data = null;
            }

            return response;
        }

    }
}
