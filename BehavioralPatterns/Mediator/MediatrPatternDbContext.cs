using BehavioralPatterns.Mediator.Entities;
using Microsoft.EntityFrameworkCore;

namespace BehavioralPatterns.Mediator
{
    public class MediatrPatternDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public MediatrPatternDbContext(DbContextOptions<MediatrPatternDbContext> options) : base(options)
        {

        }
    }
}
