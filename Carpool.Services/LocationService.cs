using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class LocationService
	{
        private readonly ApplicationDbContext dbContext;

        public LocationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Post
        public ApiResponse<Location> AddLocation(LocationRequest newLocation)
        {
            ApiResponse<Location> response;

            try
            {
                Location location = new Location()
                {
                    Name = newLocation.Name,
                    City = newLocation.City,
                    Country = newLocation.Country,
                    PINCode = newLocation.PINCode,
                    State = newLocation.State,
                    Latitude = newLocation.Latitude,
                    Longitude = newLocation.Longitude,
                };

                dbContext.Locations.Add(location);
                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Location succesfully added";
                response.Data = location;

            }
            catch(Exception ex)
            {
                response = new(404, "Failure", false);
                response.Message = "Error! Unsuccessful addition"+ ex.Message;
                response.Data = null;
            }
            return response;
        }

        //Get All
        public ApiResponse<IEnumerable<Location>> GetLocations()
        {
            ApiResponse<IEnumerable<Location>> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched locations";
                response.Data = dbContext.Locations;

            }
            catch (Exception ex)
            {
                response = new(410, "Failure", false);
                response.Message = $"Error! Unsuccessful retireval of locations;\n{ex.Message}";
                response.Data = null;
            }

            return response;
        }

        //Get by Id
        public ApiResponse<Location> GetLocation(int id)
        {
            ApiResponse<Location> response;

            try
            {
                response = new(200, "Success", true);
                response.Message = "Successfully fetched location";
                response.Data = dbContext.Locations.Find(id);
                if (response.Data == null)
                {
                    throw new DataNotFoundException("The required location doesn't exist");
                }
            }
            catch (DataNotFoundException ex)
            {
                response = new(410, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }
            catch (Exception ex)
            {
                response = new(410, "Failure", false);
                response.Message = "Error! Unsucceful retrieval of location";
                response.Data = null;
            }

            return response;
        }

        //Update
        public ApiResponse<Location> UpdateLocation(int id, LocationRequest editedLocation)
        {
            ApiResponse<Location> response;

            try
            {
                Location location = dbContext.Locations.Find(id);
                if (location == null)
                {
                    throw new DataNotFoundException("Location corresponding to specified id doesn't exist");
                }


                location.Name = editedLocation.Name;
                location.City = editedLocation.City;
                location.Country = editedLocation.Country;
                location.PINCode = editedLocation.PINCode;
                location.State = editedLocation.State;
                location.Latitude = editedLocation.Latitude;
                location.Longitude = editedLocation.Longitude;

                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully updated location";
                response.Data = location;
            }

            catch (DataNotFoundException ex)
            {
                response = new(410, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            catch (Exception ex)
            {
                response = new(410, "Failure", false);
                response.Message = "Error! Unsuccessful edit of the existing location";
                response.Data = null;
            }

            return response;
        }


        //Delete
        public ApiResponse<Location> DeleteLocation(int id)
        {
            ApiResponse<Location> response;

            try
            {
                Location location = dbContext.Locations.Find(id);
                if (location == null)
                {
                    throw new DataNotFoundException("Location corresponding to specified id doesn't exist");
                }

                dbContext.Locations.Remove(location);
                dbContext.SaveChanges();

                response = new(200, "Success", true);
                response.Message = "Successfully deleted location";
                response.Data = location;
            }

            catch (DataNotFoundException ex)
            {
                response = new(410, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            catch (Exception ex)
            {
                response = new(410, "Failure", false);
                response.Message = "Error! Unsuccessful deletion of the existing location";
                response.Data = null;
            }

            return response;
        }

    }
}

