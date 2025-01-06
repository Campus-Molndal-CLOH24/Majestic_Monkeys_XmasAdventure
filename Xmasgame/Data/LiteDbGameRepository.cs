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
                var gameCollection = db.GetCollection<GameState>("savedGames");
                //ensure there is only one GameState is unige by player id
                var existingGame = gameCollection.FindOne(g => g.PlayerName == gameState.PlayerName);
                gameCollection.Upsert(gameState); //insert or update

            }
            Console.WriteLine($"Game saved successfully for player: {gameState.PlayerName}, ID: {gameState.PlayerId}");
        }

        public GameState LoadGame(string PlayerName)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var gameCollection = db.GetCollection<GameState>("savedGames");
                var gameState = gameCollection.FindOne(g => g.PlayerName == PlayerName);
                return gameState;
            }
        }

        public IEnumerable<GameState> GetAllSaveGames()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var gameCollection = db.GetCollection<GameState>("savedGames");
                return gameCollection.FindAll().ToList();
            }
        }
    }
}
