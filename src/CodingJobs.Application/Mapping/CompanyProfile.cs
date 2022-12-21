using AutoMapper;
using CodingJobs.Contracts.Company;

namespace CodingJobs.Application.Mapping;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<AddCompanyRequest, Domain.Models.Company>();
        CreateMap<Domain.Models.Company, AddCompanyResponse>()
            .ForMember(
                dest => dest.Id, 
                src => src.MapFrom(c => c.CompanyId)
            );
    }
}