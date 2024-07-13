namespace Domain.Entities;

public class Brand : BaseEntity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; } = default!;
}
