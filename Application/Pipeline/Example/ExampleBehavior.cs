using MediatR;

namespace Application.Pipeline.Example;

public class ExampleBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.WriteLine("Example Bheavior Çalıştı.");

        TResponse response = await next();

        Console.WriteLine("Request çalıştı, example behavior tekrar çalıştı");

        return response;
    }
}
