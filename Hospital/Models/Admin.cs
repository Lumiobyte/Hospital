using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Admin : IUser
    {

        public int Id { get; set; }
        public string Password { get; set; }
    }
}
