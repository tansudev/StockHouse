using MediatR;
using StockInventoryDomain.Abstractions;
using StockInventoryDomain.Common;

namespace StockInventoryApplication.Common.SoftDelete;

public class SoftDeleteCommandHandler<TAggregate> : IRequestHandler<SoftDeleteCommand<TAggregate>, SoftDeleteResult>
    where TAggregate : SoftDeletableAggregate
{
    private readonly IRepository<TAggregate> _repository;
    private readonly ICurrentUser _currentUser;
    private readonly INow _now;
    private readonly IUnitOfWork _unitOfWork;

    public SoftDeleteCommandHandler(IRepository<TAggregate> repository, ICurrentUser currentUser, INow now, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _currentUser = currentUser;
        _now = now;
        _unitOfWork = unitOfWork;
    }
    public async Task<SoftDeleteResult> Handle(SoftDeleteCommand<TAggregate> request, CancellationToken cancellationToken)
    {
        var Ids = request.Ids.Distinct().ToList();
        var entities = await _repository.GetByIdsAsync(Ids, cancellationToken);

        var FoundIds = entities.Select(e => e.Id).ToHashSet();
        var NotFound = Ids.Where(id => !FoundIds.Contains(id)).ToList();

        var AlreadyDeleted = new List<Guid>();
        var effected = 0;
        foreach (var entity in entities)
        {
            if (entity.IsDeleted)
            {
                AlreadyDeleted.Add(entity.Id);
            }
            else
            {
                entity.MarkAsDeleted(_currentUser.UserId, _now.UtcNow);
                effected++;
            }
        }

        if (effected > 0)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return new SoftDeleteResult(effected, NotFound, AlreadyDeleted);
    }
}
