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
        }

        // Render this menu
        public void Show()
        {
            var option = int.Parse(InputField.Prompt("Please choose an option", Validators.Numeric));

            switch (option)
            {
                case 0:
                    MenuState.Instance.Push(new ViewMyDetailsMenu(_user));
                    break;
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    _menuFactory.CreateMenu<CreateAppointmentMenu>();
                    break;
                case 5:
                    MenuState.Instance.Pop();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine($"Error: No option exists for {option}");
                    break;
            }
        }
    }
}
