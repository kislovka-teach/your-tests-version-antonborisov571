using Freelance.Abstractions;
using Freelance.Models;

namespace Freelance.Repositories;

public class ReviewRepository(AppDbContext dbContext) : IReviewRepository
{

    public async Task AddAsync(Review review)
    {
        await dbContext.Reviews.AddAsync(review);
        await dbContext.SaveChangesAsync();
    }
}