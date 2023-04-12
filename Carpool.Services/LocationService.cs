using System.Linq;
using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;

namespace Carpool.Services
{
	public class LocationService:ILocationService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public LocationService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        //Post
        public async Task<LocationModel> AddLocation(LocationRequest newLocation)
        {
            try
            {
                Location location = this.mapper.Map<Location>(newLocation);
                await dbContext.Locations.AddAsync(location);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<LocationModel>(location);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Get All
        public async Task<IEnumerable<LocationModel>> GetLocations()
        {
            try
            {
                List<Location> locations = dbContext.Locations.Select(loc=>loc).ToList();
                
                List<LocationModel> locationModels = new List<LocationModel>();
                foreach (Location l in locations)
                {
                    locationModels.Add(this.mapper.Map<LocationModel>(l));
                }

                return locationModels;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get by Id
        public async Task<LocationModel> GetLocation(int id)
        {
            try
            {
                Location location = await dbContext.Locations.FindAsync(id);
                if ( location== null)
                {
                    throw new DataNotFoundException("The required location doesn't exist");
                }
                return this.mapper.Map<LocationModel>(location);
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

        //Update
        public async Task<LocationModel> UpdateLocation(int id, LocationRequest editedLocation)
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
                return this.mapper.Map<LocationModel>(location);
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


        //Delete
        public async Task<LocationModel> DeleteLocation(int id)
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
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }

            return this.mapper.Map<LocationModel>(location);
        }

    }
}

