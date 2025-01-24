using FluentValidation;
using System.Text.RegularExpressions;

namespace Test.Data.EntityValidations;

public static class ValidationExtensions
{
    private static readonly Regex GeorgianWordRegex = new Regex("^[ა-ჰ]+$");
    private static readonly Regex LatinWordRegex = new Regex("^[a-zA-Z]+$");
    public static bool IsGeorgianOrLatinText(this string input) => GeorgianWordRegex.IsMatch(input) || LatinWordRegex.IsMatch(input);

    public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule,
        ValidationError errorCode) => rule.WithErrorCode(errorCode.ToString());
}