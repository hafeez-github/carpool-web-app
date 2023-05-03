using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Carpool.Services;
using Carpool.Services.Contracts;
using Carpool.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using services = Carpool.Models.ServiceModels;
using Carpool.API.ViewModels.RequestModels;
using Carpool.API.ViewModels.ResponseModels;

namespace Carpool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService bookingService;
        private readonly IMapper mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookingRequest bookingRequest)
        {
            ApiResponse<BookingResponse> response=new ApiResponse<BookingResponse>();
            services.Booking booking = this.mapper.Map<services.Booking>(bookingRequest);
            try
            {
                response = new(201, "Success", true);
                response.Message = "Ride succesfully booked";
                response.Data = this.mapper.Map<BookingResponse>(await this.bookingService.AddBookingDetails(booking));
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetBookings(UserResponse model)
        {
            ApiResponse<List<BookingResponse>> response = new ApiResponse<List<BookingResponse>>();
            services.User user = this.mapper.Map<services.User>(model);

            try
            {
                response = new(200, "Success", true);
                response.Message = "Bookings succesfully fetched";
                response.Data = this.mapper.Map<List<BookingResponse>>(await this.bookingService.GetBookings(user));

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
