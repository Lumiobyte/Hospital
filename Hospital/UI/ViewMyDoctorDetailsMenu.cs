using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.UI.Components;

namespace Hospital.UI
{
    public class ViewMyDoctorDetailsMenu : IMenu
    {

        Patient _patient;

        public ViewMyDoctorDetailsMenu(Patient patient)
        {
            _patient = patient;
        }

        public void Load()
        {
            Console.Clear();
            TitleBox.Draw("My Doctor");
        }

        public void Show()
        {
            if (_patient.PrimaryDoctor == null)
                Console.WriteLine("You do not have a doctor assigned. You can choose your doctor when booking your next appointment!");
            else
            {
                Console.WriteLine("Your doctor:");
                DataTable.RenderTable(new List<Doctor>() { _patient.PrimaryDoctor });
            }
            InputDevice.DelayExitUntilPress();

        }
    }
}
