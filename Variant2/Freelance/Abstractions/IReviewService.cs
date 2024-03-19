using Freelance.Dtos;

namespace Freelance.Abstractions;

public interface IReviewService
{
    Task AddReview(ReviewDto reviewDto, int employerId);
}
