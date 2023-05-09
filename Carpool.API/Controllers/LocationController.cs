using Carpool.API.Exceptions;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services = Carpool.Models.ServiceModels;
using Carpool.API.ViewModels.RequestModels;
using Carpool.API.ViewModels.ResponseModels;
using Carpool.Services.Contracts;
using AutoMapper;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILocationService locationService;
        private readonly IMapper mapper;

        public LocationController(ILocationService locationService, IMapper mapper)
        {
            this.locationService = locationService;
            this.mapper = mapper;
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LocationResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationRequest model)
        {
            ApiResponse<LocationResponse> response=new ApiResponse<LocationResponse>();
            services.Location location = this.mapper.Map<services.Location>(model);
            try
            {
                response = new(201, "Success", true);
                response.Message = "Location succesfully added";
                response.Data = this.mapper.Map<LocationResponse>(await this.locationService.AddLocation(location));
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IEnumerable<LocationResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ApiResponse<IEnumerable<LocationResponse>> response=new ApiResponse<IEnumerable<LocationResponse>>();
            try
            {
                response = new (200, "Success", true);
                response.Message = "Successfully fetched locations";
                response.Data = this.mapper.Map<IEnumerable<LocationResponse>>(await this.locationService.GetLocations());

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LocationResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ApiResponse<LocationResponse> response=new ApiResponse<LocationResponse>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched location";
                response.Data = this.mapper.Map<LocationResponse>(await this.locationService.GetLocation(id));

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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LocationResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] LocationRequest model)
        {
            ApiResponse<LocationResponse> response=new ApiResponse<LocationResponse>();
            services.Location editedLocation = this.mapper.Map<services.Location>(model);
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated location";
                response.Data = this.mapper.Map<LocationResponse>(await this.locationService.UpdateLocation(id, editedLocation));

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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LocationResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            ApiResponse<LocationResponse> response=new ApiResponse<LocationResponse>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted location";
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
