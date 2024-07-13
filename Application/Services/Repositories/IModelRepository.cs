using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IModelRepository : IBaseRepository<Model, Guid>, IAsyncBaseRepository<Model, Guid>
{
}
