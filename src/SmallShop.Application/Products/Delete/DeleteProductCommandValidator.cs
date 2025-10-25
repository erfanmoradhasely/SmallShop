using FluentValidation;
using SmallShop.Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Application.Products.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("شناسه محصول"));


            RuleFor(r => r.UserId)
               .NotEqual(Guid.Empty).WithMessage(ValidationMessages.required("شناسه کاربری"));
        }
    }
}
