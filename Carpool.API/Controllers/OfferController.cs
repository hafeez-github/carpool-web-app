using System;
using System.Collections.Generic;
using Carpool.Services.Contracts;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services = Carpool.Models.ServiceModels;
using Carpool.API.ViewModels.RequestModels;
using Carpool.API.ViewModels.ResponseModels;
using AutoMapper;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private IOfferService offerService;
        private readonly IMapper mapper;

        public OfferController(IOfferService offerService, IMapper mapper)
        {
            this.offerService = offerService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OfferRequest model)
        {
            ApiResponse<OfferResponse> response=new ApiResponse<OfferResponse>();
            services.Offer offer = this.mapper.Map<services.Offer>(model);
            try
            {
                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = this.mapper.Map<OfferResponse>(await this.offerService.AddOfferDetails(offer));

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FindMatches(BookingResponse model)
        {
            ApiResponse<List<OfferResponse>> response = new ApiResponse<List<OfferResponse>>();
            services.Booking booking = this.mapper.Map<services.Booking>(model);

            try
            {
                response = new(200, "Success", true);
                response.Message = "User succesfully added";
                response.Data = this.mapper.Map<List<OfferResponse>>(await this.offerService.FindMatches(booking));

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> GetOffers(UserResponse model)
        {
            ApiResponse<List<OfferResponse>> response = new ApiResponse<List<OfferResponse>>();
            services.User user = this.mapper.Map<services.User>(model);
            try
            {
                response = new(200, "Success", true);
                response.Message = "Offers succesfully fetched";
                response.Data = this.mapper.Map<List<OfferResponse>>(await this.offerService.GetOffers(user));

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
