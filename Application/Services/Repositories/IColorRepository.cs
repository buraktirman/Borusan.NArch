using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IColorRepository : IBaseRepository<Color, Guid>, IAsyncBaseRepository<Color, Guid>
{
}