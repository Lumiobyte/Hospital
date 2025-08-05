using Hospital.Repositories;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class ListAllDoctorsMenu : IMenu
    {

        DoctorRepository _repository;

        public ListAllDoctorsMenu(DoctorRepository doctorRepository)
        {
            _repository = doctorRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.DrawTitleBox("All Doctors");
        }

        public void Show()
        {
            DataTable.RenderTable(_repository.GetAll());

            InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
