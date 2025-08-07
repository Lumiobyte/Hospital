using Hospital.Models;
using Hospital.Repositories;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class CreateAppointmentMenu : IMenu
    {

        DoctorRepository _doctorRepository;
        PatientRepository _patientRepository;
        AppointmentRepository _appointmentRepository;
        Patient patient;

        public CreateAppointmentMenu(AppointmentRepository appointmentRepository, DoctorRepository doctorRepository, PatientRepository patientRepository, Patient patient)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
            this.patient = patient;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("Book Appointment");
        }

        public void Show()
        {
            // If patient has no linked doctor - link one now.

            Doctor patientDoctor;

            if(patient.PrimaryDoctor == null)
            {
                Console.WriteLine("You are not registered with any doctor! Please choose a doctor: ");
                DataTable.RenderTable(_doctorRepository.GetAll(), true);
                var choice = int.Parse(InputField.Prompt("Enter the ID of the doctor you choose", Validators.UserId));
                var chosenDoctor = _doctorRepository.GetById(choice);
                while(chosenDoctor == null)
                {
                    VisualDevice.ClearPreviousLines(1);
                    choice = int.Parse(InputField.Prompt("Enter a valid doctor ID", Validators.UserId));
                    chosenDoctor = _doctorRepository.GetById(choice);
                }

                patientDoctor = chosenDoctor;
                _patientRepository.SetPatientDoctor(patient, chosenDoctor);
            }
            else
            {
                patientDoctor = patient.PrimaryDoctor;
            }

            Console.WriteLine($"Booking new appointment with {patientDoctor.FullName}");

            var description = InputField.Prompt("Appointment description");

            _appointmentRepository.Add(new Appointment() { AptDoctor = patientDoctor, AptPatient = patient, Description = description });

            Console.WriteLine("Booked your appointment succesfully!");

            try
            {
                Emails.SendEmail(patientDoctor.Email, "New Appointment Booking", $"Dear {patientDoctor.FullName},\n{patient.FullName} has scheduled a new appointment with you.\n\nAppointment Description:{description}");
                Emails.SendEmail(patient.Email, $"Doctor's Appointment with ${patientDoctor.FullName}", $"Dear {patient.FullName},\nYou have succesfully scheduled an appointment with Dr {patientDoctor.FullName}.\n\nAppointment Description:{description}");
                Console.WriteLine("You and your doctor have been notified by email.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to send email notifications :(\n{ex.Message}");
            }

            InputDevice.DelayExitUntilPress();
        }

    }
}
