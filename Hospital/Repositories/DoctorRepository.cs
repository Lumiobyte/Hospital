using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {

        public DoctorRepository(HospitalDbContext context) : base(context)
        {
        }

        //public IEnumerable<Patient> GetPatients()
        //{
        //    return  _dbSet.Include(d => d.Patients).FirstOrDefault(d => d.Id == );
        //}

    }
}
