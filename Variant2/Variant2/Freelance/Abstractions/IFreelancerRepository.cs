using Freelance.Models;

namespace Freelance.Abstractions;

public interface IFreelancerRepository
{
    Task<List<Freelancer>> GetTopFreelancersAsync();
    Task<Freelancer> GetByIdAsync(int freelancerId);
}