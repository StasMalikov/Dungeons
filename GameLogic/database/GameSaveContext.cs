using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GameLogic
{
    public class GameSaveContext : DbContext
    {
        public GameSaveContext() : base("DbConnection")
        {
        }
        public DbSet<GameSave> Saves { get; set; }
    }
}
