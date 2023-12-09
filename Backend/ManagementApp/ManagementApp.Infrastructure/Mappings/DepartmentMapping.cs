using ManagementApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.Infrastructure.Mappings
{
    public class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            //builder.HasMany(x => x.Employees)
            //    .WithOne(x => x.Department)
            //    .HasForeignKey(x => x.DepartmentId)
            //    .OnDelete(DeleteBehavior.ClientCascade);

            //builder.HasData(new Department
            //{
            //    Id = Guid.Parse("673d92aa-6e4b-4dfd-a69c-5327d4248a6a"),
            //    Name = "Accounting"
            //}, new Department
            //{
            //    Id = Guid.Parse("8d8ab517-6479-4731-a2c9-91b20e47d0fb"),
            //    Name = "Marketing"
            //},
            //new Department
            //{
            //    Id = Guid.Parse("f393f22f-2f18-40cb-9491-d5d6c1b6fcca"),
            //    Name = "Humam Resources"
            //});
        }
    }
}
