using System.Data;
using AutoMapper;
using Carpool.Data;
using Carpool.Models.DbModels;
using Carpool.Models.RequestModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;

namespace Carpool.Services
{
	public class BookingService:IBookingService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public BookingService(ApplicationDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;

        }

        //Post   
        public async Task<List<OfferModel>> AddBookingDetails(BookingRequest model)
        {
            try
            {
                Booking booking = new()
                {
                    BookerId = model.BookerId,
                    From = model.From,
                    To = model.To,
                    Time = model.Time,
                    Date = model.Date,
                    SeatsRequired = model.SeatsRequired,
                    BookedTime = model.BookedTime
                };

                await dbContext.Bookings.AddAsync(booking);
                await dbContext.SaveChangesAsync();

                List<Offer> filteredOffers = dbContext.Offers.Where(offer =>
                    (offer.Time == booking.Time) && (offer.Date == booking.Date)
                ).ToList<Offer>();

                List<Offer> matches=new List<Offer>();

                for (int i=0;i<filteredOffers.Count;i++)
                {
                    if (booking.From == filteredOffers[i].From)
                    {
                        if (booking.To == filteredOffers[i].To)
                        {
                            matches.Add(filteredOffers[i]);
                        }

                        else
                        {
                            int[] offeredStopsAsIDs = ConvertStringsToIDs(filteredOffers[i].Stops);

                            for (int j = 0; j < offeredStopsAsIDs.Length; j++)
                            {
                                if (booking.To == offeredStopsAsIDs[j])
                                {
                                    matches.Add(filteredOffers[i]);
                                }
                            }
                        }
                    }

                    else
                    {
                        int[] offeredStopsAsIDs = ConvertStringsToIDs(filteredOffers[i].Stops);
                        int index = -1;

                        for (int j = 0; j < offeredStopsAsIDs.Length; j++)
                        {
                            if (booking.From == offeredStopsAsIDs[j])
                            {
                                index = j;

                                if (booking.To == filteredOffers[i].To)
                                {
                                    matches.Add(filteredOffers[i]);
                                    break;
                                }

                            }
                        }

                        //There is a match for 'For' in stops and now it is to Find 'To' in Stops
                        if (index != -1)
                        {
                            for (int j = index + 1; j < offeredStopsAsIDs.Length; j++)
                            {
                                if (booking.To == offeredStopsAsIDs[j])
                                {
                                    matches.Add(filteredOffers[i]);
                                }
                            }
                        }

                    }    
                    
                }

                List<OfferModel> offerModels = new List<OfferModel>();
                foreach (Offer m in matches)
                {
                    offerModels.Add(this.mapper.Map<OfferModel>(m));
                }
                return offerModels;
            }
            
            catch (Exception ex)
            {
                throw;
            }



        }

        public int[] ConvertStringsToIDs(string stopsAsAString)
        {
            string[] stopsAsStrings= stopsAsAString.Split(", ");

            int[] offeredStops = new int[stopsAsAString.Length]; //Stops with IDs

            for (int i=0; i< stopsAsStrings.Length;i++)
            {
                if (stopsAsStrings[i] == "")
                {
                    break;
                }
                    offeredStops[i] =int.Parse(stopsAsStrings[i]);
            }

            return offeredStops;
        }
    }
}

