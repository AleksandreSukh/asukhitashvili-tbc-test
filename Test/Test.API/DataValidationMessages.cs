using System.Globalization;

namespace Test.API
{
    public static class DataValidationMessages
    {
        private static Dictionary<string, Dictionary<ValidationMessage, string>>? _localizations;

        public static string GetMessageLocalizedString(ValidationMessage message)
        {
            var language = CultureInfo.CurrentCulture.Name;
            
            //Using fake localization 
            return $"{language}: {message}";
            //return _localizations[language][message];
        }

        //Sample method for initializing localizations dictionary
        public static void InitializeFromSource(Dictionary<string, Dictionary<ValidationMessage, string>>? localizations)
        {
            _localizations = localizations;
        }
    }
}
