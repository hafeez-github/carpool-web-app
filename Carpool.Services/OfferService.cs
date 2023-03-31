using AutoMapper;
using Carpool.Data;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;

namespace Carpool.Services
{
	public class OfferService:IOfferService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public OfferService(ApplicationDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        //Post   
        public async Task<OfferModel> AddOfferDetails(OfferRequest model)
        {
            try
            {
                Offer offer = new()
                {
                    OffererId = model.OffererId,
                    From = model.From,
                    To = model.To,
                    Time = model.Time,
                    Date= model.Date,
                    SeatsAvailable = model.SeatsAvailable,
                    Stops=model.Stops,
                    OfferedTime = model.OfferedTime
                };

                await dbContext.Offers.AddAsync(offer);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<OfferModel>(offer);
            }

            catch (Exception ex)
            {
                throw;
            }

           
        }
    }
}

