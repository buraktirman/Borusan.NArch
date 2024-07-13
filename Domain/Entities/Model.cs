namespace Domain.Entities;

public class Model : BaseEntity<Guid>
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public virtual Brand Brand { get; set; } = default!;
    public virtual ICollection<Car> Cars { get; set; } = default!;
}
