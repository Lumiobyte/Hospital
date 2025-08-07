using Hospital.Extensions;
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
            user.PrintUserDetails();
            InputDevice.DelayExitUntilPress();
        }


    }
}
