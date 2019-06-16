using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
   public class Сonsole_interaction
    {
        public string[] Choice_character()
        {
            string player1;
            string player2="";
            Console.WriteLine("1 игрок");
            Console.WriteLine("Выбор персонажа");
            Console.WriteLine("--- Человек-маг --- для выбора введите \"0\"");
            Console.WriteLine("--- Гном-воин --- для выбора введите \"1\"");
            Console.WriteLine("--- Эльф-разведчик --- для выбора введите \"2\"");
            Console.Write("---Ввод:");
            player1 = Console.ReadLine();

            if(player1=="0")
            {
                Console.WriteLine("2 игрок");
                Console.WriteLine("Выбор персонажа");
                Console.WriteLine("--- Гном-воин --- для выбора введите \"1\"");
                Console.WriteLine("--- Эльф-разведчик --- для выбора введите \"2\"");
                Console.Write("---Ввод:");
                string res = Console.ReadLine();
                if (Convert.ToInt32(res) == 0)
                {
                    Error();
                    Console.Write("---Ввод:");
                    player2 = Console.ReadLine();
                }
                else
                    player2 = res;

            }
            else if(player1 == "1")
            {
                Console.WriteLine("2 игрок");
                Console.WriteLine("Выбор персонажа");
                Console.WriteLine("--- Человек-маг --- для выбора введите \"0\"");
                Console.WriteLine("--- Эльф-разведчик --- для выбора введите \"2\"");
                Console.Write("---Ввод:");
                string res= Console.ReadLine();
                if (Convert.ToInt32(res) == 1)
                {
                    Error();
                    Console.Write("---Ввод:");
                    player2 = Console.ReadLine();
                }
                else
                    player2 = res;
            }
            else if(player1 == "2")
            {
                Console.WriteLine("2 игрок");
                Console.WriteLine("Выбор персонажа");
                Console.WriteLine("--- Человек-маг --- для выбора введите \"0\"");
                Console.WriteLine("--- Гном-воин --- для выбора введите \"1\"");
                Console.Write("---Ввод:");
                string res = Console.ReadLine();
                if (Convert.ToInt32(res) == 2)
                {
                    Error();
                    Console.Write("---Ввод:");
                    player2 = Console.ReadLine();
                }
                else
                    player2 = res;
            }
            return new string[2] {player1,player2};

        }

        public void Error()
        {
            Console.WriteLine("Этот персонаж уже занят, выберете другого.");
        }

        public static int GetSaveNum()
        {
            Console.WriteLine("Для записи игры в базу данных введите номер сохранения");
            Console.Write("---Ввод:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int GetSaveExistNum()
        {
            Console.WriteLine("Введите номер сохранённой игры");
            Console.Write("---Ввод:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string Choice_action(int fdescent_cost,int special_cost)
        {
            string input = "";
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("-ОТДЫХ, расход выносливости:0 , для выбора введите \"x\"");
            Console.WriteLine("-СПУСК, расход выносливости:5 , для выбора введите \"c\"");
            Console.WriteLine("-БЫСТРЫЙ СПУСК, расход выносливости:{0} , для выбора введите \"v\"",fdescent_cost);
            Console.WriteLine("-ОСОБОЕ ДЕЙСТВИЕ, расход выносливости:{0} , для выбора введите \"b\"",special_cost);
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

        public string Get_Action(int fdescent_cost, int special_cost)
        {
            string result = Choice_action(fdescent_cost,special_cost);
            switch (result)
            {
                case "x":
                    {
                        return "rest";
                    }
                case "c":
                    {
                        return "descent";
                    }
                case "v":
                    {
                        return "fast_descent";
                    }
                case "b":
                    {
                        return "special_action";
                    }
            }
            return "";
        }


        public void Show_status(int player_num,int stamina,int person_type)
        {
            Console.WriteLine("Ход {0} игрока, выносливость: {1}",player_num,stamina);
            switch (person_type)
            {
                case 0:
                    Console.WriteLine("Тип персонажа Человек-маг");
                    break;
                case 1:
                    Console.WriteLine("Тип персонажа Гном-воин");
                    break;
                case 2:
                    Console.WriteLine("Тип персонажа Эльф-разведчик");
                    break;
            }
        }

        public void Draw_levels(int player1LvL, int player2LvL )
        {
            int min;
            int max;
            if(player1LvL>player2LvL)
            {
                min = player2LvL;
                max = player1LvL;
            }else if (player1LvL < player2LvL)
            {
                max = player2LvL;
                min = player1LvL;
            }
            else
            {
                max = player2LvL;
                min = player2LvL;
            }

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

        public int WinMessage(int player)
        {
            Console.WriteLine("Победил {0} игрок.Он первым добрался до 20 уровня.",player);
            Console.WriteLine("Выберете дальнейшее действие:");
            Console.WriteLine("- Воспроизвести игру, введите\"0\"");
            Console.WriteLine("- Начать новую игру, введите\"1\"");
            Console.WriteLine("- Выйти, введите\"2\"");
            
            Console.Write("---Ввод:");
            int tmp = Convert.ToInt32(Console.ReadLine());
            return tmp;
        }
    }
}
