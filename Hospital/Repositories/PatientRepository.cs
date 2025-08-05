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

        // Add extra methods

    }
}
