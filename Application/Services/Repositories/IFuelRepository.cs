using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IFuelRepository : IBaseRepository<Fuel, Guid>, IAsyncBaseRepository<Fuel, Guid>
{
}
