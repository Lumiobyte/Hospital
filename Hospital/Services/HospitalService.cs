using Hospital.Models;
using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public IUser? ValidateCredentials(int userId, string password)
        {
            if(userId == 867)
            {
                SeedDatabase();
                Console.WriteLine("Database Seeded Succesfully :)");
                return null;
            }

            var foundUser = TryGetAccountById(userId);

            if (foundUser == null || !foundUser.Password.Equals(password))
                return null;
            else 
                return foundUser;
        }

        IUser? TryGetAccountById(int userId)
        {
            var doctor = _doctorRepository.GetById(userId);
            if (doctor != null) return doctor;

            var patient = _patientRepository.GetById(userId);
            if (patient != null) return patient;

            var admin = _adminRepository.GetById(userId);
            return admin;
        }

        private void SeedDatabase()
        {
            // Seed rows
            _doctorRepository.Add(new Doctor() { Id = 123, Name = "Doctor", Surname = "DotNet", Address = "1 Doctor St, Shalvey, NSW", Email = "doctor@gmail.com", Password = "doctor", PhoneNumber = "0400123456" });
            _patientRepository.Add(new Patient() { Id = 234, PrimaryDoctorId = 123, Name = "Patient", Surname = "1", Address = "1 Patient St, Nerang, QLD", Email = "patient@gmail.com", Password = "patient", PhoneNumber = "0400123457" });
            _adminRepository.Add(new Admin() { Id = 345, Password = "admin" });

            // This sets different ID increment starting points for different rows -> prevent overlap
            _adminRepository.ExecuteSqlRawHelper(@"
            INSERT OR REPLACE INTO sqlite_sequence (name, seq) VALUES ('Doctors', 999);
            INSERT OR REPLACE INTO sqlite_sequence (name, seq) VALUES ('Patients', 1999);
            ");
        }
    }
}
