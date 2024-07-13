using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Concrete;

namespace Persistence.Repositories;

public class EfTransmissionRepository : EfBaseRepository<Transmission, Guid, BorusanDbContext>, ITransmissionRepository
{
    public EfTransmissionRepository(BorusanDbContext context) : base(context)
    {
    }
}
