using System;
using System.Collections.Generic;
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
        public string Description { get; set; }

    }
}
