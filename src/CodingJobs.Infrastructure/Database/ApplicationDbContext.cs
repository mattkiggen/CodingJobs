using System.Reflection;
using CodingJobs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SmartEnum.EFCore;

namespace CodingJobs.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Skill> Skills => Set<Skill>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ConfigureSmartEnum();
    }
}