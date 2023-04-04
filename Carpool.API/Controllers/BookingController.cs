using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carpool.Data;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.RequestModels;
using Carpool.Models.ResponseModels;
using Carpool.Services;
using Carpool.Services.Interfaces;
using Carpool.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookingRequest bookingRequest)
        {
            ApiResponse<BookingModel> response=new ApiResponse<BookingModel>();
            try
            {
                response = new(201, "Success", true);
                response.Message = "Ride succesfully booked";
                response.Data = await this.bookingService.AddBookingDetails(bookingRequest);
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
        public async Task<IActionResult> FetchBookings(UserModel model)
        {
            ApiResponse<List<BookingModel>> response = new ApiResponse<List<BookingModel>>();

            try
            {
                response = new(200, "Success", true);
                response.Message = "Bookings succesfully fetched";
                response.Data = await this.bookingService.FetchBookings(model);

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
