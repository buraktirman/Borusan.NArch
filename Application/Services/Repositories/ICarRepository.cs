using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface ICarRepository : IAsyncBaseRepository<Car, Guid>, IBaseRepository<Car, Guid>
{
    Task<Car?> GetByPlateAsync(string plate);
}