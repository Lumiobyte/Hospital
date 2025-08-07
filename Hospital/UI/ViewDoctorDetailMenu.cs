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
            TitleBox.Draw("View Doctor Details");
        }

        public void Show()
        {
            var doctorId = int.Parse(InputField.Prompt("Doctor ID to view", Validators.Numeric));

            var doctor = _repository.GetById(doctorId);

            while (doctor == null)
            {
                VisualDevice.ClearPreviousLines(1);
                Console.WriteLine($"Error: No doctor exists with ID {doctorId}");

                doctorId = int.Parse(InputField.Prompt("Doctor ID to view", Validators.Numeric));
                doctor = _repository.GetById(doctorId);
            }

            DataTable.RenderTable(new List<Doctor> { doctor });

            InputDevice.DelayExitUntilPress();
        }

    }
}
