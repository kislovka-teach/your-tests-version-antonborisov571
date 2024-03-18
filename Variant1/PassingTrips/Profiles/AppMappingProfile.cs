using AutoMapper;
using PassingTrips.Dtos;
using PassingTrips.Models;

namespace PassingTrips.Profiles;

public class AppMappingProfile : Profile
{
     public AppMappingProfile()
     {
          CreateMap<Trip, TripDto>()
               .ForMember(trip => trip.DepartureCity,
                    options => options.MapFrom(trip1 => trip1.DepartureCity.Name))
               .ForMember(trip => trip.ArrivalCity,
                    options => options.MapFrom(trip1 => trip1.ArrivalCity.Name));
          CreateMap<Trip, FullTripDto>()
               .ForMember(trip => trip.DepartureCity,
                    options => options.MapFrom(trip1 => trip1.DepartureCity.Name))
               .ForMember(trip => trip.ArrivalCity,
                    options => options.MapFrom(trip1 => trip1.ArrivalCity.Name))
               .ForMember(trip => trip.Driver,
                    options => options.MapFrom(trip1 => trip1.Driver.FirstName));
          CreateMap<User, DriverDto>()
               .ForMember(d => d.Score,
                    options => options.MapFrom(d1 => 
                         d1.DriverTrips.SelectMany(x => x.Reviews.Select(y => y.Score)).Average()))
               .ForMember(d => d.Reviews,
                    options => options.MapFrom(d1 => d1.DriverTrips.SelectMany(x => x.Reviews)))
               .ForMember(d => d.CountTrips,
                    options => options.MapFrom(d1 => d1.DriverTrips.Count));
          CreateMap<Review, ReviewDto>()
               .ForMember(r => r.Sender,
                    options => options.MapFrom(r1 => r1.Sender.FirstName));

     }
}