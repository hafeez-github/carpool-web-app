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
    public class LocationController : ControllerBase
    {
        private ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationRequest location)
        {
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();

            try
            {
                response = new(201, "Success", true);
                response.Message = "Location succesfully added";
                response.Data = await this.locationService.AddLocation(location);
                return Ok(response);
            }

            catch(Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition" + ex.Message;
                response.Data = null;
                return BadRequest(response);
            }

            
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ApiResponse<IEnumerable<LocationModel>> response=new ApiResponse<IEnumerable<LocationModel>>();

            try
            {
                response = new (200, "Success", true);
                response.Message = "Successfully fetched locations";
                response.Data = await this.locationService.GetLocations();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new (404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of locations;\n{ex.Message}";
                response.Data = null;

                return BadRequest(response);

            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched location";
                response.Data = await this.locationService.GetLocation(id);

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
                response.Message = "Error! Unsucceful retrieval of location";
                response.Data = null;

                return NotFound(response);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] LocationRequest editedLocation)
        {
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated location";
                response.Data = await this.locationService.UpdateLocation(id, editedLocation);

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
                response.Message = "Error! Unsuccessful edit of the existing location";
                response.Data = null;

                return NotFound(response);
            }

            
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted location";
                response.Data = await this.locationService.DeleteLocation(id);

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
                response.Message = "Error! Unsuccessful deletion of the existing location";
                response.Data = null;

                return NotFound(response);
            }

            
        }
    }
}
