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

        public int AptDoctorId { get; set; }
        [ForeignKey(nameof(AptDoctorId))]
        public Doctor AptDoctor { get; set; }

        public int AptPatientId { get; set; }
        [ForeignKey(nameof(AptPatientId))]
        public Patient AptPatient { get; set; }

        public string Description { get; set; }

    }
}
