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
            GameLogic.GameProcess gp = new GameLogic.GameProcess();
            gp.Choice_person();
            gp.StartGame();
            Console.ReadKey();
        }
    }
}
