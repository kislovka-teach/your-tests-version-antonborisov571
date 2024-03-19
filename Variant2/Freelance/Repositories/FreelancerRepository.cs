using Freelance.Abstractions;
using Freelance.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Repositories;

public class FreelancerRepository(AppDbContext context) : IFreelancerRepository
{
    public async Task<List<Freelancer>> GetTopFreelancersAsync()
    {
        return await context.Freelancers
            .OrderByDescending(f => f.Rating)
            .Take(10)
            .ToListAsync();
    }
    
    public async Task<Freelancer> GetByIdAsync(int freelancerId)
    {
        return await context.Freelancers.FindAsync(freelancerId);
    }
}