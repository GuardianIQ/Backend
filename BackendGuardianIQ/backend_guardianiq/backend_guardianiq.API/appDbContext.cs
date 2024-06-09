using Microsoft.EntityFrameworkCore;
using backend_guardianiq.API.Devices.Models;

namespace backend_guardianiq.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
    }
}