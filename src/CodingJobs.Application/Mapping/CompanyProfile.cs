using AutoMapper;
using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;

namespace CodingJobs.Application.Mapping;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        // Contract to domain
        CreateMap<AddCompanyRequest, Domain.Models.Company>();
        CreateMap<UpdateCompanyRequest, Domain.Models.Company>();
        
        // Domain to contract
        CreateMap<Domain.Models.Company, CompanyResponse>();
        CreateMap<Domain.Models.Company, CompanyWithJobsResponse>();
    }
}