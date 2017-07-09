using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanConsoleGame
{
    public enum Direction { Up, Down, Left, Right };

    public interface IGame
    {
        bool isFinished();
        void Load(string newLevel);
        bool Move(Direction moveDirection);
        void Restart();
        void Undo();
    }
}
