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

            int result = gp.StartGame();
            if (result == 0)
            {
                GameLogic.SaveGameToConsole printgame = new GameLogic.SaveGameToConsole();
                printgame.PrintGame(gp.Get_GameSave(UserInterface.Сonsole_interaction.GetSaveExistNum()));
            }
            if (result == 1)
            {
                GameLogic.GameProcess gp2 = new GameLogic.GameProcess();
                gp2.Choice_person();
                gp2.StartGame();
            }
            Console.ReadKey();
        }
    }
}
