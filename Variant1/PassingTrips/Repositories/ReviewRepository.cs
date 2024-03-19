using PassingTrips.Abstractions;
using PassingTrips.Models;

namespace PassingTrips.Repositories;

public class ReviewRepository(AppDbContext dbContext) : IReviewRepository
{
    public async Task AddReview(Review review)
    {
        await dbContext.Reviews.AddAsync(review);
        await dbContext.SaveChangesAsync();
    }
}