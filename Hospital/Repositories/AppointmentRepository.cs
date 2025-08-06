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

        public IEnumerable<Appointment> GetAppointmentsForPatient(Patient patient)
        {
            return _dbSet.Include(a => a.AptPatient).Include(a => a.AptDoctor).Where(a => a.AptPatient.Id == patient.Id);
        }

    }
}
