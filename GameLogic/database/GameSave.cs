using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameLogic
{
    public class GameSave
    {
        [Key]
        public int Id { get; set; }
        public List<Turn> Turns { get; set; }
        public int NumOfSave;
        public GameSave()
        {
            Turns = new List<Turn>();
        }
        public GameSave(int num_of_save)
        {
            Id = num_of_save;
            NumOfSave = num_of_save;
            Turns = new List<Turn>();
        }
    }
}
