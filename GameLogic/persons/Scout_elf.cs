using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
   public class Scout_elf : Charecter
    {
        public Scout_elf(int maxstamina, int fast_descent_cost, int special_cost) : base(maxstamina, fast_descent_cost, special_cost)
        {

        }

        public override void Special_action(GameProcess gp)
        {
            Stamina -= Special_action_cost;
            if (gp.Levels[Lvl + 1].Modification == "")//1 переход
            {
                gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
                gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
                Lvl++;
            }
            if (gp.Levels.Count > Lvl + 1)//2 переход
            {
                if (gp.Levels[Lvl + 1].Modification == "")
                {
                    gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
                    gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
                    Lvl++;
                }
            }
            if (gp.Levels.Count > Lvl + 1)//3 переход
            {
                if (gp.Levels[Lvl + 1].Modification == "")
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
