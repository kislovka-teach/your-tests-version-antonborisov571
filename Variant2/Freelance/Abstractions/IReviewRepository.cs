using Freelance.Models;

namespace Freelance.Abstractions;

public interface IReviewRepository
{
    Task AddAsync(Review review);
}