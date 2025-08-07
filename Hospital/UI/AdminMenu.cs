using Hospital.Models;
using Hospital.Repositories;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class AdminMenu : IMenu
    {

        Admin _user;
        AdminRepository _repository;
        MenuFactory _menuFactory;

        public AdminMenu(MenuFactory menuFactory, AdminRepository adminRepository, Admin user)
        {
            _user = user;
            _repository = adminRepository;
            _menuFactory = menuFactory;
        }

        // Prepare this menu for rendering and interaction
        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("Administrator Menu");
            Console.WriteLine($"Welcome to DotNet Hospital Management System ADMINISTRATOR\n\n");
            Console.WriteLine("Please choose an option:\n1. List all doctors\n2. Check doctor details\n3. List all patients\n4. Check patient details\n5. Add doctor\n6. Add patient\n7. Logout\n8. Exit System");
        }

        // Render this menu
        public void Show()
        {
            var option = int.Parse(InputField.Prompt("Please choose an option", Validators.Numeric));

            switch (option)
            {
                case 1:
                    _menuFactory.CreateMenu<ListAllDoctorsMenu>();
                    break;
                case 2:
                    _menuFactory.CreateMenu<ViewDoctorDetailMenu>();
                    break;
                case 3:
                    _menuFactory.CreateMenu<ListAllPatientsMenu>();
                    break;
                case 4:
                    _menuFactory.CreateMenu<ViewPatientDetailMenu>();
                    break;
                case 5:
                    _menuFactory.CreateMenu<AddNewUserMenu>(new Doctor());
                    break;
                case 6:
                    _menuFactory.CreateMenu<AddNewUserMenu>(new Patient());
                    break;
                case 7:
                    MenuState.Instance.Pop();
                    break;
                case 8:
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
