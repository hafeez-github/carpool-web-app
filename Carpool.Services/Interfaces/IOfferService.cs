using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IOfferService
	{
        ApiResponse<OfferTransaction> ReadOfferDetails(OfferRequest model);
    }
}

