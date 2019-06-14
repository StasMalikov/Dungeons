using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
   public class Turn
    {
        public int TurnNum { get; set; }
        public string Charecter  { get; set; }
        public int Lvl { get; set; }
        public int PlayerNum { get; set; }
        public int Stamina { get; set; }
        public string Action { get; set; }

        public Turn(int turn_num,string character,int player,int lvl,int stmn,string action)
        {
            TurnNum = turn_num;
            Charecter = character;
            PlayerNum = player;
            Lvl = lvl;
            Stamina = stmn;
            Action = action;
        }
    }
}
