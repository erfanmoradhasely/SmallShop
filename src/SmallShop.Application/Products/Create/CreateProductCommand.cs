using SmallShop.Application.Common;
using SmallShop.Domain.Common.ValueObjects;

namespace SmallShop.Application.Products.Create;

public class CreateProductCommand : IBaseCommand
{
    public string Name { get; set; }
    public string ManufacturerEmail { get; set; }
    public string ManufacturerPhoneNumber { get; set; }
    public DateOnly ProductionDate { get; set; }
    public bool IsAvailable { get; set; }
    //to be set in the api
    public Guid UserId { get; set; }

}