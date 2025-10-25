using FluentValidation;
using SmallShop.Application.Common.Validation;
using SmallShop.Application.Common.Validation.FluentValidations;

namespace SmallShop.Application.Products.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("شناسه محصول"));

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
}
