using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace GameLogic
{
    public class GameProcess
    {
        public List<Level> Levels { get; set; } 
        public List<Charecter> Players { get; set; }
        public UserInterface.Сonsole_interaction CI;
        public int type1; //тип персонажа игрока 1
        public int type2; //тип персонажа игрока 2

        public GameProcess()
        {
            CI = new Сonsole_interaction();
            
            Levels = new List<Level>();
            for (int i = 0; i < 21; i++)
            {
                Levels.Add(new Level(i));
            }
            Players = new List<Charecter>();
        }

        public void Choice_person()
        {
            string[] arr = CI.Choice_character();
            switch (Convert.ToInt32(arr[0]))
            {
                case 0:
                    Players.Add(new Man_magician(30, 13, 15));
                    type1 = 0;
                    break;
                case 1:
                    Players.Add(new Dwarf_warrior(50, 15, 20));
                    type1 = 1;
                    break;
                case 2:
                    Players.Add(new Scout_elf(40, 12, 24));
                    type1 = 2;
                    break;
            }
            switch (Convert.ToInt32(arr[1]))
            {
                case 0:
                    Players.Add(new Man_magician(30, 13, 15));
                    type2 = 0;
                    break;
                case 1:
                    Players.Add(new Dwarf_warrior(50, 15, 20));
                    type2 = 1;
                    break;
                case 2:
                    Players.Add(new Scout_elf(40, 12, 24));
                    type2 = 2;
                    break;
            }
        }

        public void Turn(int player, int turn, GameSave GS)
        {
            //персонаж делает ход
            int result = Players[player].Make_move(CI.Get_Action(Players[player].Fast_descent_cost, Players[player].Special_action_cost), this);
            if (result >= 0)
            {
                //получилось походить
                string action = "";
                switch (result)
                {
                    case 0:
                        action = "rest";
                        break;
                    case 1:
                        action = "descent";
                        break;
                    case 2:
                        action = "fast_descent";
                        break;
                    case 3:
                        action = "special_action";
                        break;
                }
                GS.Turns.Add(new Turn(turn, Players[player].Name, player + 1, Players[player].Lvl, Players[player].Stamina, action));
                // запоминаем что было сделанно в этот ход

            }
            else//ещё одна попытка походить
            {
                Turn(player, turn,GS);
            }
        }

        public int StartGame(GameSave GS)
        {
            Random rnd = new Random();
            int turn = rnd.Next(0, 2);//рандомно выбирается первый ход
            while (true)
            {
                Console.Clear();
                CI.Draw_levels(Players[0].Lvl, Players[1].Lvl); //отрисовываем уровни

                if (turn % 2 == 0)//ходит первый игрок
                {
                    CI.Show_status(1, Players[0].Stamina, type1); //показываем состояние игрока
                    Turn(0, turn,GS);//делаем ход
                    if (Players[0].Lvl == 20)// проверка победы
                    {
                        return CI.WinMessage(1);
                    }
                }
                else//ходит второй игрок игрок
                {
                    CI.Show_status(2, Players[1].Stamina, type2);
                    Turn(1, turn,GS);
                    if (Players[1].Lvl == 20)
                    {
                        return CI.WinMessage(2);
                    }
                }
                ++turn;
            }
        }
        
    }
}
