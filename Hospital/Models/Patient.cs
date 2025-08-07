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

        [Tabulate]
        public int Id { get; set; }
        public string Password { get; set; }

        [NotMapped]
        [Tabulate]
        public string FullName => Name + " " + Surname;

        public string Name { get; set; }
        public string Surname { get; set; }
        [Tabulate]
        public string Email { get; set; }
        [Tabulate]
        public string PhoneNumber { get; set; }
        [Tabulate]
        public string Address { get; set; }


        public int? PrimaryDoctorId { get; set; }
        [ForeignKey(nameof(PrimaryDoctorId))]
        public Doctor? PrimaryDoctor { get; set; }



    }
}
