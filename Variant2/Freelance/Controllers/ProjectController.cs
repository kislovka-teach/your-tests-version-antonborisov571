using System.Security.Claims;
using Freelance.Abstractions;
using Freelance.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Freelance.Controllers;

[Route("project")]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    [Authorize(Roles = "employer")]
    [HttpPost("add")]
    public async Task<IActionResult> AddProject(ProjectDto projectDto)
    {
        var employerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await projectService.AddProject(projectDto, employerId);
        return Ok();
    }

    [Authorize(Roles = "freelancer")]
    [HttpPost("bid/add")]
    public async Task<IActionResult> AddBid(BidDto bidDto)
    {
        var freelancerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await projectService.AddBid(bidDto, freelancerId);
        return Ok();
    }
    
    [Authorize(Roles = "employer")]
    [HttpPost("{projectId:int}/accept/{bidId:int}")]
    public async Task<IActionResult> AcceptBid(int projectId, int bidId)
    {
        var employerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await projectService.AcceptBid(projectId, bidId, employerId);
        return Ok();
    }
}