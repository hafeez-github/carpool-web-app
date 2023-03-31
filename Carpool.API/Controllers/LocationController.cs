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
        public async Task<ApiResponse<LocationModel>> Post(LocationRequest location)
        {
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();

            try
            {
                response = new(201, "Success", true);
                response.Message = "Location succesfully added";
                response.Data = await this.locationService.AddLocation(location);
            }

            catch(Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition" + ex.Message;
                response.Data = null;
            }

            return response;
        }


        [HttpGet]
        public async Task<ApiResponse<IEnumerable<LocationModel>>> Get()
        {
            ApiResponse<IEnumerable<LocationModel>> response=new ApiResponse<IEnumerable<LocationModel>>();

            try
            {
                response = new (200, "Success", true);
                response.Message = "Successfully fetched locations";
                response.Data = await this.locationService.GetLocations();
            }
            catch (Exception ex)
            {
                response = new (404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of locations;\n{ex.Message}";
                response.Data = null;
            }

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResponse<LocationModel>> Get([FromRoute] int id)
        {
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched location";
                response.Data = await this.locationService.GetLocation(id);
            }
            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsucceful retrieval of location";
                response.Data = null;
            }
            return response;
        }

        [HttpPut("{id:int}")]
        public async Task<ApiResponse<LocationModel>> Put([FromRoute] int id, [FromBody] LocationRequest editedLocation)
        {
            
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated location";
                response.Data = await this.locationService.UpdateLocation(id, editedLocation);
            }
            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful edit of the existing location";
                response.Data = null;
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ApiResponse<LocationModel>> Delete([FromRoute] int id)
        {
            ApiResponse<LocationModel> response=new ApiResponse<LocationModel>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted location";
                response.Data = await this.locationService.DeleteLocation(id);
            }
            catch (DataNotFoundException ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful deletion of the existing location";
                response.Data = null;
            }

            return response;
        }
    }
}
