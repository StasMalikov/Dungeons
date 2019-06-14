using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
   public class GameSave
    {
        public List<Turn> Turns { get; set; }
        public int NumOfSave;
        public GameSave(int num_of_save)
        {
            NumOfSave = num_of_save;
            Turns = new List<Turn>();
        }
    }
}
