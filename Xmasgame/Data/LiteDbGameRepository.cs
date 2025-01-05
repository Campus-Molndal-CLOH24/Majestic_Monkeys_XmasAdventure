using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Xmasgame.Logic;

namespace Xmasgame.Data
{
    public  class LiteDbGameRepository : IgameRespository
    {
        private readonly string _databasePath = "GameDatabase.db";

        public void SaveGame(GameState gameState)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var gameCollection = db.GetCollection<GameState>("gameState");
                //ensure there is only one GameState in the database (overwrite)
                gameCollection.DeleteAll();
                gameCollection.Insert(gameState);
            }
        }

        public GameState LoadGame()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var gameCollection = db.GetCollection<GameState>("gameState");
                return gameCollection.FindAll().FirstOrDefault();
            }
        }
    }
}
