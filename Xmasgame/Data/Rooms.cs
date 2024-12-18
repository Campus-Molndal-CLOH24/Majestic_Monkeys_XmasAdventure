using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Data
{
    public class Rooms
    {
        public int RoomsId {get; set; }
        public string? RoomsName { get; set; }
        public string RoomsDescription { get; set; } = string.Empty;
        public List<Items>? Items { get; set; } = new List<Items>();
    }
}
