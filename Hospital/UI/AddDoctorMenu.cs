using Hospital.Models;
using Hospital.Repositories;
using Hospital.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class AddDoctorMenu : IMenu
    {

        DoctorRepository _doctorRepository;

        public AddDoctorMenu(DoctorRepository doctorRepository) 
        {
            _doctorRepository = doctorRepository;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("Add Doctor");
        }

        public void Show()
        {

        }

    }
}
