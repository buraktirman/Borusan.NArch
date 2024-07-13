using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(c => c.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(c => c.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(c => c.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(c => c.SaleState).HasColumnName("SaleState").IsRequired();
        builder.Property(c => c.Plate).HasColumnName("Plate").IsRequired();
        builder.Property(c => c.ModelYear).HasColumnName("ModelYear").IsRequired();
        builder.Property(c => c.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(c => c.Model).WithMany(m => m.Cars).HasForeignKey(c => c.ModelId);
        builder.HasOne(c => c.Fuel).WithMany(f => f.Cars).HasForeignKey(c => c.FuelId);
        builder.HasOne(c => c.Transmission).WithMany(t => t.Cars).HasForeignKey(c => c.TransmissionId);
        builder.HasOne(c => c.Color).WithMany(c => c.Cars).HasForeignKey(c => c.ColorId);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
