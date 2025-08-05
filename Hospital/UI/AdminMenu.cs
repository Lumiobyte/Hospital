using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class AdminMenu : IMenu
    {

        Admin _user;
        AdminRepository _repository;

        public AdminMenu(AdminRepository adminRepository, Admin user)
        {
            _user = user;
            _repository = adminRepository;
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
