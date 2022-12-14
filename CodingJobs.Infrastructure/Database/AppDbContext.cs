using System.Reflection;
using CodingJobs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingJobs.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Address> Addresses => Set<Address>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}