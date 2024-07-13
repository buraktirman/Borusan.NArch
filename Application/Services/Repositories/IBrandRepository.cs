using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IBrandRepository : IBaseRepository<Brand, Guid>, IAsyncBaseRepository<Brand, Guid>
{
}