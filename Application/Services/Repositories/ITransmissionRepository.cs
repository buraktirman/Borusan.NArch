using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface ITransmissionRepository : IBaseRepository<Transmission, Guid>, IAsyncBaseRepository<Transmission, Guid>
{
}
