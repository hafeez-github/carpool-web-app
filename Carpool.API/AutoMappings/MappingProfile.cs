using System;
using AutoMapper;
using Carpool.API.ViewModels.RequestModels;
using Carpool.API.ViewModels.Authentication;
using Carpool.API.ViewModels.ResponseModels;
using service = Carpool.Models.ServiceModels;
using db = Carpool.Data.DbModels;


namespace Carpool.API.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<service.Offer, db.Offer>().ReverseMap();
            CreateMap<service.Location, db.Location>().ReverseMap();
            CreateMap<service.Ride, db.Ride>().ReverseMap();
            CreateMap<service.User, db.User>().ReverseMap();
            CreateMap<service.Vehicle, db.Vehicle>().ReverseMap();
            CreateMap<service.Booking, db.Booking>().ReverseMap();

            CreateMap<service.Booking, db.Booking_Info>().ReverseMap();
            CreateMap<service.Offer, db.Offer_Info>().ReverseMap();

            CreateMap<BookingRequest, service.Booking>().ReverseMap();
            CreateMap<OfferRequest, service.Offer>().ReverseMap();
            CreateMap<RideRequest, service.Ride>().ReverseMap();
            CreateMap<UserRequest, service.User>().ReverseMap();
            CreateMap<LocationRequest, service.Location>().ReverseMap();
            CreateMap<LogIn, service.Authentication.LogIn>().ReverseMap();
            CreateMap<SignUp, service.Authentication.SignUp>().ReverseMap();

            CreateMap<BookingResponse, service.Booking>().ReverseMap();
            CreateMap<OfferResponse, service.Offer>().ReverseMap();
            CreateMap<RideResponse, service.Ride>().ReverseMap();
            CreateMap<UserResponse, service.User>().ReverseMap();
            CreateMap<LocationResponse, service.Location>().ReverseMap();
            CreateMap<VehicleResponse, service.Vehicle>().ReverseMap();
        }
    }
}

