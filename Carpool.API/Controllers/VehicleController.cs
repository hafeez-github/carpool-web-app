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
    public class VehicleController : ControllerBase
    {
        private IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpPost]
        public async Task<ApiResponse<VehicleModel>> Post(VehicleRequest vehicle)
        {
            ApiResponse<VehicleModel> response=new ApiResponse<VehicleModel>();

            try
            {
                response = new(201, "Success", true);
                response.Message = "Vehicle succesfully added";
                response.Data = await this.vehicleService.AddVehicle(vehicle);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition.\n" + ex.Message;
                response.Data = null;
            }
            return response;

        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<VehicleModel>>> Get()
        {
            ApiResponse<IEnumerable<VehicleModel>> response=new ApiResponse<IEnumerable<VehicleModel>>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicles";
                response.Data = await this.vehicleService.GetVehicles();
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of vehicles;\n{ex.Message}";
                response.Data = null;
            }

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResponse<VehicleModel>> Get([FromRoute] int id)
        {
            ApiResponse<VehicleModel> response=new ApiResponse<VehicleModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicle";
                response.Data = await this.vehicleService.GetVehicle(id);
                
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
                response.Message = "Error! Unsucceful retrieval of vehicle";
                response.Data = null;
            }

            return response;

        }

        [HttpPut("{id:int}")]
        public async Task<ApiResponse<VehicleModel>> Put([FromRoute] int id, [FromBody] VehicleRequest editedVehicle)
        {
            ApiResponse<VehicleModel> response=new ApiResponse<VehicleModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully updated vehicle";
                response.Data = await this.vehicleService.UpdateVehicle(id, editedVehicle);
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
                response.Message = "Error! Unsuccessful edit of the existing vehicle";
                response.Data = null;
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ApiResponse<VehicleModel>> Delete([FromRoute] int id)
        {
            ApiResponse<VehicleModel> response=new ApiResponse<VehicleModel>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully deleted vehicle";
                response.Data = await this.vehicleService.DeleteVehicle(id);
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
                response.Message = "Error! Unsuccessful deletion of the existing vehicle";
                response.Data = null;
            }

            return response;
        }
    }
}
