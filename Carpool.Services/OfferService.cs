using AutoMapper;
using Carpool.Data;
using db=Carpool.Data.DbModels;
using Carpool.Services.Contracts;
using Carpool.Models.ServiceModels;

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

        public async Task<Offer> AddOfferDetails(Offer model)
        {
            try
            {
                db.Offer offer = this.mapper.Map<db.Offer>(model);
                await dbContext.Offers.AddAsync(offer);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<Offer>(offer);
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Offer>> FindMatches(Booking booking)
        {

            List<db.Offer> filteredOffers = dbContext.Offers.Where(offer =>
                    (offer.Time == booking.Time) && (offer.Date.Date == booking.Date.Date)
                ).ToList<db.Offer>();

            List<db.Offer> matches = new List<db.Offer>();

            for (int i = 0; i < filteredOffers.Count; i++)
            {
                if (booking.From == filteredOffers[i].From)
                {
                    if (booking.To == filteredOffers[i].To)
                    {
                        matches.Add(filteredOffers[i]);
                    }

                    else
                    {
                        int[] offeredStopsAsIDs = this.ConvertStringsToIDs(filteredOffers[i].Stops);

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
                    int[] offeredStopsAsIDs = this.ConvertStringsToIDs(filteredOffers[i].Stops);
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

            List<Offer> offerModels = new List<Offer>();
            foreach (db.Offer m in matches)
            {
                var match = this.mapper.Map<Offer>(m);
                match.Offerer = this.dbContext.Users.Where(user => match.OffererId == user.Id).Select(col => col.FirstName).First();
                match.FromLocation = this.dbContext.Locations.Where(loc => match.From == loc.Id).Select(col => col.Name).First();
                match.ToLocation = this.dbContext.Locations.Where(loc => match.To == loc.Id).Select(col => col.Name).First();

                offerModels.Add(match);
            }

            return offerModels;
        }

        public async Task<List<Offer>> GetOffers(User user)
        {
            List<Offer> offers = new List<Offer>();

            List<db.Offer> results=this.dbContext.Offers.Where(offer=>offer.OffererId==user.Id).ToList<db.Offer>();

            foreach (db.Offer result in results)
            {
                Offer currentOffer=this.mapper.Map<Offer>(result);

                currentOffer.Offerer = this.dbContext.Users.Where(user => currentOffer.OffererId == user.Id).Select(col => col.FirstName).First();
                currentOffer.FromLocation = this.dbContext.Locations.Where(loc => currentOffer.From == loc.Id).Select(col => col.Name).First();
                currentOffer.ToLocation = this.dbContext.Locations.Where(loc => currentOffer.To == loc.Id).Select(col => col.Name).First();
                offers.Add(currentOffer);
            }

            return offers;
        }

        //helper
        private int[] ConvertStringsToIDs(string stopsAsAString)
        {
            string[] stopsAsStrings = stopsAsAString.Split(", ");
            int[] offeredStops = new int[stopsAsAString.Length]; //Stops with IDs

            for (int i = 0; i < stopsAsStrings.Length; i++)
            {
                if (stopsAsStrings[i] == "")
                {
                    break;
                }
                offeredStops[i] = int.Parse(stopsAsStrings[i]);
            }

            return offeredStops;
        }
    }
}

