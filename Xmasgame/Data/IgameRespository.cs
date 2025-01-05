using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Logic;

namespace Xmasgame.Data
{
    public interface IgameRespository
    {
        void SaveGame(GameState gameState);
        GameState LoadGame(string PlayerId);
        IEnumerable<GameState> GetAllSaveGames(); // retrive all save game
    }
}
