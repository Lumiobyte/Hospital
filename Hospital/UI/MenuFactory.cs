using Hospital.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class MenuFactory
    {

        private readonly IServiceProvider _serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Create a new instance of a user menu e.g. the root menu for Doctors, Patients, or Admins
        public IMenu CreateUserMenu(IUserAccount user)
        {
            return user switch
            {
                Doctor => ActivatorUtilities.CreateInstance<DoctorMenu>(_serviceProvider, user),
                Patient => ActivatorUtilities.CreateInstance<PatientMenu>(_serviceProvider, user),
                Admin => ActivatorUtilities.CreateInstance<AdminMenu>(_serviceProvider, user)
            };
        }

        // Create a new instance of a generic menu that requires database access e.g. the "create new user" menu, the "schedule new appointment" menu..
        public IMenu CreateMenu<T>() where T : IMenu, new() // could allow this to take some args in some structure e.g. a list or a dict, whihc are then passed to the menu obect initialisation.
        {
            return ActivatorUtilities.CreateInstance<T>(_serviceProvider);
        }

        // Generic menus that don't require DB can be created anywhere by simply instantiating the class.

    }
}
