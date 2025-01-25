using FluentValidation;
using Test.Data.Entities;

namespace Test.Data.EntityValidations;

public class PersonalConnectionValidator : AbstractValidator<PersonalConnection>
{
    public PersonalConnectionValidator()
    {
        RuleFor(e => e.ConnectionTypeId)
            .Cascade(CascadeMode.Continue)
            .Must(ct => ct.IsValidConnectionType())
            .WithErrorCode(ValidationError.ConnectionTypeIsNotValid);
    }
}