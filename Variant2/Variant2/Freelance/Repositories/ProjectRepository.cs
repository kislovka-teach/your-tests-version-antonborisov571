using Freelance.Abstractions;
using Freelance.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Repositories;

public class ProjectRepository(AppDbContext context) : IProjectRepository
{

    public async Task<List<Project>> GetProjectsByFreelancerIdAsync(int freelancerId)
    {
        return await context.Projects
            .Where(p => p.Freelancers.Any(fp => fp.ReferenceUserId == freelancerId))
            .ToListAsync();
    }
}