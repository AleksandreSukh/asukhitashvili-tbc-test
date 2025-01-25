namespace Test.Data.EntityValidations;

public enum ValidationError
{
    UnknownError,
    NameMustNotBeEmpty,
    NameLenghtMustBeAtLeast2Symbols,
    NameLenghtMustBeAtMost50Symbols,
    NameMustBeGeorgianOrLatinWord,
    SurnameMustNotBeEmpty,
    SurnameLenghtMustBeAtLeast2Symbols,
    SurnameLenghtMustBeAtMost50Symbols,
    SurnameMustBeGeorgianOrLatinWord,
    GenderMustNotBeEmpty,
    GenderMustBeEitherMaleOrFemale,
    IdNumberMustNotBeEmpty,
    IdNumberMustBe11CharsLong,
    BirthDateMustBeSpecified,
    MustBeOlderThan18Years,
    CityIsNotValid,
    ConnectionTypeIsNotValid,
    InvalidPhoneNumber
}