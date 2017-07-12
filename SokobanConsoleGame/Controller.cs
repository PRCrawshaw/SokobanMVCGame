using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public class Controller
    {
        iGame Game;
        iView View;

        public Controller(iGame game, iView view)
        {
            Game = game;
            View = view;
        }
    }
}
