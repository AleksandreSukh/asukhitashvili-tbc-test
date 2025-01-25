using FluentValidation;
using Test.Data.Entities;

namespace Test.Data.EntityValidations
{
    public class PersonValidator : AbstractValidator<Person>
    {

        public PersonValidator(TestDbContext context)
        {
            var validCities = context.Cities.Select(c => c.Id).ToHashSet(); //TODO: Can be initialized into static cache depending on how often do we need to add new cities

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
                .Must(g => g.IsValidGender())
                .WithErrorCode(ValidationError.GenderMustBeEitherMaleOrFemale);

            RuleFor(e => e.IdNumber)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .WithErrorCode(ValidationError.IdNumberMustNotBeEmpty)
                .Length(11)
                .WithErrorCode(ValidationError.IdNumberMustBe11CharsLong);

            RuleFor(e => e.BirthDate)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .WithErrorCode(ValidationError.BirthDateMustBeSpecified);

            When(e => e.BirthDate.HasValue,
                () => RuleFor(i => i.BirthDate)
                    .Must(d => d!.Value.IsOlderThanYears(18))
                    .WithErrorCode(ValidationError.MustBeOlderThan18Years));

            When(e => e.CityId != null,
                () => RuleFor(e => e.CityId)
                    .Cascade(CascadeMode.Continue)
                    .Must(c => validCities.Contains(c.Value))
                    .WithErrorCode(ValidationError.CityIsNotValid));

            //When(e => !string.IsNullOrEmpty(e.Picture),
            //    () => RuleFor(e => e.Picture)
            //        .Cascade(CascadeMode.Continue)
            //        .Must(c => ValidateImagePath)
            //        .WithErrorCode(ValidationError.PictureFileCouldNotBeFound));
        }
    }
}
