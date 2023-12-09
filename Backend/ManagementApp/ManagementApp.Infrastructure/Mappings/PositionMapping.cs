using ManagementApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.Infrastructure.Mappings
{
    public class PositionMapping : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            //builder.HasMany(x => x.Employees)
            //    .WithOne(x => x.Position)
            //    .HasForeignKey(x => x.PositionId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.ClientCascade);

            //builder.HasData(new Position
            //{
            //    Id = Guid.Parse("419c7253-f19c-4be1-88b3-fc473bc8c19d"),
            //    Name = "Manager",
            //    DepartmentId = Guid.Parse("673d92aa-6e4b-4dfd-a69c-5327d4248a6a")
            //}, new Position
            //{
            //    Id = Guid.Parse("41c1d152-e945-4852-b707-539ca262c083"),
            //    Name = "Employee",
            //    DepartmentId = Guid.Parse("673d92aa-6e4b-4dfd-a69c-5327d4248a6a")
            //}, new Position
            //{
            //    Id = Guid.Parse("f942f102-18a5-424a-9301-a5b21f7601b7"),
            //    Name = "Trainee",
            //    DepartmentId = Guid.Parse("673d92aa-6e4b-4dfd-a69c-5327d4248a6a")
            //}, new Position
            //{
            //    Id = Guid.Parse("419c7253-f19c-4be1-88b3-fc473bc8c19d"),
            //    Name = "Manager",
            //    DepartmentId = Guid.Parse("8d8ab517-6479-4731-a2c9-91b20e47d0fb")
            //}, new Position
            //{
            //    Id = Guid.Parse("41c1d152-e945-4852-b707-539ca262c083"),
            //    Name = "Employee",
            //    DepartmentId = Guid.Parse("8d8ab517-6479-4731-a2c9-91b20e47d0fb")
            //}, new Position
            //{
            //    Id = Guid.Parse("f942f102-18a5-424a-9301-a5b21f7601b7"),
            //    Name = "Trainee",
            //    DepartmentId = Guid.Parse("8d8ab517-6479-4731-a2c9-91b20e47d0fb")
            //}, new Position
            //{
            //    Id = Guid.Parse("419c7253-f19c-4be1-88b3-fc473bc8c19d"),
            //    Name = "Manager",
            //    DepartmentId = Guid.Parse("f393f22f-2f18-40cb-9491-d5d6c1b6fcca")
            //}, new Position
            //{
            //    Id = Guid.Parse("41c1d152-e945-4852-b707-539ca262c083"),
            //    Name = "Employee",
            //    DepartmentId = Guid.Parse("f393f22f-2f18-40cb-9491-d5d6c1b6fcca")
            //}, new Position
            //{
            //    Id = Guid.Parse("f942f102-18a5-424a-9301-a5b21f7601b7"),
            //    Name = "Trainee",
            //    DepartmentId = Guid.Parse("f393f22f-2f18-40cb-9491-d5d6c1b6fcca")
            //});
        }
    }
}
