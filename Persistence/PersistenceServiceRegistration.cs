using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BorusanDbContext>();
        services.AddScoped<IModelRepository, EfModelRepository>();
        services.AddScoped<ICarRepository, EfCarRepository>();
        services.AddScoped<IFuelRepository, EfFuelRepository>();
        services.AddScoped<ITransmissionRepository, EfTransmissionRepository>();
        services.AddScoped<IColorRepository, EfColorRepository>();
        services.AddScoped<IBrandRepository, EfBrandRepository>();

        return services;
    }
}
