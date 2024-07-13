using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Concrete;

namespace Persistence.Repositories;

public class EfCarRepository : EfBaseRepository<Car, Guid, BorusanDbContext>, ICarRepository
{
    public EfCarRepository(BorusanDbContext context) : base(context)
    {
    }

    public async Task<Car?> GetByPlateAsync(string plate)
    {
        return await Context.Set<Car>().FirstOrDefaultAsync(c => c.Plate == plate);
    }
}
