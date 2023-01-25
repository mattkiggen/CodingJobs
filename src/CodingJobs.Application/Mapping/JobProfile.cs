using AutoMapper;
using CodingJobs.Contracts.Requests.Job;
using CodingJobs.Contracts.Responses.Job;
using CodingJobs.Domain.Models;

namespace CodingJobs.Application.Mapping;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<AddJobRequest, Job>()
            .ForMember(j => j.Skills, 
                opt => opt.MapFrom(
                    req => req.Skills.Select(id => new Skill { SkillId = id})
                    )
            );

        CreateMap<Job, JobResponse>();
    }
}