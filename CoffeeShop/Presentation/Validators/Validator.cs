

namespace CoffeeShop.Presentation.Validators
{
    public static class Validator
    {
        public static bool IsValidInteger(string value,out int intValue)
        {
            return int.TryParse(value, out intValue);
        }

        public static bool IsValidUsername(string username)
        {
            return username.All(c => char.IsLetterOrDigit(c));
        }

        internal static bool IsValidName(string name)
        {
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
    }
}
