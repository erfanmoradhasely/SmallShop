
using FluentValidation;
using SmallShop.Application.Common.Validation;
using SmallShop.Application.Common.Validation.FluentValidations;
using SmallShop.Domain.Common.Utils;

namespace SmallShop.Application.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(r => r.ManufacturerEmail)
            .ValidEmail();

        RuleFor(r => r.ManufacturerPhoneNumber)
            .ValidPhoneNumber();

        RuleFor(r => r.UserId)
            .NotEqual(Guid.Empty).WithMessage(ValidationMessages.required("شناسه کاربری"));

        RuleFor(r => r.ProductionDate)
           .NotEmpty().WithMessage(ValidationMessages.required("تاریخ"));

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("نام محصول"));

    }
}