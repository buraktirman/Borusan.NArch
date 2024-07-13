using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Concrete;

namespace Persistence.Repositories;

public class EfModelRepository : EfBaseRepository<Model, Guid, BorusanDbContext>, IModelRepository
{
    public EfModelRepository(BorusanDbContext context) : base(context)
    {
    }
}
