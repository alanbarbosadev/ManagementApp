using ManagementApp.Domain.Models;
using ManagementApp.Infrastructure.Mappings;
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

            modelBuilder.ApplyConfiguration(new EmployeeMapping());
            modelBuilder.ApplyConfiguration(new DepartmentMapping());
            modelBuilder.ApplyConfiguration(new PositionMapping());
            modelBuilder.ApplyConfiguration(new ActivityMapping());

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
