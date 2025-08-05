using Hospital.Models;
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
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit);
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
            return !string.IsNullOrWhiteSpace(input) && System.Text.RegularExpressions.Regex.IsMatch(input, emailRegex);
        }

        // Validate phone number
        public static bool PhoneNumber(string input)
        {
            return Numeric(input) && (input.Length >= 9 && input.Length <= 10);
        }

        public static bool LoginProcessor(string userId, string password)
        {
            IUserAccount? user = CheckPassword();

            if (user == null)
                Console.WriteLine("Invalid login credentials");
                return false;

            IMenu newMenu = MenuFactory(user);
            MenuState.Instance.Push(newMenu);

            Console.WriteLine("Valid Credentials");
            return true;
        }

    }
}
