using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Services.Contracts;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services = Carpool.Models.ServiceModels;
using Carpool.API.ViewModels.RequestModels;
using Carpool.API.ViewModels.ResponseModels;
using AutoMapper;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequest model)
        {
            ApiResponse<UserResponse> response=new ApiResponse<UserResponse>();
            services.User user = this.mapper.Map<services.User>(model);

            try
            {
                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = this.mapper.Map<UserResponse>(await this.userService.AddUser(user));

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ApiResponse<IEnumerable<UserResponse>> response= new ApiResponse<IEnumerable<UserResponse>>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched users";
                response.Data = this.mapper.Map<IEnumerable<UserResponse>>(await this.userService.GetUsers());

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ApiResponse<UserResponse> response=new ApiResponse<UserResponse>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched user";
                response.Data = this.mapper.Map<UserResponse>(await this.userService.GetUser(id));

                return Ok(response);
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserResponse model)
        {
            ApiResponse<UserResponse> response=new ApiResponse<UserResponse>();
            services.User editedUser = this.mapper.Map<services.User>(model);
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated user";
                response.Data = this.mapper.Map<UserResponse>(await this.userService.UpdateUser(editedUser));

                return Ok(response);
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            ApiResponse<UserResponse> response=new ApiResponse<UserResponse>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted user";
                response.Data = this.mapper.Map<UserResponse>(await this.userService.DeleteUser(id));

                return Ok(response);
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
