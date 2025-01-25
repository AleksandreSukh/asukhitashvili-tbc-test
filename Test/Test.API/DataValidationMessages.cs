using System.Globalization;
using Test.Data.EntityValidations;

namespace Test.API
{
    public static class DataValidationMessages
    {
        private static Dictionary<string, Dictionary<ValidationError, string>>? _localizations;

        public static string ToLocalizedString(this ValidationError message)
        {
            var language = CultureInfo.CurrentCulture.Name;
            
            //Using fake localization 
            return $"{language}: {message}";
            //return _localizations[language][message];
        }

        //Sample method for initializing localizations dictionary
        public static void InitializeFromSource(Dictionary<string, Dictionary<ValidationError, string>>? localizations)
        {
            _localizations = localizations;
        }
    }
}
