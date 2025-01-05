using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Xmasgame.Models;

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
                //ensure there is only one GameState is unige by player id
                var existingGame = gameCollection.FindOne(g => g.PlayerId == gameState.PlayerId);
                

                gameCollection.Upsert(gameState); //insert or update
            }
        }

        public GameState LoadGame(string PlayerId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var gameCollection = db.GetCollection<GameState>("gameState");
                var gameState = gameCollection.FindOne(g => g.PlayerId == PlayerId);
                return gameState;
            }
        }

        public IEnumerable<GameState> GetAllSaveGames()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var gameCollection = db.GetCollection<GameState>("gameState");
                return gameCollection.FindAll().ToList();
            }
        }
    }
}
