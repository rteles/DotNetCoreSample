using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DotNetSample.Domain.Entities;

namespace DotNetSample.Infra.Repository.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Name)
               .IsRequired()
               .HasMaxLength(100);

            entity.Property(o => o.LastName)
                .IsRequired(false)
                .HasMaxLength(100);

            entity.Property(o => o.BirthDate)
                .IsRequired();

            entity.Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(o => o.Active)
                .IsRequired();
        }
    }
}