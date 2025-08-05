using Hospital.Services;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class LoginMenu : IMenu
    {

        MenuFactory _menuFactory;
        ServiceFactory _serviceFactory;

        public LoginMenu(MenuFactory menuFactory, ServiceFactory serviceFactory)
        {
            _menuFactory = menuFactory;
            _serviceFactory = serviceFactory;
        }

        public void Load()
        {
            Console.Clear();
            // Display intro text
        }

        public void Show()
        {
            TakeAccountDetails();
        }

        // Prompt the user for a login. Recurse and prompt again if the attempt was unsuccessful.
        public void TakeAccountDetails()
        {
            var success = InputField.PromptLogin(_menuFactory, _serviceFactory);
            if(!success)
                TakeAccountDetails();
        }

    }
}
