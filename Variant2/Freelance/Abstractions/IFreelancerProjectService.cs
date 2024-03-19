using Freelance.Dtos;

namespace Freelance.Abstractions;

public interface IFreelancerProjectService
{
    Task<List<ProjectDto>> GetFreelancerProjects(int freelancerId);
}