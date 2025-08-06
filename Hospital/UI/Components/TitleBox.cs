using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI.Components
{
    public static class TitleBox
    {

        // Draw the title box, calculate padding to center the menu title
        public static void Draw(string menuTitle)
        {
            int boxWidth = 44;
            Console.WriteLine("┌" + new string('─', boxWidth - 2) + "┐");
            Console.WriteLine("|" + "     DotNet Hospital Management System    " + "|");
            Console.WriteLine("|" + new string('-', boxWidth - 2), "|");
            Console.WriteLine("|" + CenterText(menuTitle, boxWidth - 2) + "|");
            Console.WriteLine("└" + new string('─', boxWidth - 2) + "┘");
        }

        public static string CenterText(string text, int width)
        {
            int leftPadding = (width - text.Length) / 2;
            return new string(' ', leftPadding) + text + new string(' ', width - text.Length - leftPadding);
        }

    }
}
