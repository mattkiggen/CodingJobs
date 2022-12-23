using AutoMapper;
using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;

namespace CodingJobs.Application.Mapping;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<AddCompanyRequest, Domain.Models.Company>();
        CreateMap<Domain.Models.Company, CompanyResponse>();
        CreateMap<Domain.Models.Company, CompanyWithJobsResponse>();
        CreateMap<UpdateCompanyRequest, Domain.Models.Company>();
    }
}