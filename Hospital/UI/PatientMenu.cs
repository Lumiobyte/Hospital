using Hospital.Models;
using Hospital.Repositories;
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
        }

        // Render this menu
        public void Show()
        {

        }
    }
}
