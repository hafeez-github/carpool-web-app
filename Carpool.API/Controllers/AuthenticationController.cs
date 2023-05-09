using Carpool.API.ViewModels.Authentication;
using Carpool.API.ViewModels.ResponseModels;
using Carpool.Services.Contracts.Authentication;
using services=Carpool.Models.ServiceModels.Authentication;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Carpool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ILogInService logInService;
        private ISignUpService signUpService;
        private readonly IMapper mapper;

        public AuthenticationController(ILogInService logInService, ISignUpService signUpService, IMapper mapper)
        {
            this.logInService = logInService;
            this.signUpService = signUpService;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn(LogIn model)
        {
            ApiResponse<string> response=new ApiResponse<string>();
            services.LogIn login=this.mapper.Map<services.LogIn>(model);
            try
            {
                response = new(200, "Success", true);
                response.Message = "Succesful Login";
                response.Data = await this.logInService.LogIn(login);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            ApiResponse<UserResponse> response=new ApiResponse<UserResponse>();
            services.SignUp signup = this.mapper.Map<services.SignUp>(model);
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successful SignUp";
                response.Data = this.mapper.Map<UserResponse>(await this.signUpService.SignUp(signup));
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
