using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
   public class Dwarf_warrior:Charecter
    {
        public bool Block_Lvl { get; set; }
        public Dwarf_warrior(int maxstamina, int fast_descent_cost, int special_cost) : base(maxstamina, fast_descent_cost, special_cost)
        {

        }

        public override int Make_move(string action, GameProcess gp)
        {
            if(Block_Lvl)//разблокировали ранее заблокированный уровень
            {
                gp.Levels[Lvl].Modification = "";
                Block_Lvl = false;
            }
            switch (action)
            {
                case "rest":
                    Rest();
                    break;

                case "descent":
                    if (Stamina < 5)
                        return -1;
                    else
                    {
                        if (gp.Levels.Count > Lvl + 1)
                        {
                            if (gp.Levels[Lvl + 1].Modification == "")
                                Descent(gp);
                        }
                    }
                    break;

                case "fast_descent":
                    if (Stamina < Fast_descent_cost)
                        return -1;
                    else
                    {
                        if (gp.Levels.Count > Lvl + 1)
                        {
                            if (gp.Levels[Lvl + 1].Modification == "")
                                Fast_descent(gp);
                        }
                    }
                    break;

                case "special_action":
                    if (Stamina < Special_action_cost)
                        return -1;
                    else
                    {
                        if (gp.Levels.Count > Lvl + 1)
                        {
                            Special_action(gp);
                        }
                    }
                    break;

            }
            return 0;
        }

        public override void Special_action(GameProcess gp)
        {
            Stamina -= Special_action_cost;
            if (gp.Levels.Count > Lvl + 1)
            {
                gp.Levels[Lvl].Persons.Remove(this);//удаляем с прошлого уровня
                gp.Levels[Lvl + 1].Persons.Add(this);//добавляем на новый уровень
                Lvl++;
                gp.Levels[Lvl + 1].Modification = "block";
                Block_Lvl = true;
            }
                Stamina += 2;
        }
    }
}
