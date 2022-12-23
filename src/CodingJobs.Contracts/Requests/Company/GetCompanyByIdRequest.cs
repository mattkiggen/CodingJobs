namespace CodingJobs.Contracts.Requests.Company;

public class GetCompanyByIdRequest
{
    public int Id { get; }

    public GetCompanyByIdRequest(int id)
    {
        Id = id;
    }
}