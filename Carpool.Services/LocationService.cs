using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class LocationService:ILocationService
	{
        private readonly ApplicationDbContext dbContext;

        public LocationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Post
        public async Task<Location> AddLocation(LocationRequest newLocation)
        {
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

                await dbContext.Locations.AddAsync(location);
                await dbContext.SaveChangesAsync();

                return location;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Get All
        public async Task<IEnumerable<Location>> GetLocations()
        {
            try
            {
                return dbContext.Locations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get by Id
        public async Task<Location> GetLocation(int id)
        {
            try
            {
                Location location = await dbContext.Locations.FindAsync(id);
                if ( location== null)
                {
                    throw new DataNotFoundException("The required location doesn't exist");
                }
                return location;
            }

            catch (DataNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Update
        public async Task<Location> UpdateLocation(int id, LocationRequest editedLocation)
        {
            Location location;
            try
            {
                location= await dbContext.Locations.FindAsync(id);

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

                await dbContext.SaveChangesAsync();
                return location;
            }

            catch (DataNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        //Delete
        public async Task<Location> DeleteLocation(int id)
        {
            Location location;
            try
            {
                location = await dbContext.Locations.FindAsync(id);

                if (location == null)
                {
                    throw new DataNotFoundException("Location corresponding to specified id doesn't exist");
                }

                dbContext.Locations.Remove(location);
                await dbContext.SaveChangesAsync();
            }
            catch (DataNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return location;
        }

    }
}

