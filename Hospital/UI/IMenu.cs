using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public interface IMenu
    {

        // Run whenever a menu reaches the top of the stack, either by creation, or by the menu higher than it being exited
        public void Load();

        // Renders the menu
        public void Show();

    }
}
