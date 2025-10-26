

using SmallShop.Application.Common;

namespace SmallShop.Application.Products.Edit
{
    public class EditProductCommand : IBaseCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerEmail { get; set; }
        public string ManufacturerPhoneNumber { get; set; }
        public DateOnly ProductionDate { get; set; }
        public bool IsAvailable { get; set; }
        /// <summary>
        /// to be set in the api
        /// </summary>
        public Guid? UserId { get; set; }
    }
}