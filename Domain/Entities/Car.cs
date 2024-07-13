using Domain.Enums;

namespace Domain.Entities;

public class Car : BaseEntity<Guid>
{
    // UUID
    public Guid ModelId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid ColorId { get; set; }
    public SaleState SaleState { get; set; }
    public string Plate { get; set; }
    public int ModelYear { get; set; }
    public long Kilometer { get; set; }

    public virtual Model Model { get; set; } = default!;
    public virtual Fuel Fuel { get; set; } = default!;
    public virtual Transmission Transmission { get; set; } = default!;
    public virtual Color Color { get; set; } = default!;
}
