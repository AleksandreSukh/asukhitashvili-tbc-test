using FluentValidation;
using Test.Data.Entities;

namespace Test.Data.EntityValidations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        private static readonly HashSet<string> ValidGenders = new HashSet<string>() { "male", "female" };
        public PersonValidator()
        {
            RuleFor(e => e.Name)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .WithErrorCode(ValidationError.NameMustNotBeEmpty)
                .MinimumLength(2)
                .WithErrorCode(ValidationError.NameLenghtMustBeAtLeast2Symbols)
                .MaximumLength(50)
                .WithErrorCode(ValidationError.NameLenghtMustBeAtMost50Symbols)
                .Must(n => n.IsGeorgianOrLatinText())
                .WithErrorCode(ValidationError.NameMustBeGeorgianOrLatinWord);

            RuleFor(e => e.Surname)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .WithErrorCode(ValidationError.SurnameMustNotBeEmpty)
                .MinimumLength(2)
                .WithErrorCode(ValidationError.SurnameLenghtMustBeAtLeast2Symbols)
                .MaximumLength(50)
                .WithErrorCode(ValidationError.SurnameLenghtMustBeAtMost50Symbols)
                .Must(n => n.IsGeorgianOrLatinText())
                .WithErrorCode(ValidationError.SurnameMustBeGeorgianOrLatinWord);

            RuleFor(e => e.Gender)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .WithErrorCode(ValidationError.GenderMustNotBeEmpty)
                .Must(g => ValidGenders.Contains(g))
                .WithErrorCode(ValidationError.GenderMustBeEitherMaleOrFemale);
        }
    }

    public class PersonalConnectionValidator
    {
    }

    public class PhoneNumberValidator
    {
    }
}
