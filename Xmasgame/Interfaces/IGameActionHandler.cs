using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Models;

namespace Xmasgame.Interfaces
{
    public interface IGameActionHandler
    {
        bool HandleSaveOrQuit(GameState gameState);
    }
}
