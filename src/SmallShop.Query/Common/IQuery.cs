using MediatR;
using SmallShop.Query.Common.Filter;

namespace SmallShop.Query.Common;

public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class?
{
}

public class QueryFilter<TResponse, TParam> : IQuery<TResponse>
    where TResponse : BaseFilter
    where TParam : BaseFilterParam
{
    public TParam FilterParams { get; set; }
    public QueryFilter(TParam filterParams)
    {
        FilterParams = filterParams;
    }
}