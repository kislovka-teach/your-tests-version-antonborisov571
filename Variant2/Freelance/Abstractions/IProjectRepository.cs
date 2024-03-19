using Freelance.Models;

namespace Freelance.Abstractions;

public interface IProjectRepository
{
    Task<List<Project>> GetProjectsByFreelancerIdAsync(int freelancerId);
}