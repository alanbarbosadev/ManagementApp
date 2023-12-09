using ManagementApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.Infrastructure.Mappings
{
    public class ActivityMapping : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.StartDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.EndDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasMany(x => x.Employees)
                .WithMany(x => x.Activities);
        }
    }
}
