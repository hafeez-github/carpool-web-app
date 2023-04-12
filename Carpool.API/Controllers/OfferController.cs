using System;
using System.Collections.Generic;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;
using Carpool.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase

    {
        private IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OfferRequest offer)
        {
            ApiResponse<OfferModel> response=new ApiResponse<OfferModel>();

            try
            {
                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = await this.offerService.AddOfferDetails(offer);

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }

            
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FindMatches(BookingModel model)
        {
            ApiResponse<List<OfferModel>> response = new ApiResponse<List<OfferModel>>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "User succesfully added";
                response.Data = await this.offerService.FindMatches(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> FetchOffers(UserModel model)
        {
            ApiResponse<List<OfferModel>> response = new ApiResponse<List<OfferModel>>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Offers succesfully fetched";
                response.Data = await this.offerService.GetOffers(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }
        }
    }
}
