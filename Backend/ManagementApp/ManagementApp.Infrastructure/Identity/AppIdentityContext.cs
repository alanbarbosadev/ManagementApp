using ManagementApp.Domain.Models.Identity;
using ManagementApp.Infrastructure.Identity.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Infrastructure.Identity
{
    public class AppIdentityContext : IdentityDbContext<AppUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppUserMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new AppUserRoleMapping());

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
