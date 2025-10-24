using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Products.Command.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<Unit>;
