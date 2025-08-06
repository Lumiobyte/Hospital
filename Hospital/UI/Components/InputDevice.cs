using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI.Components
{
    public static class InputDevice
    {

        public static void DelayUntilPress()
        {
            Console.ReadKey(true);
        }

        public static void DelayUntilPress(Action onContinue)
        {
            Console.ReadKey(true);
            onContinue();
        }

        public static void DelayExitUntilPress()
        {
            DelayUntilPress(() => { MenuState.Instance.Pop(); });
        }

    }
}
