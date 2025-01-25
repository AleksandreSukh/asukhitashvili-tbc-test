using FluentValidation;
using Test.Data.Entities;

namespace Test.Data.EntityValidations;

public class PhoneNumberValidator : AbstractValidator<PhoneNumber>
{
    public PhoneNumberValidator()
    {
        RuleFor(e => e.Number)
            .Cascade(CascadeMode.Continue)
            .Must(ct => ct.IsValidPhoneNumber())
            .WithErrorCode(ValidationError.InvalidPhoneNumber);
    }
}