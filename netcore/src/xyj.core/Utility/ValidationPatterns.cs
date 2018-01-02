using System.Text.RegularExpressions;

namespace xyj.core.Utility
{
    public class ValidationPatterns
    {
        public const string UsernamePattern = "^([a-z0-9_\\-@\\.]){5,}$";

        public const string UsernameInvalidMessage = "Invalid username (At least 5 digits, characters[a-z0-9_-@.])";

        public const string PasswordPattern = "^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[!@#$%^&*].*).{8,}$";

        public const string PasswordInvalidMessage =
            "Invalid password (At least 8 digits, one capital letter[A-Z],one number[0-9], one special character[!@#$%^&*])";

        public const string WeakPasswordPattern = "([a-zA-Z0-9!@#$%^&*]){5,}";

        public const string WeakPasswordInvalidMessage =
            "Invalid password (At least 5 digits, characters[a-zA-Z0-9!@#$%^&*])";

        public static Regex UsernameRegex
        {
            get { return new Regex(UsernamePattern, RegexOptions.Compiled); }
        }

        public static Regex PasswordRegex
        {
            get { return new Regex(PasswordPattern, RegexOptions.Compiled); }
        }

        public static Regex WeakPasswordRegex
        {
            get { return new Regex(WeakPasswordPattern, RegexOptions.Compiled); }
        }
    }
}