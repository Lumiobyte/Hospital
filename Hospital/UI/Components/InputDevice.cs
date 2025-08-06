using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI.Components
{
    public static class InputDevice
    {

        // Force console to wait until keypress
        public static void DelayUntilPress()
        {
            Console.ReadKey(true);
        }

        // Force console to wait until keypress, then execute an action once it is received
        public static void DelayUntilPress(Action onContinue)
        {
            Console.ReadKey(true);
            onContinue();
        }

        // Force console to wait until keypress, then exit the current menu
        public static void DelayExitUntilPress()
        {
            DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
