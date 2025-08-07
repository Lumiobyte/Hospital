using Hospital.Models;
using Hospital.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI.Components
{
    public static class InputField
    {

        // Helper to prompt for an account login and validate the provided credentials
        public static IUser? PromptLogin(HospitalService hospitalService)
        {
            var userId = int.Parse(Prompt("ID", validator: Validators.UserId));
            var password = Prompt("Password", masked: true);

            return hospitalService.ValidateCredentials(userId, password);
        }

        // Prompt for an input. Optionally provide a Validator that will be run on the input and recurse if the input does not pass validation.
        public static string Prompt(string label, Predicate<string>? validator = null, bool masked = false) 
        {
            Console.Write($"{label}: ");

            string input = masked ? ReadMasked() : (Console.ReadLine() ?? "");

            if (validator != null)
                if (!validator(input))
                    return Prompt(label, validator, masked); // Recurse until a valid input is provided.

            return input;
            
        }

        // Prompt for an input as above, but also execute an action on succesful submit
        public static string Prompt(string label, Action<string> onSubmit, Predicate<string>? validator = null, bool masked = false)
        {
            var input = Prompt(label, validator, masked);

            onSubmit(input);

            return input;
        }

        // Read input and mask what was typed e.g. password input: "********"
        private static string ReadMasked()
        {

            Stack<char> input = new Stack<char>();

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Count > 0)
                    {
                        input.Pop();
                        Console.Write("\b \b"); // Replace the last * with a space (\b moves cursor back)
                    }
                }
                else if (char.IsLetterOrDigit(key.KeyChar) || char.IsWhiteSpace(key.KeyChar))
                {
                    input.Push(key.KeyChar);
                    Console.Write("*");
                }

            }

            Console.WriteLine();

            return String.Join("", input.Reverse());
        }

    }
}
