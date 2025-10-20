using System;

namespace StockInventoryApplication.Common.SoftDelete;

public record SoftDeleteResult(int Effected,
    IReadOnlyList<Guid> NotFound,
    IReadOnlyList<Guid> AlreadyDeleted);

