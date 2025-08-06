using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Appointment
    {

        public int Id { get; set; }

        public Doctor AptDoctor { get; set; }
        public Patient AptPatient { get; set; }

        [NotMapped]
        [Tabulate]
        public string DoctorName => AptDoctor.FullName;

        [NotMapped]
        [Tabulate]
        public string PatientName => AptPatient.FullName;

        [Tabulate]
        public string Description { get; set; }

    }
}
