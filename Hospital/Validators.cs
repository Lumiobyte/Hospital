using Hospital.Models;
using Hospital.Services;
using Hospital.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public static class Validators
    {

        // Validate that input contains only digits
        public static bool Numeric(string input)
        {
            bool valid = !string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit);
            if (!valid)
                Console.WriteLine("Error: Expected numeric input");
            return valid;
        }

        // In case the spec of a UserID changes in the future, we won't need to replace usages of the Numeric validator with a new one, instead simply changing the behaviour of this validator :)
        // This is very redundant for the hospital app but I'm trying to design things properly
        public static bool UserId(string input)
        {
            return Numeric(input);
        }

        // Validate email address
        public static bool EmailAddress(string input)
        {
            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool valid = !string.IsNullOrWhiteSpace(input) && System.Text.RegularExpressions.Regex.IsMatch(input, emailRegex);
            if (!valid)
                Console.WriteLine("Error: Not a valid email address");
            return valid;
        }

        // Validate phone number
        public static bool PhoneNumber(string input)
        {
            bool valid = Numeric(input) && (input.Length >= 9 && input.Length <= 10);
            if (!valid)
                Console.WriteLine("Error: Not a valid phone number");
            return valid;
        }

        public static bool NotNullString(string input)
        {
            bool valid = !string.IsNullOrWhiteSpace(input);
            if (!valid)
                Console.WriteLine("Error: Input cannot be empty");
            return valid;
        }

    }
}
