using ManagementApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.Infrastructure.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Birthday)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.HiredAt)
                .IsRequired()
                .HasColumnType("date");

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.Activities)
                .WithMany(x => x.Employees);
        }
    }
}
