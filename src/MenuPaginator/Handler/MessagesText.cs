using System.Globalization;
using System.Text.Json;
using TirsvadCLI.MenuPaginator.Model;

namespace TirsvadCLI.MenuPaginator.Handler
{
    public class Translator
    {
        //Translator()
        //{
        //}

        public string LookUpCustomText(string key, string? language = null)
        {
            if (language == null)
            {
                language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                if (!File.Exists("MessageText." + language + ".json"))
                {
                    language = "en";
                }
            }

            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                MessageText? messages = JsonSerializer
                .Deserialize<MessageText>
                (
                    File.ReadAllText("MessageText." + language + ".json"), options
                );

                if (messages is null || messages.Translations is null)
                {
                    throw new NullReferenceException("The specified language or translations were not found in the json file.");
                }

                if (!messages.Translations.TryGetValue(key, out string? translation))
                {
                    throw new KeyNotFoundException($"The key '{key}' was not found in the translations.");
                }

                return translation;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while looking up custom text.", ex);
            }
        }
    }
}
