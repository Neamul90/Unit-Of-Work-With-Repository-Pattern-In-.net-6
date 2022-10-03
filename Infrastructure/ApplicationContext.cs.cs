using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Transactions;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
       
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Entity<Branch>().HasOne(e => e.Area).WithMany().OnDelete(DeleteBehavior.Restrict); 
            //modelBuilder.Entity<Branch>().HasOne(e => e.City).WithMany().OnDelete(DeleteBehavior.Restrict); 
            base.OnModelCreating(modelBuilder);

        }
    }
}