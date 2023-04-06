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
        public async Task<IActionResult> Post(UserRequest user)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();

            try
            {
                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = await this.userService.AddUser(user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition";
                response.Data = null;

                return BadRequest(response);
            }

            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ApiResponse<IEnumerable<UserModel>> response= new ApiResponse<IEnumerable<UserModel>>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched users";
                response.Data = await this.userService.GetUsers();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of users;\n{ex.Message}";
                response.Data = null;

                return BadRequest(response);
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched user";
                response.Data = await this.userService.GetUser(id);

                return Ok(response);
            }
            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsucceful retrieval of user";
                response.Data = null;

                return BadRequest(response);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel editedUser)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated user";
                response.Data = await this.userService.UpdateUser(editedUser);

                return Ok(response);

            }
            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful edit of the existing user";
                response.Data = null;

                return NotFound(response);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted user";
                response.Data = await this.userService.DeleteUser(id);

                return Ok(response);
            }
            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful deletion of the existing user";
                response.Data = null;

                return NotFound(response);
            }

        }

    }
}
