using AutoMapper;
using Freelance.Abstractions;
using Freelance.Dtos;

namespace Freelance.Services;

public class FreelancerService(IFreelancerRepository freelancerRepository, IMapper mapper) : IFreelancerService
{
    public async Task<List<FreelancerDto>> GetTopFreelancers()
    {
        var topFreelancers = await freelancerRepository.GetTopFreelancersAsync();
        return mapper.Map<List<FreelancerDto>>(topFreelancers);
    }
}