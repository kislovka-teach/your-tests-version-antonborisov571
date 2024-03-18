using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassingTrips.Abstractions;
using PassingTrips.Dtos;
using PassingTrips.Models;

namespace PassingTrips.Controllers;

[ApiController]
[Route("/[controller]")]
public class TripsController(
    ITripRepository tripRepository, 
    ICityRepository cityRepository,
    IFindTripsByCoordinates findTripsByCoordinates,
    IUserRepository userRepository,
    IReviewRepository reviewRepository,
    IMapper mapper) : ControllerBase
{
    [Authorize]
    [HttpPost]
    [Route("/add")]
    public async Task<IActionResult> AddTrip([FromBody]InputTripDto inputTripDto)
    {
        var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var trip = new Trip
        {
            DriverId = id,
            DepartureTime = inputTripDto.DepartureTime,
            ArrivalTime = inputTripDto.ArrivalTime,
            DepartureCityId = (await cityRepository.GetCityByName(inputTripDto.DepartureCity)).Id,
            ArrivalCityId = (await cityRepository.GetCityByName(inputTripDto.ArrivalCity)).Id,
            Price = inputTripDto.Price,
            MaxCountPassenger = inputTripDto.MaxCountPassenger,
            Car = inputTripDto.Car,
            IsMusic = inputTripDto.IsMusic,
            IsSmoking = inputTripDto.IsSmoking,
            IsAnimal = inputTripDto.IsAnimal
        };
        await tripRepository.AddTrip(trip);
        return Ok("Поездка добавлена");
    }

    [Authorize]
    [HttpPost]
    [Route("/by_cities_trips")]
    public List<TripDto> GetTripsByCitiesTime([FromBody] FindTripByCitiesDto findTripDto)
    {
        var trips = tripRepository.GetTripsByCitiesTime(findTripDto);
        return mapper.Map<List<TripDto>>(trips);
    }
    
    [Authorize]
    [HttpPost]
    [Route("/by_coordinates_trips")]
    public List<TripDto> GetTripsByCitiesTime([FromBody] FindTripByCoordinatesDto findTripDto)
    {
        var trips = findTripsByCoordinates.GetTripsByCoordinates(findTripDto);
        return mapper.Map<List<TripDto>>(trips);
    }
    
    [Authorize]
    [HttpGet]
    [Route("/{id:int}")]
    public async Task<FullTripDto> GetTrip(int id)
    {
        var trip = await tripRepository.GetTripById(id);
        return mapper.Map<FullTripDto>(trip);
    }
    
    [Authorize]
    [HttpGet]
    [Route("/{id:int}/get_driver")]
    public async Task<DriverDto> GetDriver(int id)
    {
        var driver = await userRepository.GetDriverByTripId(id);
        return mapper.Map<DriverDto>(driver);
    }
    
    [Authorize]
    [HttpGet]
    [Route("/{id:int}/add_passenger")]
    public async Task<string> BookTrip(int id)
    {
        var trip = await tripRepository.GetTripById(id);
        if (trip != null)
            return "Вы забронировали поездку! Вот номер водителя:" + trip.Driver.NumberPhone;
        return "Все места заняты!";
    }
    
    [Authorize]
    [HttpPost]
    [Route("/{id:int}/add_review")]
    public async Task AddReview([FromBody]ReviewDto reviewDto, int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var review = new Review
        {
            SenderId = userId,
            TripId = id,
            ReviewText = reviewDto.ReviewText,
            Score = reviewDto.Score
        };
        await reviewRepository.AddReview(review);
    }
}