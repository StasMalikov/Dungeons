using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace Dungeons
{
   public class DatabaseOperations
    {
        public static void SaveGame(GameSave GS)//сохраняем игру в бд
        {
            using (var db = new GameSaveContext())
            {
                db.Saves.Add(GS);//добавляем нашу игру в бд
                db.SaveChanges();//делаем сохранение в бд
            }
        }

        public static GameSave Get_GameSave(int num)//загружаем игру из бд
        {
            using (GameSaveContext db = new GameSaveContext())
            {
                var saves = db.Saves.ToList();
                foreach (GameSave tmp in saves)
                {
                    if (tmp.NumOfSave == num)
                        return tmp;//нашли сохранённую игру
                }
            }
            return new GameSave(-1);//не нашли нашу сохранённую игру
        }
    }
}
