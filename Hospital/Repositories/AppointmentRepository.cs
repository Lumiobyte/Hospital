using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class AppointmentRepository : Repository<Appointment>
    {

        public AppointmentRepository(HospitalDbContext context) : base(context) { }

        // Get all appointment records referencing a specific patient
        public IEnumerable<Appointment> GetAppointmentsForPatient(Patient patient)
        {
            return _dbSet.Include(a => a.AptPatient).Include(a => a.AptDoctor).Where(a => a.AptPatient.Id == patient.Id);
        }

        // Get all appointment records referencing a specific doctor
        public IEnumerable<Appointment> GetAppointmentsForDoctor(Doctor doctor)
        {
            return _dbSet.Include(a => a.AptPatient).Include(a => a.AptDoctor).Where(a => a.AptDoctor.Id == doctor.Id);
        }

    }
}
