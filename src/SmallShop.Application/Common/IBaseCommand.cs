using MediatR;

namespace SmallShop.Application.Common;

public interface IBaseCommand : IRequest<OperationResult>
{
}

public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
{
}