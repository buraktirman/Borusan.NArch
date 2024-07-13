namespace Application.Features.Models.Commands.Create;

public class CreatedModelResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }
}
