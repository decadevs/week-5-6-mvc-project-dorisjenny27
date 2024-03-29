using First_Website_Challenge.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace First_Website_Challenge.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}
