using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmallShop.Infrastructure.Persistence.DatabaseContext;
using SmallShop.Query.Common;
using SmallShop.Query.Products.DTOs;

namespace SmallShop.Query.Products.GetByFilter;

internal class GetProductsByFilterQueryHandler : IQueryHandler<GetProductsByFilterQuery, ProductFilterResult>
{
    private readonly SmallShopContext _context;
    private readonly IMapper _mapper;


    public GetProductsByFilterQueryHandler(SmallShopContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductFilterResult> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Products.OrderByDescending(d => d.CreationDate).AsQueryable();

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new ProductFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}