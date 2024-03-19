using Freelance.Dtos;

namespace Freelance.Abstractions;

public interface IFreelancerService
{
    Task<List<FreelancerDto>> GetTopFreelancers();
}