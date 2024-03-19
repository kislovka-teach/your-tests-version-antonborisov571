using Freelance.Abstractions;
using Freelance.Dtos;
using Freelance.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Services;

public class ProjectService(AppDbContext dbContext) : IProjectService
{
    public async Task AddProject(ProjectDto projectDto, int employerId)
    {
        var project = new Project
        {
            Title = projectDto.Title,
            Description = projectDto.Description,
            Type = projectDto.Type,
            Budget = projectDto.Budget,
            CreationDate = projectDto.CreationDate,
            Status = ProjectStatus.Active
        };
        var employer = await dbContext.Users.FindAsync(employerId);
        if (employer == null || employer.Role != UserRole.Employer)
        {
            throw new InvalidOperationException("Only employers can add projects.");
        }
        
        dbContext.Projects.Add(project);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddBid(BidDto bidDto, int freelancerId)
    {
        var project = await dbContext.Projects.FindAsync(bidDto.ProjectId);
        if (project == null || project.Status != ProjectStatus.Active)
        {
            throw new InvalidOperationException("The project is not active or does not exist.");
        }

        var user = await dbContext.Users.SingleAsync(x => x.Id == freelancerId);
        if (user == null || user.Role != UserRole.Freelancer)
        {
            throw new InvalidOperationException("Only freelancers can bid on projects.");
        }
        var freelancer = await dbContext.Freelancers.SingleAsync(x => x.ReferenceUserId == freelancerId);

        var bid = new Bid
        {
            Freelancer = freelancer,
            Project = project,
            Cost = bidDto.Cost,
            Description = bidDto.Description
        };

        dbContext.Proposals.Add(bid);
        await dbContext.SaveChangesAsync();
    }

    public async Task AcceptBid(int projectId, int bidId, int employerId)
    {
        var project = await dbContext.Projects.FindAsync(projectId);
        if (project == null || project.Status != ProjectStatus.Active)
        {
            throw new InvalidOperationException("The project is not active or does not exist.");
        }

        var employer = await dbContext.Users.FindAsync(employerId);
        if (employer == null || employer.Role != UserRole.Employer)
        {
            throw new InvalidOperationException("Only employers can accept bids.");
        }

        var bid = await dbContext.Proposals.FindAsync(bidId);
        if (bid == null || bid.ProjectId != projectId || bid.Project.Status != ProjectStatus.Active)
        {
            throw new InvalidOperationException("The bid is not valid.");
        }

        project.Status = ProjectStatus.Completed;
        bid.Project.Status = ProjectStatus.Completed;

        await dbContext.SaveChangesAsync();
    }
}