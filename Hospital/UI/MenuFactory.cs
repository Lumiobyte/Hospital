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
        public IMenu CreateUserMenu(IUser user)
        {
            return user switch
            {
                Doctor => ActivatorUtilities.CreateInstance<DoctorMenu>(_serviceProvider, user),
                Patient => ActivatorUtilities.CreateInstance<PatientMenu>(_serviceProvider, user),
                Admin => ActivatorUtilities.CreateInstance<AdminMenu>(_serviceProvider, user)
            };
        }

        // Create a new instance of a generic menu that requires database access e.g. the "create new user" menu, the "schedule new appointment" menu..
        public void CreateMenu<T>() where T : IMenu
        {
            MenuState.Instance.Push(ActivatorUtilities.CreateInstance<T>(_serviceProvider));
        }

        // New instance of a generic menu, but this override allows us to pass parameters.
        public void CreateMenu<T>(params object[] args) where T : IMenu
        {
            MenuState.Instance.Push((IMenu) ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), args));
        }

        // Generic menus that don't require DB can be created anywhere by simply instantiating the class.

    }
}
