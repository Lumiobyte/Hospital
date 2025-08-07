using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Repositories;
using Hospital.UI.Components;

namespace Hospital.UI
{
    public class ListAppointmentsForDoctorMenu : IMenu
    {

        DoctorRepository _doctorRepository;
        AppointmentRepository _appointmentRepository;
        Doctor _doctor;

        public ListAppointmentsForDoctorMenu(DoctorRepository doctorRepository, AppointmentRepository appointmentRepository, Doctor doctor)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            _doctor = doctor;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("View Appointments With Doctor");
        }

        public void Show()
        {
            Console.WriteLine($"Appointments for {_doctor.FullName}");
            DataTable.RenderTable(_appointmentRepository.GetAppointmentsForDoctor(_doctor));
            InputDevice.DelayExitUntilPress();
        }

    }
}
