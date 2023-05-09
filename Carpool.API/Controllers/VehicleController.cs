using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Services.Contracts;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services = Carpool.Models.ServiceModels;
using Carpool.API.ViewModels.RequestModels;
using Carpool.API.ViewModels.ResponseModels;

namespace Carpool.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleService vehicleService;
        private readonly IMapper mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<VehicleResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(VehicleRequest model)
        {
            ApiResponse<VehicleResponse> response=new ApiResponse<VehicleResponse>();
            services.Vehicle vehicle = this.mapper.Map<services.Vehicle>(model);
            try
            {
                response = new(201, "Success", true);
                response.Message = "Vehicle succesfully added";
                response.Data = this.mapper.Map<VehicleResponse>(await this.vehicleService.AddVehicle(vehicle));

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IEnumerable<VehicleResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ApiResponse<IEnumerable<VehicleResponse>> response=new ApiResponse<IEnumerable<VehicleResponse>>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicles";
                response.Data = this.mapper.Map<IEnumerable<VehicleResponse>>(await this.vehicleService.GetVehicles());

                return Ok(response);
            }

            catch (Exception ex)
            {
                throw;
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<VehicleResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ApiResponse<VehicleResponse> response=new ApiResponse<VehicleResponse>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicle";
                response.Data = this.mapper.Map<VehicleResponse>(await this.vehicleService.GetVehicle(id));

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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<VehicleResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] VehicleRequest model)
        {
            ApiResponse<VehicleResponse> response=new ApiResponse<VehicleResponse>();
            services.Vehicle editedVehicle = this.mapper.Map<services.Vehicle>(model);

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated vehicle";
                response.Data = this.mapper.Map<VehicleResponse>(await this.vehicleService.UpdateVehicle(id, editedVehicle));

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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<VehicleResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            ApiResponse<VehicleResponse> response=new ApiResponse<VehicleResponse>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted vehicle";
                response.Data = this.mapper.Map<VehicleResponse>(await this.vehicleService.DeleteVehicle(id));

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
