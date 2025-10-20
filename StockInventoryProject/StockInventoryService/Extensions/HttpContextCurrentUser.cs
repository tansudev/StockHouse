using System;
using System.Linq.Expressions;
using StockInventoryDomain.Abstractions;

namespace StockInventoryService.Extensions;

public class HttpContextCurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _http;
    public HttpContextCurrentUser(IHttpContextAccessor http) => _http = http;

    public Guid? UserId
    {
        get
        {
            var sub = _http.HttpContext?.User?.FindFirst("sub")?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;

        }
    }
}