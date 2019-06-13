using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace Dungeons
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.Сonsole_interaction UI = new Сonsole_interaction();
            UI.Draw_levels(1,5,1,5);
            UI.Choice_action(13, 15);
            Console.ReadKey();
        }
    }
}
