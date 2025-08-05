using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI.Components
{
    public static class TitleBox
    {

        public static void DrawTitleBox(string menuTitle)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("DotNet Hospital Management System");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(menuTitle);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");
        }

    }
}
