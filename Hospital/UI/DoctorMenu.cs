using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class DoctorMenu : IMenu
    {

        Doctor _user;
        DoctorRepository _repository;

        public DoctorMenu(DoctorRepository doctorRepository, Doctor user)
        {
            _user = user;
            _repository = doctorRepository;
        }

        // Prepare this menu for rendering and interaction
        public void Load()
        {
            Console.Clear();
        }

        // Render this menu
        public void Show()
        {

        }
    }
}
