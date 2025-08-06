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
    public class ViewDoctorDetailMenu : IMenu
    {

        DoctorRepository _repository;

        public ViewDoctorDetailMenu(DoctorRepository doctorRepository)
        {
            _repository = doctorRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("View Patient Details");
        }

        public void Show()
        {
            var doctorId = int.Parse(InputField.Prompt("Patient ID to view", Validators.Numeric));

            var doctor = _repository.GetById(doctorId);

            if (doctor == null)
            {
                Console.WriteLine($"Error: No doctor exists with ID {doctorId}");
                InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
                return;
            }

            DataTable.RenderTable(new List<Doctor> { doctor });

            InputDevice.DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
