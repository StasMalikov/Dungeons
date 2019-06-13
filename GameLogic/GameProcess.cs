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
        public List<Charecter> HeroesForChoice { get; set; }
        public List<Charecter> Players { get; set; }
        public UserInterface.Сonsole_interaction input;



        public GameProcess()
        {
            input = new Сonsole_interaction();
            Levels = new List<Level>();
            for (int i = 0; i < 21; i++)
            {
                Levels.Add(new Level(i));
            }

            HeroesForChoice = new List<Charecter>();
            HeroesForChoice.Add(new Man_magician(30,13,15));
            HeroesForChoice.Add(new Scout_elf(40,12,24));
            HeroesForChoice.Add(new Dwarf_warrior(50,15,20));
        }

        public void Choice_person(int gamer,int hero)
        {
            Players[gamer] = HeroesForChoice[hero];
        }

        public void Turn(int player)
        {
            if (Players[player].Make_move(input.Choice_action(0,0), this) >= 0)
            {
                //получилось походить
            }
            else//ещё одна попытка походить
            {
                Turn(player);
            }
        }

        public int StartGame()
        {
            Random rnd = new Random();
            int turn= rnd.Next(1,2);//рандомно выбирается первый ход
            int win_player;
            while (true)
            {
                if (turn % 2 == 0)//ходит первый игрок
                {
                    Turn(0);
                    if (Players[0].Lvl==20)
                    {
                        win_player = 0;
                        break;
                    }
                }
                else//ходит второй игрок игрок
                {
                    Turn(1);
                    if (Players[1].Lvl == 20)
                    {
                        win_player = 1;
                        break;
                    }
                }

                ++turn;
            }
            return win_player;
        }
    }
}
