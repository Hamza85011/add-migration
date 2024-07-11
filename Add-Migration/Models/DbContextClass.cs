using Microsoft.EntityFrameworkCore;

namespace add_migration.Models
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() { }
        public DbContextClass(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        
    }
}
