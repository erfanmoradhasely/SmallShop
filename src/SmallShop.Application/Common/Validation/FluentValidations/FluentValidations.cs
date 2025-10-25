using FluentValidation;
using SmallShop.Domain.Common.Utils;

namespace SmallShop.Application.Common.Validation.FluentValidations;

public static class FluentValidations
{
    public static IRuleBuilderOptionsConditions<T, string> ValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = ValidationMessages.InvalidEmail)
    {
        return ruleBuilder.Custom((email, context) =>
        {
            if (string.IsNullOrWhiteSpace(email) || !email.IsValidEmail())
                context.AddFailure(errorMessage);
        });
    }
    public static IRuleBuilderOptionsConditions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = ValidationMessages.InvalidPhoneNumber)
    {
        return ruleBuilder.Custom((phoneNumber, context) =>
        {
           if(string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length is < 11 or > 11)
               context.AddFailure(errorMessage);

        });
    }
}