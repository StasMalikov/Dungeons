using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
   public class Сonsole_interaction
    {
        public string Choice_action(int fdescent_cost,int special_cost)
        {
            string input = "";
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("-ОТДЫХ, расход выносливости:0 , для выбора введите \"x\"");
            Console.WriteLine("-СПУСК, расход выносливости:5 , для выбора введите \"c\"");
            Console.WriteLine("-БЫСТРЫЙ СПУСК, расход выносливости:{0} , для выбора введите \"v\"",fdescent_cost);
            Console.WriteLine("-ОСОБОЕ ДЕЙСТВИЕ, расход выносливости:{0} , для выбора введите \"x\"",special_cost);
            Console.Write("---Ввод:");
            input = Console.ReadLine();
            if((input=="x")||(input == "c")||(input == "v")||(input == "b"))
                return input;
            else
            {
                Console.WriteLine("Введена неверная команда,попробуйте ещё раз");
                input=Choice_action(fdescent_cost, special_cost);
            }
            return input;
        }


        public void Show_status(int player_num,int stamina)
        {
            Console.WriteLine("Ход {0} игрока, выносливость: {1}",player_num,stamina);
        }

        public void Draw_levels(int player1LvL, int player2LvL,int min, int max )
        {
            Console.WriteLine("|");

            for (int i = min; i <= max; i++)
            {
                if((i== player1LvL)&&(i == player2LvL))
                {
                    Console.WriteLine("{0}_lvl--- 1p, 2p", i);
                }
                else if(i == player1LvL)
                {
                    Console.WriteLine("{0}_lvl--- 1p", i);
                }
                else if (i == player2LvL)
                {
                    Console.WriteLine("{0}_lvl--- 2p", i);
                }
                else
                {
                    Console.WriteLine("{0}_lvl---", i);
                }
                    Console.WriteLine("|");
            }
            Console.WriteLine("------------------------------------------------");

        }
    }
}
