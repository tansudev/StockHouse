

using MediatR;

namespace StockInventoryApplication.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Log the request
        Console.WriteLine($"Handling {typeof(TRequest).Name}");

        var response = await next();

        // Log the response
        Console.WriteLine($"Handled {typeof(TRequest).Name}");

        return response;
    }
}
