using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Extensions
{
    public static class UserAccountExtensions
    {

        // Helper to print out details for an IUserAccount in the non-tabulated format required for a couple of the menus e.g. "view my details for patient/doctor"
        public static void PrintUserDetails(this IUserAccount user)
        {
            Console.WriteLine($"{user.Name}'s Details");
            Console.WriteLine();
            Console.WriteLine($"{user.GetType().Name} ID: {user.Id}");
            Console.WriteLine($"Full Name: {user.FullName}");
            Console.WriteLine($"Address: {user.Address}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone: {user.PhoneNumber}");
        }

    }
}
