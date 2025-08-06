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
    public class AddNewUserMenu : IMenu
    {

        DoctorRepository _doctorRepository;
        PatientRepository _patientRepository;

        IUserAccount newUserType;

        public AddNewUserMenu(DoctorRepository doctorRepository, PatientRepository patientRepository, IUserAccount newUserType)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            this.newUserType = newUserType;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw($"Add {newUserType.GetType().Name}");
        }

        public void Show()
        {
            Console.WriteLine($"Registering a new {newUserType.GetType().Name} with the DotNet Hospital Management System");

            // Take info for all fields - can use reflection to get all fields that exist. Exclude ID. Save to DB.
        }
    }
}
