using Domain.Enums;

namespace Application.Features.Cars.Queries.GetAll;

public class GetAllCarItemResponse
{
    public Guid Id { get; set; }
    public Guid ModelId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid ColorId { get; set; }
    public SaleState SaleState { get; set; }
    public string Plate { get; set; }
    public int ModelYear { get; set; }
    public long Kilometer { get; set; }
}
