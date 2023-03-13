using System;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class VehicleTypeService
	{
        private readonly ApplicationDbContext dbContext;

        public VehicleTypeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Post
        public ApiResponse<VehicleType> AddVehicleType(VehicleTypeRequest newVehicleType)
        {
            ApiResponse<VehicleType> response;

            try
            {
                VehicleType vehicleType = new VehicleType()
                {
                    Type = newVehicleType.Type
                };

                dbContext.VehicleTypes.Add(vehicleType);
                dbContext.SaveChanges();

                response = new(201, "Success", true);
                response.Message = "VehicleType succesfully added";
                response.Data = vehicleType;

            }
            catch
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition";
                response.Data = null;
            }
            return response;
        }

        //Get All
        public ApiResponse<IEnumerable<VehicleType>> GetVehicleTypes()
        {
            ApiResponse<IEnumerable<VehicleType>> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicleTypes";
                response.Data = dbContext.VehicleTypes;

            }
            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of vehicleTypes;\n{ex.Message}";
                response.Data = null;
            }

            return response;
        }

        //Get by Id
        public ApiResponse<VehicleType> GetVehicleType(int id)
        {
            ApiResponse<VehicleType> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicleType";
                response.Data = dbContext.VehicleTypes.Find(id);
                if (response.Data == null)
                {
                    throw new DataNotFoundException("The required vehicleType doesn't exist");
                }
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
                response.Message = "Error! Unsucceful retrieval of vehicleType";
                response.Data = null;
            }

            return response;
        }

        //Update
        public ApiResponse<VehicleType> UpdateVehicleType(int id, VehicleTypeRequest editedVehicleType)
        {
            ApiResponse<VehicleType> response;

            try
            {
                VehicleType vehicleType = dbContext.VehicleTypes.Find(id);
                if (vehicleType == null)
                {
                    throw new DataNotFoundException("VehicleType corresponding to specified id doesn't exist");
                }


                vehicleType.Type = editedVehicleType.Type;

                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully updated vehicleType";
                response.Data = vehicleType;
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
                response.Message = "Error! Unsuccessful edit of the existing vehicleType";
                response.Data = null;
            }

            return response;
        }


        //Delete
        public ApiResponse<VehicleType> DeleteVehicleType(int id)
        {
            ApiResponse<VehicleType> response;

            try
            {
                VehicleType vehicleType = dbContext.VehicleTypes.Find(id);
                if (vehicleType == null)
                {
                    throw new DataNotFoundException("VehicleType corresponding to specified id doesn't exist");
                }

                dbContext.VehicleTypes.Remove(vehicleType);
                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully deleted vehicleType";
                response.Data = vehicleType;
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
                response.Message = "Error! Unsuccessful deletion of the existing vehicleType";
                response.Data = null;
            }

            return response;
        }
    }
}

