using AutoMapper;
using CodingJobs.Contracts.Company;
using CodingJobs.Contracts.Company.Requests;
using CodingJobs.Contracts.Company.Responses;

namespace CodingJobs.Application.Mapping;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<AddCompanyRequest, Domain.Models.Company>();
        CreateMap<Domain.Models.Company, CompanyResponse>()
            .ForMember(
                dest => dest.Id, 
                src => src.MapFrom(c => c.CompanyId)
            );
    }
}