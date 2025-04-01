using DocoSoftTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocoSoftTest.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
