using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace GameLogic
{
   public class SaveGameToConsole
    {
        UserInterface.Сonsole_interaction CI = new Сonsole_interaction();
        public void PrintGame(GameSave gs)
        {
            Console.WriteLine("Игра №{0}",gs.NumOfSave);

            CI.Draw_levels(0, 0);
            for (int i = 0; i < gs.Turns.Count; i++)
            {
                if (i == 0)
                {
                    if (gs.Turns[0].PlayerNum == 1)
                    {
                        CI.Draw_levels(gs.Turns[0].Lvl, 0);
                    }
                    else
                    {
                        CI.Draw_levels(0,gs.Turns[0].Lvl);
                    }
                }

                if (gs.Turns[i].TurnNum % 2 == 0)
                {//походил первый игрок
                    CI.Draw_levels(gs.Turns[i].Lvl, gs.Turns[i-1].Lvl);
                }
                else
                {//походил второй игрок
                    CI.Draw_levels(gs.Turns[i-1].Lvl, gs.Turns[i].Lvl);
                }
            }
        }
    }
}
