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
    public class ViewPatientDetailMenu : IMenu
    {

        PatientRepository _repository;

        public ViewPatientDetailMenu(PatientRepository patientRepository)
        {
            _repository = patientRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("View Patient Details");
        }

        public void Show()
        {
            var patientId = int.Parse(InputField.Prompt("Patient ID to view", Validators.Numeric));

            var patient = _repository.GetById(patientId);

            while (patient == null)
            {
                VisualDevice.ClearPreviousLines(1);
                Console.WriteLine($"Error: No patient exists with ID {patientId}");

                patientId = int.Parse(InputField.Prompt("Patient ID to view", Validators.Numeric));
                patient = _repository.GetById(patientId);
            }

            DataTable.RenderTable(new List<Patient>() { patient });

            InputDevice.DelayExitUntilPress();
        }

    }
}
