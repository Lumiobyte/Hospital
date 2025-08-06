using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class PatientRepository : Repository<Patient>
    {

        public PatientRepository(HospitalDbContext context) : base(context) { }

        public void AddAppointment(Patient patient, string description)
        {

            // This will ensure that EF tracks our changes properly and creates correct relationships for this new appointment
            // TODO: Add/remove if necessary
            //_context.Attach(patient);
            //_context.Attach(patient.PrimaryDoctor);

            var apt = new Appointment() { AptDoctor = patient.PrimaryDoctor, AptPatient = patient, Description = description};

            patient.Appointments.Add(apt);
            patient.PrimaryDoctor.Appointments.Add(apt);

            _context.SaveChanges();
        }

        public void SetPatientDoctor(Patient patient, Doctor doctor)
        {
            patient.PrimaryDoctor = doctor;
            _context.SaveChanges();
        }

    }
}
