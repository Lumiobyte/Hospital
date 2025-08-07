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
        private readonly AppointmentRepository _appointmentRepository;

        public HospitalService(DoctorRepository doctorRepository, PatientRepository patientRepository, AdminRepository adminRepository, AppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _adminRepository = adminRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IUser? ValidateCredentials(int userId, string password)
        {
            if (userId == 867)
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
            // Doctors  
            var seedDoctor1 = new Doctor() { Id = 121, Name = "John", Surname = "Doe", Address = "1 Doctor St, Sydney, NSW", Email = "evanpartridge0@gmail.com", Password = "john123", PhoneNumber = "0400123457" };
            _doctorRepository.Add(seedDoctor1);
            var seedDoctor2 = new Doctor() { Id = 122, Name = "Alice", Surname = "Smith", Address = "2 Doctor St, Shalvey, NSW", Email = "alice.smith@gmail.com", Password = "alice123", PhoneNumber = "0400123458" };
            _doctorRepository.Add(seedDoctor2);
            var seedDoctor3 = new Doctor() { Id = 123, Name = "Bob", Surname = "Johnson", Address = "3 Doctor St, Shalvey, NSW", Email = "bob.johnson@gmail.com", Password = "bob123", PhoneNumber = "0400123459" };
            _doctorRepository.Add(seedDoctor3);
            var seedDoctor4 = new Doctor() { Id = 124, Name = "Carol", Surname = "Williams", Address = "4 Doctor St, Shalvey, NSW", Email = "carol.williams@gmail.com", Password = "carol123", PhoneNumber = "0400123460" };
            _doctorRepository.Add(seedDoctor4);
            var seedDoctor5 = new Doctor() { Id = 125, Name = "David", Surname = "Taylor", Address = "5 Doctor St, Melbourne, VIC", Email = "david.taylor@gmail.com", Password = "david123", PhoneNumber = "0400123465" };
            _doctorRepository.Add(seedDoctor5);
            var seedDoctor6 = new Doctor() { Id = 126, Name = "Emma", Surname = "Anderson", Address = "6 Doctor St, Perth, WA", Email = "emma.anderson@gmail.com", Password = "emma123", PhoneNumber = "0400123466" };
            _doctorRepository.Add(seedDoctor6);
            var seedDoctor7 = new Doctor() { Id = 127, Name = "Frank", Surname = "Thomas", Address = "7 Doctor St, Adelaide, SA", Email = "frank.thomas@gmail.com", Password = "frank123", PhoneNumber = "0400123467" };
            _doctorRepository.Add(seedDoctor7);
            var seedDoctor8 = new Doctor() { Id = 128, Name = "Grace", Surname = "Moore", Address = "8 Doctor St, Hobart, TAS", Email = "grace.moore@gmail.com", Password = "grace123", PhoneNumber = "0400123468" };
            _doctorRepository.Add(seedDoctor8);
            var seedDoctor9 = new Doctor() { Id = 129, Name = "Henry", Surname = "Martin", Address = "9 Doctor St, Darwin, NT", Email = "henry.martin@gmail.com", Password = "henry123", PhoneNumber = "0400123469" };
            _doctorRepository.Add(seedDoctor9);
            var seedDoctor10 = new Doctor() { Id = 130, Name = "Ivy", Surname = "Clark", Address = "10 Doctor St, Canberra, ACT", Email = "ivy.clark@gmail.com", Password = "ivy123", PhoneNumber = "0400123470" };
            _doctorRepository.Add(seedDoctor10);

            // Patients  
            var seedPatient1 = new Patient() { Id = 231, PrimaryDoctor = seedDoctor1, Name = "Eve", Surname = "Brown", Address = "1 Patient St, Brisbane, QLD", Email = "evanpartridge0@gmail.com", Password = "eve123", PhoneNumber = "0400123461" };
            _patientRepository.Add(seedPatient1);
            var seedPatient2 = new Patient() { Id = 232, PrimaryDoctor = seedDoctor2, Name = "Frank", Surname = "Davis", Address = "2 Patient St, Brisbane, QLD", Email = "frank.davis@gmail.com", Password = "frank123", PhoneNumber = "0400123462" };
            _patientRepository.Add(seedPatient2);
            var seedPatient3 = new Patient() { Id = 233, PrimaryDoctor = seedDoctor3, Name = "Grace", Surname = "Miller", Address = "3 Patient St, Brisbane, QLD", Email = "grace.miller@gmail.com", Password = "grace123", PhoneNumber = "0400123463" };
            _patientRepository.Add(seedPatient3);
            var seedPatient4 = new Patient() { Id = 234, PrimaryDoctor = seedDoctor4, Name = "Hank", Surname = "Wilson", Address = "4 Patient St, Brisbane, QLD", Email = "hank.wilson@gmail.com", Password = "hank123", PhoneNumber = "0400123464" };
            _patientRepository.Add(seedPatient4);
            var seedPatient5 = new Patient() { Id = 235, PrimaryDoctor = seedDoctor5, Name = "Ivy", Surname = "Taylor", Address = "5 Patient St, Brisbane, QLD", Email = "ivy.taylor@gmail.com", Password = "ivy123", PhoneNumber = "0400123465" };
            _patientRepository.Add(seedPatient5);
            var seedPatient6 = new Patient() { Id = 236, PrimaryDoctor = seedDoctor6, Name = "Jack", Surname = "Anderson", Address = "6 Patient St, Brisbane, QLD", Email = "jack.anderson@gmail.com", Password = "jack123", PhoneNumber = "0400123466" };
            _patientRepository.Add(seedPatient6);
            var seedPatient7 = new Patient() { Id = 237, PrimaryDoctor = seedDoctor7, Name = "Kara", Surname = "Thomas", Address = "7 Patient St, Brisbane, QLD", Email = "kara.thomas@gmail.com", Password = "kara123", PhoneNumber = "0400123467" };
            _patientRepository.Add(seedPatient7);
            var seedPatient8 = new Patient() { Id = 238, PrimaryDoctor = seedDoctor8, Name = "Liam", Surname = "Moore", Address = "8 Patient St, Brisbane, QLD", Email = "liam.moore@gmail.com", Password = "liam123", PhoneNumber = "0400123468" };
            _patientRepository.Add(seedPatient8);
            var seedPatient9 = new Patient() { Id = 239, PrimaryDoctor = seedDoctor9, Name = "Mia", Surname = "Martin", Address = "9 Patient St, Brisbane, QLD", Email = "mia.martin@gmail.com", Password = "mia123", PhoneNumber = "0400123469" };
            _patientRepository.Add(seedPatient9);
            var seedPatient10 = new Patient() { Id = 240, PrimaryDoctor = seedDoctor10, Name = "Noah", Surname = "Clark", Address = "10 Patient St, Brisbane, QLD", Email = "noah.clark@gmail.com", Password = "noah123", PhoneNumber = "0400123470" };
            _patientRepository.Add(seedPatient10);

            // Appointments
            _appointmentRepository.Add(new Appointment() { Id = 342, AptDoctor = seedDoctor2, AptPatient = seedPatient2, Description = "Dental checkup" });
            _appointmentRepository.Add(new Appointment() { Id = 343, AptDoctor = seedDoctor3, AptPatient = seedPatient3, Description = "Eye examination" });
            _appointmentRepository.Add(new Appointment() { Id = 344, AptDoctor = seedDoctor4, AptPatient = seedPatient4, Description = "Skin consultation" });
            _appointmentRepository.Add(new Appointment() { Id = 345, AptDoctor = seedDoctor1, AptPatient = seedPatient2, Description = "Follow-up visit" });
            _appointmentRepository.Add(new Appointment() { Id = 346, AptDoctor = seedDoctor2, AptPatient = seedPatient3, Description = "Routine checkup" });
            _appointmentRepository.Add(new Appointment() { Id = 347, AptDoctor = seedDoctor3, AptPatient = seedPatient4, Description = "Vaccination" });
            _appointmentRepository.Add(new Appointment() { Id = 348, AptDoctor = seedDoctor4, AptPatient = seedPatient1, Description = "Physical therapy" });
            _appointmentRepository.Add(new Appointment() { Id = 349, AptDoctor = seedDoctor1, AptPatient = seedPatient3, Description = "Blood test" });
            _appointmentRepository.Add(new Appointment() { Id = 350, AptDoctor = seedDoctor2, AptPatient = seedPatient4, Description = "Consultation for allergies" });
            _appointmentRepository.Add(new Appointment() { Id = 351, AptDoctor = seedDoctor2, AptPatient = seedPatient4, Description = "please, i have died and i need a death certificate. please help me doctor" });

            // Admins  
            _adminRepository.Add(new Admin() { Id = 341, Password = "admin" });

            // This sets different ID increment starting points for different rows -> prevent overlap  
           // _adminRepository.ExecuteSqlRawHelper(@"  
           //INSERT OR REPLACE INTO sqlite_sequence (name, seq) VALUES ('Doctors', 999);  
           //INSERT OR REPLACE INTO sqlite_sequence (name, seq) VALUES ('Patients', 1999);  
           //");
        }

        public void AddUserAccount(IUserAccount newAccount)
        {
            if (newAccount.GetType() == typeof(Doctor))
            {
                _doctorRepository.Add((Doctor)newAccount);
            }
            else if (newAccount.GetType() == typeof(Patient))
            {
                var patient = (Patient)newAccount;
                patient.PrimaryDoctor = null;
                _patientRepository.Add(patient);
            }
        }
    }
}
