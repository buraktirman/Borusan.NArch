using Application.Encryption.JWT;
using Application.Pipeline.Example;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, TokenOptions tokenOptions)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(ExampleBehavior<,>)); // Herhangi bir TRequest ve TResponse için
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ITokenHelper, JwtHelper>(_ => new JwtHelper(tokenOptions));
        return services;
    }
}
