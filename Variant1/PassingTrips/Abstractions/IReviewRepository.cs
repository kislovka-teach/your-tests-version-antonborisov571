using PassingTrips.Models;

namespace PassingTrips.Abstractions;

public interface IReviewRepository
{
    Task AddReview(Review review);
}