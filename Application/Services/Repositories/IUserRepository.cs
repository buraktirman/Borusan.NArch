using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserRepository : IBaseRepository<User, Guid>, IAsyncBaseRepository<User, Guid>
{
}
