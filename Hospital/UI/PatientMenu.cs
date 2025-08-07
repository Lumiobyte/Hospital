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
    public class PatientMenu : IMenu
    {

        Patient _user;
        PatientRepository _repository;
        MenuFactory _menuFactory;

        public PatientMenu(MenuFactory menuFactory, PatientRepository patientRepository, Patient user)
        {
            _user = user;
            _repository = patientRepository;
            _menuFactory = menuFactory;
        }

        // Prepare this menu for rendering and interaction
        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("Patient Menu");
            Console.WriteLine($"Welcome to DotNet Hospital Management System {_user.FullName}\n\n");
            Console.WriteLine("Please choose an option:\n1. List patient details\n2. List my doctor details\n3. List all appointments\n4. Book appointment\n5. Exit to login\n6. Exit System");
        }

        // Render this menu
        public void Show()
        {
            var option = int.Parse(InputField.Prompt("Please choose an option", Validators.Numeric));

            switch (option)
            {
                case 1:
                    MenuState.Instance.Push(new ViewMyDetailsMenu(_user));
                    break;
                case 2:
                    _menuFactory.CreateMenu<ViewMyDoctorDetailsMenu>(_user);
                    break;
                case 3:
                    _menuFactory.CreateMenu<ListAppointmentsForPatientMenu>(_user);
                    break;
                case 4:
                    _menuFactory.CreateMenu<CreateAppointmentMenu>(_user);
                    break;
                case 5:
                    MenuState.Instance.Pop();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"Error: No option exists for {option}");
                    InputDevice.DelayUntilPress(() => { VisualDevice.ClearPreviousLines(2); });
                    break;
            }
        }
    }
}
