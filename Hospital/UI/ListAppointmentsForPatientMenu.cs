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
    public class ListAppointmentsForPatientMenu : IMenu
    {

        PatientRepository _repository;
        Patient patient;

        public ListAppointmentsForPatientMenu(PatientRepository patientRepository, Patient patient)
        {
            _repository = patientRepository;
            this.patient = patient;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("View Appointments");
        }

        public void Show()
        {
            Console.WriteLine($"Appointments for {patient.FullName}");
        }

    }
}
