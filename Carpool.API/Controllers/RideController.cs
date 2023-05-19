using AutoMapper;
using Carpool.API.ViewModels.RequestModels;
using Carpool.API.ViewModels.ResponseModels;
using Carpool.Services.Contracts;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services = Carpool.Models.ServiceModels;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private IRideService rideService;
        private readonly IMapper mapper;

        public RideController(IRideService rideService, IMapper mapper)
        {
            this.rideService = rideService;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<RideResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(RideRequest model)
        {
            ApiResponse<RideResponse> response = new ApiResponse<RideResponse>();
            services.Ride ride = this.mapper.Map<services.Ride>(model);
            try
            {
                response = new(201, "Success", true);
                response.Message = "Ride sucessfully added.";
                response.Data = this.mapper.Map<RideResponse>(await this.rideService.AddRideDetails(ride));

                return Ok(response);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
