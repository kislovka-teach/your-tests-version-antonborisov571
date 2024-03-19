using Freelance.Dtos;

namespace Freelance.Abstractions;

public interface IProjectService
{
    Task AddProject(ProjectDto projectDto, int employerId);
    Task AddBid(BidDto bidDto, int freelancerId);
    Task AcceptBid(int projectId, int bidId, int employerId);
}