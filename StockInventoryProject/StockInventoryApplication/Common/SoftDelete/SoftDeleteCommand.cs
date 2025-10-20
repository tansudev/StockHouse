using MediatR;
using StockInventoryDomain.Common;

namespace StockInventoryApplication.Common.SoftDelete;

public record SoftDeleteCommand<TAggregate>(IReadOnlyList<Guid> Ids) : IRequest<SoftDeleteResult> where TAggregate : SoftDeletableAggregate;

