using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Concrete;

namespace Persistence.Repositories;

public class EfUserRepository : EfBaseRepository<User, Guid, BorusanDbContext>, IUserRepository
{
    public EfUserRepository(BorusanDbContext context) : base(context)
    {
    }
}
