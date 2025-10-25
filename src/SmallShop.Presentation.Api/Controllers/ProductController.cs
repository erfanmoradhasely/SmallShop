using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallShop.Application.Common;
using SmallShop.Application.Products.Create;
using SmallShop.Application.Products.Delete;
using SmallShop.Application.Products.Edit;
using SmallShop.Contracts.Identity.Models;
using SmallShop.Presentation.Api.Models;
using SmallShop.Presentation.Api.Utilities;
using SmallShop.Query.Products.DTOs;
using SmallShop.Query.Products.GetByFilter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmallShop.Presentation.Api.Controllers;

[Authorize]
public class ProductController : ApiController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
    {
        return QueryResult(await _mediator.Send(new GetProductsByFilterQuery(filterParams)));
    }

    [HttpPost]
    public async Task<ApiResult<Guid>> CreateProduct(CreateProductCommand command)
    {
        command.UserId = User.GetUserId();
        var result = await _mediator.Send(command);
        return CommandResult(result
            ,System.Net.HttpStatusCode.Created, $"/api/products/{result.Data}");
    }

    [HttpPut]
    public async Task<ApiResult> EditProduct(EditProductCommand command)
    {
        command.UserId = User.GetUserId();
        return CommandResult(await _mediator.Send(command),System.Net.HttpStatusCode.NoContent);
    }

    [HttpDelete]
    public async Task<ApiResult> DeleteProduct([FromQuery] DeleteProductCommand command)
    {
        command.UserId = User.GetUserId();
        return CommandResult(await _mediator.Send(command));
    }
}
