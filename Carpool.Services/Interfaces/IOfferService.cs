using System;
using Carpool.Models;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IOfferService
	{
        Task<OfferModel> AddOfferDetails(OfferRequest model);
    }
}

