using Hospital.Repositories;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class AddPatientMenu
    {

        PatientRepository _patientRepository;

        public AddPatientMenu(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("Add Patient");
        }

        public void Show()
        {
            // Prompt each detail, save.
        }

    }
}
