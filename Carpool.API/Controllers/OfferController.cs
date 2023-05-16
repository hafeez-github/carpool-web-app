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
using Carpool.API.User;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private IOfferService offerService;
        private readonly IMapper mapper;
        private readonly UserContext builder;

        public OfferController(IOfferService offerService, IMapper mapper, UserContext builder)
        {
            this.offerService = offerService;
            this.mapper = mapper;
            this.builder = builder;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OfferResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OfferResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OfferResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("[action]")]
        public async Task<IActionResult> GetOffers()
        {
            ApiResponse<List<OfferResponse>> response = new ApiResponse<List<OfferResponse>>();
            try
            {
                response = new(200, "Success", true);
                response.Message = "Offers succesfully fetched";
                response.Data = this.mapper.Map<List<OfferResponse>>(await this.offerService.GetOffers());

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
