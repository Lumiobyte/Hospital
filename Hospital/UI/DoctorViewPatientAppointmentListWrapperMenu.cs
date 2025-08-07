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
    public class DoctorViewPatientAppointmentListWrapperMenu : IMenu
    {

        MenuFactory _menuFactory;
        PatientRepository _repository;
        bool consumed;

        public DoctorViewPatientAppointmentListWrapperMenu(MenuFactory menuFactory, PatientRepository patientRepository)
        {
            _menuFactory = menuFactory;
            _repository = patientRepository;
            consumed = false;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("View Appointments");
        }

        public void Show()
        {

            if (consumed)
            {
                MenuState.Instance.Pop();
                return;
            }

            var patientId = int.Parse(InputField.Prompt("Patient ID to view appointments for", Validators.Numeric));

            var patient = _repository.GetById(patientId);

            while (patient == null)
            {
                VisualDevice.ClearPreviousLines(1);
                Console.WriteLine($"Error: No patient exists with ID {patientId}");
                

                patientId = int.Parse(InputField.Prompt("Patient ID to view", Validators.Numeric));
                patient = _repository.GetById(patientId);
            }

            _menuFactory.CreateMenu<ListAppointmentsForPatientMenu>(patient);
            consumed = true;
        }

    }
}
