using System.Text.RegularExpressions;

namespace UserApp
{
    internal class InputValidator
    {
        public bool IsValidData(string name)
        {
            // regular expression that checks whether the entered name contains only letters and allowed characters
            string pattern = @"^[A-Za-z]*${1,25}";

            // Validate input using a regular expression
            return Regex.IsMatch(name, pattern);
        }

        public bool IsValidData(int id)
        {
             string idString = id.ToString();
            // regular expression that checks whether the entered name contains only letters and allowed characters
            string pattern = @"^\d+$${1,10}";

            // Validate input using a regular expression
            return Regex.IsMatch(idString, pattern);
        }

    }
}
