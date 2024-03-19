using AutoMapper;
using Freelance.Dtos;
using Freelance.Models;

namespace Freelance.Profiles;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<ReviewDto, Review>().ReverseMap();
        CreateMap<FreelancerDto, Freelancer>().ReverseMap();
        CreateMap<ProjectDto, Project>().ReverseMap();

        CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.FreelancerId, opt => opt.MapFrom(src => src.Freelancer.Id));
        
        CreateMap<Freelancer, FreelancerDto>()
            .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(s => s.Name)));

        CreateMap<Project, ProjectDto>();
    }
}