using Carpool.Models.Authentication;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces.Authentication;
using Carpool.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Controllers
{
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
        public async Task<ApiResponse<UserModel>> LogIn(LogIn model)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Succesful Login";
                response.Data = await this.logInService.LogIn(model);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            return response;
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse<UserModel>> SignUp(SignUp model)
        {
            ApiResponse<UserModel> response=new ApiResponse<UserModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successful SignUp";
                response.Data = await this.signUpService.SignUp(model);
            }
            catch(Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            return response;
        }
    }
}
