using System;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class VehicleService:IVehicleService
	{
        private readonly ApplicationDbContext dbContext;

        public VehicleService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        //Post
        public ApiResponse<Vehicle> AddVehicle(VehicleRequest newVehicle)
        {
            ApiResponse<Vehicle> response;

            try
            {
                Vehicle vehicle = new Vehicle()
                {
                    Number = newVehicle.Number,
                    Type = newVehicle.Type,
                    OwnerId = newVehicle.OwnerId
                };

                dbContext.Vehicles.Add(vehicle);
                dbContext.SaveChanges();

                response = new(201, "Success", true);
                response.Message = "Vehicle succesfully added";
                response.Data = vehicle;

            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! Unsuccessful addition.\n"+ex.Message;
                response.Data = null;
            }
            return response;
        }

        //Get All
        public ApiResponse<IEnumerable<Vehicle>> GetVehicles()
        {
            ApiResponse<IEnumerable<Vehicle>> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicles";
                response.Data = dbContext.Vehicles;
            }

            catch (Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of vehicles;\n{ex.Message}";
                response.Data = null;
            }

            return response;
        }

        //Get by Id
        public ApiResponse<Vehicle> GetVehicle(int id)
        {
            ApiResponse<Vehicle> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched vehicle";
                response.Data = dbContext.Vehicles.Find(id);
                if (response.Data == null)
                {
                    throw new DataNotFoundException("The required vehicle doesn't exist");
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
                response.Message = "Error! Unsucceful retrieval of vehicle";
                response.Data = null;
            }

            return response;
        }

        //Update
        public ApiResponse<Vehicle> UpdateVehicle(int id, VehicleRequest editedVehicle)
        {
            ApiResponse<Vehicle> response;

            try
            {
                Vehicle vehicle = dbContext.Vehicles.Find(id);
                if (vehicle == null)
                {
                    throw new DataNotFoundException("Vehicle corresponding to specified id doesn't exist");
                }


                vehicle.Number = editedVehicle.Number;
                vehicle.Type = editedVehicle.Type;
                vehicle.OwnerId = editedVehicle.OwnerId;

                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully updated vehicle";
                response.Data = vehicle;
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


        //Delete
        public ApiResponse<Vehicle> DeleteVehicle(int id)
        {
            ApiResponse<Vehicle> response;

            try
            {
                Vehicle user = dbContext.Vehicles.Find(id);
                if (user == null)
                {
                    throw new DataNotFoundException("Vehicle corresponding to specified id doesn't exist");
                }

                dbContext.Vehicles.Remove(user);
                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully deleted vehicle";
                response.Data = user;
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

