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

        public PatientMenu(PatientRepository patientRepository, Patient user)
        {
            _user = user;
            _repository = patientRepository;
        }

        // Prepare this menu for rendering and interaction
        public void Load()
        {
            Console.Clear();
            TitleBox.DrawTitleBox("Patient Menu");
        }

        // Render this menu
        public void Show()
        {
            var option = int.Parse(InputField.Prompt("Please choose an option", Validators.Numeric));

            switch (option)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
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
