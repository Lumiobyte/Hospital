using Hospital.Repositories;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class CreateAppointmentMenu : IMenu
    {

        DoctorRepository _doctorRepository;
        PatientRepository _patientRepository;

        public CreateAppointmentMenu(DoctorRepository doctorRepository, PatientRepository patientRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("Book Appointment");
        }

        public void Show()
        {
            // If patient has no linked doctor - link one now.

            // Take appointment information and save.
        }

    }
}
