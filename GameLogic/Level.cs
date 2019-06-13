using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Level
    {
        public int Number { get; set; }//номер уровня
        public List<Charecter> Persons { get; set; }//персонажи находящиеся на уровне
        public string Modification { get; set; }//эффект наложенный на уровень
        public Level(int num)
        {
            Number = num;
            Persons= new List<Charecter>();
            Modification = "";
        }
    }
}
