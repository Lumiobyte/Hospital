using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class StreetAddress
    {

        public StreetAddress(int unitNo, string street, string city, string state)
        {
            UnitNo = unitNo;
            Street = street;
            City = city;
            State = state;
        }
        public int Id { get; set; }
        public int UnitNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"{UnitNo} {Street}, {City}, {State}";
        }

    }
}
