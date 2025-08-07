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
    public class AddPatientMenu : IMenu
    {

        PatientRepository _patientRepository;
        IUserAccount _emptyAccount;

        public AddPatientMenu(PatientRepository patientRepository, IUserAccount emptyAccount)
        {
            _patientRepository = patientRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw($"Add {_emptyAccount.GetType().Name}");
        }

        public void Show()
        {
            var firstName = InputField.Prompt("First Name", Validators.NotNullString);
            var lastName = InputField.Prompt("Last Name", Validators.NotNullString);
            var email = InputField.Prompt("Email", Validators.EmailAddress);
            var phone = InputField.Prompt("Phone", Validators.PhoneNumber);
            var address = InputField.Prompt("Address", Validators.NotNullString);
            var patient = new Patient() { };
            _patientRepository.Add(patient);
            Console.WriteLine($"{_} {patient.FullName} added successfully!");
            InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
