using EventManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data
{
    public class EmDbContext : DbContext
    {
        public EmDbContext(DbContextOptions<EmDbContext> options) : base(options)
        {
        }

        public DbSet<EventType> EventTypes { get; set; } = null!;
        public DbSet<EventLocation> EventLocations { get; set; } = null!;
    }
}
