using Carpool.Models.Authentication;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces.Authentication;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ILogInService logInService;
        private ISignUpService signUpService;

        public AuthenticationController(ILogInService logInService, ISignUpService signUpService)
        {
            this.logInService = logInService;
            this.signUpService = signUpService;
        }

        
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn(LogIn model)
        {
            ApiResponse<string> response=new ApiResponse<string>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Succesful Login";
                response.Data = await this.logInService.LogIn(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successful SignUp";
                response.Data = await this.signUpService.SignUp(model);
                return Ok(response);
            }
            catch(Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
                return BadRequest(response);
            }

            
        }
    }
}
