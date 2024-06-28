using backend_guardianiq.API.ActiveService.Domain.Models;
using backend_guardianiq.API.Devices.Domain.Models;
using backend_guardianiq.API.PersonalSafety.Domain.Models;
using backend_guardianiq.API.Profiles.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<Service> Service { get; set; }
    public DbSet<Device> Device { get; set; }
    public DbSet<Personal> Personal { get; set; }
    
    public DbSet<Profile> Profile { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Service>().ToTable("Service");
        modelBuilder.Entity<Service>().HasKey(s=>s.Id);
        
        modelBuilder.Entity<Device>().ToTable("Device");
        modelBuilder.Entity<Device>().HasKey(d => d.Id);
        
        modelBuilder.Entity<Personal>().ToTable("PersonalSafety");
        modelBuilder.Entity<Personal>().HasKey(p => p.Id);
        
        modelBuilder.Entity<Profile>().ToTable("Profile");
        modelBuilder.Entity<Profile>().HasKey(r => r.Id);
    }
}