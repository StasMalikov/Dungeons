using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using GameLogic;

namespace Dungeons
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic.GameProcess gp = new GameLogic.GameProcess();
            gp.Choice_person();//выбираем персонажей
            GameSave GS = new GameSave(UserInterface.Сonsole_interaction.GetSaveNum());
            int result = gp.StartGame(GS);//начинаем игру, и получаем в результате дальнейшее действие
            DatabaseOperations.SaveGame(GS);//сохраняем нашу игру в бд


            if (result == 0)//воспроизвести игру из бд
            {
                GameLogic.SaveGameToConsole printgame = new GameLogic.SaveGameToConsole();
                printgame.PrintGame(DatabaseOperations.Get_GameSave(UserInterface.Сonsole_interaction.GetSaveExistNum()));
            }
            if (result == 1)//начать новую игру
            {
                GameLogic.GameProcess gp2 = new GameLogic.GameProcess();
                gp2.Choice_person();
                gp2.StartGame(new GameSave(UserInterface.Сonsole_interaction.GetSaveNum()));
            }
        }
    }
}
