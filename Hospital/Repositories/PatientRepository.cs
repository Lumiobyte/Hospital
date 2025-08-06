using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class PatientRepository : Repository<Patient>
    {

        public PatientRepository(HospitalDbContext context) : base(context) {
        }

        public void SetPatientDoctor(Patient patient, Doctor doctor)
        {
            patient.PrimaryDoctor = doctor;
            _context.SaveChanges();
        }
    
        public List<Patient> GetDoctorPatients(Doctor doctor)
        {
            return _dbSet.Include(p => p.PrimaryDoctor).Where(p => p.PrimaryDoctor.Id == doctor.Id).ToList();
        }

    }
}
