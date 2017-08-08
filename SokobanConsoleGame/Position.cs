using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public struct Position
    {
        public int Column { get; set; }
        public int Row{ get; set; }

        public Position(int _row, int _col)
        {
            Row = _row;
            Column = _col;
        }
    }
}
