using Hospital.Models;
using Hospital.Repositories;
using Hospital.Services;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class AddNewUserMenu : IMenu
    {

        HospitalService _hospitalService;
        IUserAccount _newAccount;

        public AddNewUserMenu(HospitalService hospitalService, IUserAccount emptyAccount)
        {
            _hospitalService = hospitalService;
            _newAccount = emptyAccount;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw($"Add {_newAccount.GetType().Name}");
        }

        public void Show()
        {
            var firstName = InputField.Prompt("First Name", Validators.NotNullString);
            var lastName = InputField.Prompt("Last Name", Validators.NotNullString);
            var email = InputField.Prompt("Email", Validators.EmailAddress);
            var phone = InputField.Prompt("Phone", Validators.PhoneNumber);
            var address = InputField.Prompt("Address", Validators.NotNullString);

            _hospitalService.AddUserAccount(_newAccount);

            Console.WriteLine($"{_newAccount.GetType().Name} {_newAccount.FullName} added successfully!");
            InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }
    }
}
