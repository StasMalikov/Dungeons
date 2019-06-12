using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class GameProcess
    {
        public List<Level> Levels { get; set; }

        public GameProcess()
        {
            Levels = new List<Level>();
        }
    }
}
