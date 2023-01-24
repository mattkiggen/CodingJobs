using CodingJobs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingJobs.Infrastructure.Database.Config;

public class JobConfig : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.Property(j => j.PublishedOn)
            .HasDefaultValueSql("now()");
    }
}