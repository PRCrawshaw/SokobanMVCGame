using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public enum Direction { Up, Down, Left, Right };

    public interface iGame
    {
        bool isFinished();
        bool Load(string newLevel);
        bool Move(Direction moveDirection);
        void Restart();
        void Undo();
    }
}
