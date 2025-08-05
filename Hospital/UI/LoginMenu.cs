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
        HospitalService _hospitalService;

        public LoginMenu(MenuFactory menuFactory, HospitalService hospitalService)
        {
            _menuFactory = menuFactory;
            _hospitalService = hospitalService;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.DrawTitleBox("Login");
        }

        public void Show()
        {
            TakeAccountDetails();
        }

        // Prompt the user for a login. Recurse and prompt again if the attempt was unsuccessful.
        public void TakeAccountDetails()
        {
            var user = InputField.PromptLogin(_hospitalService);
            if (user != null)
                InputDevice.DelayUntilPress(() => { MenuState.Instance.Push(_menuFactory.CreateUserMenu(user)); });
            else
                TakeAccountDetails();
        }

    }
}

