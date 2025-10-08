using MediatR;
using StockInventoryApplication.Abstractions.Messaging;
using StockInventoryDomain.Abstractions;
namespace StockInventoryApplication;

public class EfCommitBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        var isCommand = request is ICommand || request is ICommand<TResponse>;
        if (isCommand)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return response;
    }
}
