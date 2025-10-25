using SmallShop.Domain.Common.ValueObjects;
using SmallShop.Query.Common;

namespace SmallShop.Query.Products.DTOs;

public class ProductDto : BaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ManufacturerEmail { get; set; }
    public string ManufacturerPhoneNumber { get; set; }
    public DateOnly ProductionDate { get; set; }
    public bool IsAvailable { get; set; }
    public Guid UserId { get; set; }
}