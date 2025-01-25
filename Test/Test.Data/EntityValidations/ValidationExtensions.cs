using FluentValidation;
using System.Text.RegularExpressions;
using Test.Data.Entities.Enums;

namespace Test.Data.EntityValidations;

internal static class ValidationExtensions
{
    private static readonly Regex GeorgianWordRegex = new Regex("^[ა-ჰ]+$");
    private static readonly Regex LatinWordRegex = new Regex("^[a-zA-Z]+$");
    private static readonly Regex PhoneNumberRegex = new Regex("^[0-9]{4,50}$");
    private static readonly HashSet<string> ValidGenders = new() { "male", "female" };
    private static readonly HashSet<int> ValidConnectionTypes = Enum.GetValues(typeof(ConnectionTypeEnum)).Cast<int>().ToHashSet();

    public static bool IsGeorgianOrLatinText(this string input) => GeorgianWordRegex.IsMatch(input) || LatinWordRegex.IsMatch(input);
    public static bool IsValidGender(this string input) => ValidGenders.Contains(input);
    public static bool IsValidPhoneNumber(this string input) => PhoneNumberRegex.IsMatch(input);
    public static bool IsValidConnectionType(this int input) => ValidConnectionTypes.Contains(input);
    public static bool IsOlderThanYears(this DateTime input, int years)
    {
        var currentDate = DateTime.Today;
        var yearsDiff = currentDate.Year - input.Year;

        return yearsDiff > years 
               || (yearsDiff == years && currentDate.DayOfYear - input.DayOfYear >= 0);
    }

    public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule,
        ValidationError errorCode) => rule.WithErrorCode(errorCode.ToString());
}