using CodingJobs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingJobs.Infrastructure.Database.Configs;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasOne<Address>().WithOne().HasForeignKey<Company>(c => c.AddressId);
    }
}