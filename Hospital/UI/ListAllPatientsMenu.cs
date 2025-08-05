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

        public ListAllPatientsMenu(PatientRepository patientRepository)
        {
            _repository = patientRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.DrawTitleBox("All Patients");
        }

        public void Show()
        {
            DataTable.RenderTable(_repository.GetAll());

            InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
