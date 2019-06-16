using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Charecter
    {
        public int Stamina { get; set; }
        public int MaxStamina { get; set; }
        public int Fast_descent_cost { get; set; }
        public int Special_action_cost { get; set; }
        public int Lvl { get; set; }
        public string Name { get; set; }

        public Charecter(int maxstamina, int fast_descent_cost, int special_cost)
        {
            MaxStamina = maxstamina;
            Stamina = MaxStamina;
            Fast_descent_cost = fast_descent_cost;
            Special_action_cost = special_cost;
            Lvl = 0;
        }
        public virtual int Make_move(string action, GameProcess gp)
        {
            switch (action)
            {
                case "rest":
                    Rest();
                    return 0;
                    

                case "descent":
                    if ((Stamina < 5)|| gp.Levels[Lvl].Modification != "")
                        return -1;
                    else
                    {
                        if (gp.Levels.Count > Lvl + 1)
                        {
                            if (gp.Levels[Lvl + 1].Modification == "")
                            {
                                Descent(gp);
                                return 1;
                            }
                        }
                    }
                    break;

                case "fast_descent":
                    if ((Stamina < Fast_descent_cost)|| gp.Levels[Lvl].Modification != "")
                        return -1;
                    else
                    {
                        if (gp.Levels.Count > Lvl + 1)
                        {
                            if (gp.Levels[Lvl + 1].Modification == "")
                            {
                                Fast_descent(gp);
                                return 2;
                            }
                        }
                    }
                    break;

                case "special_action":
                    if ((Stamina < Special_action_cost)|| gp.Levels[Lvl].Modification != "")
                        return -1;
                    else
                    {
                        if (gp.Levels.Count > Lvl + 1)
                        {
                            Special_action(gp);
                            return 3;
                        }
                    }
                    break;

            }
            return -1;
        }
        public virtual void Special_action(GameProcess gp)
        {
            //у каждого персонажа это действие индивидуально
        }

        public void Rest()
        {
            Stamina += 5;
            if (Stamina > MaxStamina)
                Stamina = MaxStamina;
        }
        public void Descent(GameProcess gp)
        {
            Stamina -= 5;//стоимость перехода
            gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
            gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
            Lvl++;
            Stamina += 2;
        }
        public void Fast_descent(GameProcess gp)
        {
            Stamina -= Fast_descent_cost;
            if (gp.Levels[Lvl + 1].Modification == "")
            {
                gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
                gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
                Lvl++;
                if (gp.Levels.Count > Lvl + 1)//делаем второй переход
                {
                    gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
                    gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
                    Lvl++;
                }
            }
            Stamina += 2;
        }
    }
}
