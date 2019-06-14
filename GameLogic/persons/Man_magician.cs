using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
   public class Man_magician : Charecter
    {
        public Man_magician(int maxstamina, int fast_descent_cost, int special_cost) : base(maxstamina, fast_descent_cost, special_cost)
        {
            Name = "Человек-маг";
        }

        public override void Special_action(GameProcess gp)
        {
            Stamina -= Special_action_cost;
            if (gp.Levels[Lvl + 1].Modification == "")
            {
                if(gp.Levels[Lvl + 1].Persons.Count==0)//если никого нет на уровне ниже
                {
                    gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
                    gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
                    Lvl++;
                }
                else//смена мест персонажей
                {
                    Charecter tmp = gp.Levels[Lvl + 1].Persons[0];
                    gp.Levels[Lvl + 1].Persons.Remove(tmp);
                    tmp.Lvl--;
                    gp.Levels[Lvl].Persons.Add(tmp);//добавляем на новый уровень

                    gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
                    gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
                    Lvl++;
                }
            }
                Stamina += 2;
        }

    }
}
