using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Pipeline.Authentication;

public class AuthenticationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest, new()
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
            throw new Exception("Giriş yapmadan bu endpointi çalıştıramazsınız.");

        TResponse response = await next();

        return response;
    }
}
