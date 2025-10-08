using MediatR;

namespace StockInventoryApplication.Abstractions.Messaging;

public interface ICommand : IRequest<Unit> { }

// Değer dönen komutlar
public interface ICommand<out TResponse> : IRequest<TResponse> { }
