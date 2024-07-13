using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Concrete;

namespace Persistence.Repositories;

public class EfBrandRepository : EfBaseRepository<Brand, Guid, BorusanDbContext>, IBrandRepository
{
    public EfBrandRepository(BorusanDbContext context) : base(context)
    {
    }
}