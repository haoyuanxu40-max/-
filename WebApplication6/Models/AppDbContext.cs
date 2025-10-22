using Microsoft.EntityFrameworkCore;
using 系統端.Models;

namespace WebApplication4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Package> Packages { get; set; }
    }
}