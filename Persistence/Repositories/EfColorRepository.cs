using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Concrete;

namespace Persistence.Repositories;

public class EfColorRepository : EfBaseRepository<Color, Guid, BorusanDbContext>, IColorRepository
{
    public EfColorRepository(BorusanDbContext context) : base(context)
    {
    }
}
