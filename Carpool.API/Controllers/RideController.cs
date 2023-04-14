using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private IRideService rideService;

        public RideController(IRideService rideService)
        {
            this.rideService = rideService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RideRequest ride)
        {
            ApiResponse<RideModel> response=new ApiResponse<RideModel>();
            try
            {
                response = new(201, "Success", true);
                response.Message = "Ride sucessfully added.";
                response.Data = await this.rideService.AddRideDetails(ride);

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

    }
}
