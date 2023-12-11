using ManagementApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ManagementApp.Infrastructure.DataContext
{
    public class ManagementAppContext : DbContext
    {
        public ManagementAppContext(DbContextOptions<ManagementAppContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
