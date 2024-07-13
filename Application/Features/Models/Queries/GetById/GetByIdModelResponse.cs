namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }
}
