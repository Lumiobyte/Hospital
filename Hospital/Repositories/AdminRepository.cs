using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class AdminRepository : Repository<Admin>
    {

        public AdminRepository(HospitalDbContext context) : base(context) { }

        
        // Helper allowing us to reach the HospitalDbContext and execute raw SQL statements on it.
        public void ExecuteSqlRawHelper(string sqlStatement)
        {
            _context.Database.ExecuteSqlRaw(sqlStatement);
        }

    }
}
