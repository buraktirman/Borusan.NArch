﻿namespace Domain.Entities;

public class Transmission : BaseEntity<Guid>
{
    public string Name { get; set; }

    public ICollection<Car> Cars { get; set; } = default!;
}
