namespace Domain.Entities;

public class Color : BaseEntity<Guid>
{
    public string Name { get; set; }

    public ICollection<Car> Cars { get; set; } = default!;
}