using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Admin : IUserAccount
    {

        public Admin(string password)
        {
            Password = password;
        }

        public int Id { get; set; }

        public string Password { get; set; }
    }
}
