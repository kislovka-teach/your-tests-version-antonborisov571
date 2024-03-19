using System.Security.Claims;
using Freelance.Abstractions;
using Freelance.Dtos;
using Freelance.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freelance.Controllers;

[Route("freelancer")]
public class FreelancerController(
    IReviewService reviewService, 
    IFreelancerService freelancerService,
    FreelancerProjectService freelancerProjectService) 
    : ControllerBase
{
    [Authorize(Roles = "Employer")]
    [HttpPost("review/add")]
    public async Task<IActionResult> AddReview(ReviewDto reviewDto)
    {
        var employerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await reviewService.AddReview(reviewDto, employerId);
        return Ok();
    }

    [HttpGet("top")]
    public async Task<IActionResult> GetTopFreelancers()
    {
        var topFreelancers = await freelancerService.GetTopFreelancers();
        return Ok(topFreelancers);
    }
    
    [HttpGet("{freelancerId:int}/projects")]
    public async Task<IActionResult> GetFreelancerProjects(int freelancerId)
    {
        var projects = await freelancerProjectService.GetFreelancerProjects(freelancerId);
        return Ok(projects);
    }
}