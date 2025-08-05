using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class HospitalService : IService
    {
        private readonly DoctorRepository _doctorRepository;
        private readonly PatientRepository _patientRepository;
        private readonly AdminRepository _adminRepository;

        public HospitalService(DoctorRepository doctorRepository, PatientRepository patientRepository, AdminRepository adminRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _adminRepository = adminRepository;
        }

        public IUserAccount? LoginUser(string email, string password)
        {
            // Attempt to login
            // Success -> return IUserAccount instance
            // Fail -> return null
        }
    }
}
