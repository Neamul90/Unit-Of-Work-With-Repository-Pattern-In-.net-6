using Microsoft.EntityFrameworkCore;
using UnitOfWorkWithRepositoryPattern.Model;

namespace UnitOfWorkWithRepositoryPattern.Context
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
