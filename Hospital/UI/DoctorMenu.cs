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
    public class DoctorMenu : IMenu
    {

        Doctor _user;
        DoctorRepository _repository;
        MenuFactory _menuFactory;

        public DoctorMenu(MenuFactory menuFactory, DoctorRepository doctorRepository, Doctor user)
        {
            _user = user;
            _repository = doctorRepository;
            _menuFactory = menuFactory;
        }

        // Prepare this menu for rendering and interaction
        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("Doctor Menu");
            Console.WriteLine($"Welcome to DotNet Hospital Management System {_user.FullName}\n\n");
            Console.WriteLine("Please choose an option:\n1. List doctor details\n2. List patients\n3. List all appointments\n4. Check patient\n5. List appointments with patient\n6. Logout\n7. Exit System");
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
                    _menuFactory.CreateMenu<ListAllPatientsMenu>(_user);
                    break;
                case 3:
                    _menuFactory.CreateMenu<ListAppointmentsForDoctorMenu>(_user);
                    break;
                case 4:
                    _menuFactory.CreateMenu<ViewPatientDetailMenu>();
                    break;
                case 5:
                    _menuFactory.CreateMenu<DoctorViewPatientAppointmentListWrapperMenu>();
                    break;
                case 6:
                    MenuState.Instance.Pop();
                    break;
                case 7:
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
