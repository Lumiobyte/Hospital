using Hospital.Models;
using Hospital.Repositories;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class ViewMyDetailsMenu : IMenu
    {

        IUserAccount user;

        public ViewMyDetailsMenu(IUserAccount user)
        {
            this.user = user;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("My Details");
        }

        public void Show()
        {
            Console.WriteLine($"{user.Name}'s Details");
            Console.WriteLine();
            Console.WriteLine($"Patient ID: {user.Id}");
            Console.WriteLine($"Full Name: {user.Name} {user.Surname}");
            Console.WriteLine($"Address: {user.Address}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone: {user.PhoneNumber}");

            InputDevice.DelayExitUntilPress();
        }


    }
}
