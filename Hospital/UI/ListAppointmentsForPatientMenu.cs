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
    public class ListAppointmentsForPatientMenu : IMenu
    {

        AppointmentRepository _appointmentRepository;
        Patient patient;

        public ListAppointmentsForPatientMenu(AppointmentRepository appointmentRepository, Patient patient)
        {
            _appointmentRepository = appointmentRepository;
            this.patient = patient;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("View Appointments");
        }

        public void Show()
        {
            Console.WriteLine($"Appointments for {patient.FullName}");
            DataTable.RenderTable(_appointmentRepository.GetAppointmentsForPatient(patient));
            InputDevice.DelayExitUntilPress();
        }

    }
}
