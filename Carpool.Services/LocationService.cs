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
                List<Location> locationResponses = this.mapper.Map<List<Location>>(locations);

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
                location = await dbContext.Locations.FindAsync(id);

                if (location == null)
                {
                    throw new DataNotFoundException("Location corresponding to specified id doesn't exist");
                }

                location = this.mapper.Map(editedLocation, location);
                location.Id = id;
                var c  = dbContext.SaveChangesAsync();
                var res = this.mapper.Map(location, editedLocation);
                return res;
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
            catch (Exception ex)
            {
                throw;
            }

            return this.mapper.Map<Location>(location);
        }

    }
}

