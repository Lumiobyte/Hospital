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
    public class ListAllPatientsMenu : IMenu
    {

        PatientRepository _repository;
        Doctor _doctor;

        public ListAllPatientsMenu(PatientRepository patientRepository, Doctor? doctor = null)
        {
            _repository = patientRepository;
            _doctor = doctor;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("All Patients");
        }

        public void Show()
        {
            if (_doctor == null)
            {
                DataTable.RenderTable(_repository.GetAll());
            }
            else
            {
                DataTable.RenderTable(_repository.GetDoctorPatients(_doctor));
            }

            InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
