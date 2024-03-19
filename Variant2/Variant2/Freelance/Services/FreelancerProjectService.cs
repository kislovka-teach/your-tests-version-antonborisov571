using AutoMapper;
using Freelance.Abstractions;
using Freelance.Dtos;

namespace Freelance.Services;

public class FreelancerProjectService(
    IFreelancerRepository freelancerRepository, 
    IProjectRepository projectRepository, 
    IMapper mapper) 
    : IFreelancerProjectService
{

    public async Task<List<ProjectDto>> GetFreelancerProjects(int freelancerId)
    {
        var freelancer = await freelancerRepository.GetByIdAsync(freelancerId);
        if (freelancer == null)
        {
            return new List<ProjectDto>();
        }

        var projects = await projectRepository.GetProjectsByFreelancerIdAsync(freelancerId);

        var projectDtos = mapper.Map<List<ProjectDto>>(projects);

        return projectDtos;
    }
}