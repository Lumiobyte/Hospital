using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI.Components
{
    public static class VisualDevice
    {

        // Clear numLines previous lines in the console
        public static void ClearPreviousLines(int numLines)
        {
            int cursorLine = Console.CursorTop;

            for(int i = 0; i < numLines; i++)
            {
                if (cursorLine <= 1)
                    break;

                Console.SetCursorPosition(0, cursorLine - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cursorLine - 1); // Because writing WindowWidth sets us down to the next line
            }

        }

    }
}
