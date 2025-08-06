using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient : IUserAccount
    {

        public int Id { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public int PrimaryDoctorId { get; set; }
        [ForeignKey(nameof(PrimaryDoctorId))]
        public Doctor PrimaryDoctor { get; set; }

        [NotMapped]
        public string FullName => Name + " " + Surname;

    }
}
