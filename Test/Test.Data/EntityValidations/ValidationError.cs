namespace Test.Data.EntityValidations;

public enum ValidationError
{
    UnknownError,
    DataFormatIsNotValid,
    NameMustNotBeEmpty,
    NameLenghtMustBeAtLeast2Symbols,
    NameLenghtMustBeAtMost50Symbols,
    NameMustBeGeorgianOrLatinWord,
    SurnameMustNotBeEmpty,
    SurnameLenghtMustBeAtLeast2Symbols,
    SurnameLenghtMustBeAtMost50Symbols,
    SurnameMustBeGeorgianOrLatinWord,
    GenderMustNotBeEmpty,
    GenderMustBeEitherMaleOrFemale
}