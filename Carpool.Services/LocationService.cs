using System.Linq;
using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Data;
using db=Carpool.Data.DbModels;
using Carpool.Services.Contracts;
using Carpool.Models.ServiceModels;

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
        public async Task<Location> AddLocation(Location newLocation)
        {
            try
            {
                db.Location location = this.mapper.Map<db.Location>(newLocation);
                await dbContext.Locations.AddAsync(location);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<Location>(location);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Get All
        public async Task<IEnumerable<Location>> GetLocations()
        {
            try
            {
                List<db.Location> locations = dbContext.Locations.Select(loc=>loc).ToList();
                List<Location> locationResponses = new List<Location>();

                foreach (db.Location l in locations)
                {
                    locationResponses.Add(this.mapper.Map<Location>(l));
                }

                return locationResponses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get by Id
        public async Task<Location> GetLocation(int id)
        {
            try
            {
                db.Location location = await dbContext.Locations.FindAsync(id);
                if ( location== null)
                {
                    throw new DataNotFoundException("The required location doesn't exist");
                }
                return this.mapper.Map<Location>(location);
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
        public async Task<Location> UpdateLocation(int id, Location editedLocation)
        {
            db.Location location;
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
                return this.mapper.Map<Location>(location);
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
        public async Task<Location> DeleteLocation(int id)
        {
            db.Location location;
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

            return this.mapper.Map<Location>(location);
        }

    }
}

