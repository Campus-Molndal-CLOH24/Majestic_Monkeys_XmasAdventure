using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Interfaces
{
    public interface IInputhandler
    {
        int GetRoomchoice(string[] rooms, Func<string> inputProvider);
    }
}
