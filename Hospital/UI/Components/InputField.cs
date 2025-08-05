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

        public static IUserAccount? PromptLogin(HospitalService hospitalService)
        {
            var userId = int.Parse(Prompt("ID", validator: Validators.UserId));
            var password = Prompt("Password", masked: true);

            return hospitalService.ValidateCredentials(userId, password);
        }

        public static string Prompt(string label, Predicate<string>? validator = null, bool masked = false) // it is possible to do Func<string, IUserAccount> testset, er.g. multiparam/outputs.
        {
            Console.Write($"{label}: ");

            string input = masked ? ReadMasked() : (Console.ReadLine() ?? "");

            if (validator != null)
                if (!validator(input))
                    Prompt(label, validator, masked); // Recurse until a valid input is provided.

            return input;
            
        }

        public static string Prompt(string label, Action<string> onSubmit, Predicate<string>? validator = null, bool masked = false)
        {
            var input = Prompt(label, validator, masked);

            onSubmit(input);

            return input;
        }

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
