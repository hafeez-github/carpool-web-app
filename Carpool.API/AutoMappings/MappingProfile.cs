using System;
using AutoMapper;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;

namespace Carpool.API.AutoMappings
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
            CreateMap<Offer, OfferModel>().ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<Ride, RideModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Vehicle, VehicleModel>().ReverseMap();

            //CreateMap<List<Location>, List<LocationModel>>().ReverseMap();
            //CreateMap<List<Offer>, List<OfferModel>>().ReverseMap();
            //CreateMap<List<User>, List<UserModel>>().ReverseMap();
            //CreateMap<List<Vehicle>, List<VehicleModel>>().ReverseMap();
        }
	}
}

