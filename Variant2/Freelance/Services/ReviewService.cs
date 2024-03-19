using AutoMapper;
using Freelance.Abstractions;
using Freelance.Dtos;
using Freelance.Models;

namespace Freelance.Services;

public class ReviewService(
    IReviewRepository reviewRepository, 
    IMapper mapper
    ) : IReviewService
{

    public async Task AddReview(ReviewDto reviewDto, int employerId)
    {
        var review = mapper.Map<Review>(reviewDto);
        review.SenderId = employerId;
        await reviewRepository.AddAsync(review);
    }
}