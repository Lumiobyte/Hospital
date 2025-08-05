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
            TitleBox.DrawTitleBox("View Patient Details");
        }

        public void Show()
        {
            var patientId = int.Parse(InputField.Prompt("Patient ID to view", Validators.Numeric));

            var patient = _repository.GetById(patientId);

            if (patient == null)
            {
                Console.WriteLine($"Error: No patient exists with ID {patientId}");
                InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
                return;
            }

            DataTable.RenderTable(patient);

            InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
