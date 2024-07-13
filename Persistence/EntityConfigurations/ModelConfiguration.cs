using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(m => m.Name).HasColumnName("Name").IsRequired();
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(m => m.Brand).WithMany(b => b.Models).HasForeignKey(m => m.BrandId);
        builder.HasMany(m => m.Cars).WithOne(c => c.Model).HasForeignKey(c => c.ModelId);

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}
