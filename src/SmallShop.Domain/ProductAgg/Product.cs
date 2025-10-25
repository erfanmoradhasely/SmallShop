using SmallShop.Domain.Common;
using SmallShop.Domain.Common.ValueObjects;
using SmallShop.Domain.ProductAgg.Exceptions;
using SmallShop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Email ManufacturerEmail { get; private set; }
        public PhoneNumber ManufacturerPhoneNumber { get; private set; }
        public DateOnly ProductionDate { get; private set; }
        public bool IsAvailable { get; private set; }
        public Guid UserId { get; private set; }


        public Product(string name, Email manufacturerEmail,DateOnly productionDate,
            PhoneNumber manufacturerPhoneNumber, bool isAvailable, Guid userId
            ,IProductDomainService productDomainService)
        {
            GuardAgainstDuplicateProduct(manufacturerEmail, productionDate, productDomainService).GetAwaiter().GetResult();

            Id = Guid.NewGuid();
            Name = name;
            ManufacturerEmail = manufacturerEmail;
            ManufacturerPhoneNumber = manufacturerPhoneNumber;
            ProductionDate = productionDate;
            IsAvailable = isAvailable;
            UserId = userId;
        }
        public async Task Edit(string name, Email manufacturerEmail, DateOnly productionDate,
            PhoneNumber manufacturerPhoneNumber, bool isAvailable, Guid userId
            , IProductDomainService productDomainService)
        {
            await GuardAgainstDuplicateProduct(manufacturerEmail, productionDate, productDomainService);
            GuardAgainstWrongUserId(userId);

            Name = name;
            ManufacturerEmail = manufacturerEmail;
            ManufacturerPhoneNumber = manufacturerPhoneNumber;
            ProductionDate = productionDate;
            IsAvailable = isAvailable;
        }
        /// <summary>
        /// throws if user is not the owner
        /// </summary>
        /// <param name="userId"></param>
        public void CanBeDeletedOrUpdatedBy(Guid userId)
        {
            GuardAgainstWrongUserId(userId);
        }




        private void GuardAgainstWrongUserId(Guid userId)
        {
            if (UserId != userId)
             throw new InvalidUserDomainDataException();
        }
        private async Task GuardAgainstDuplicateProduct(string manufacturerEmail, DateOnly productionDate
            ,IProductDomainService productDomainService)
        {
            if (await productDomainService.ProductExists(manufacturerEmail, productionDate))
                throw new DuplicateProductDomainDataException("محصول با این ایمیل تولید کننده و تاریخ قبلا ایجاد شده است");
        }

    }
}

