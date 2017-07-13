using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public class Controller
    {
        Game Game;
        iView View;

        public Controller(Game game, iView view)
        {
            Game = game;
            View = view;
            View.
            SetupGame();
        }
        public void SetupGame()
        {
            Game.Load("####\n# .#\n#@$#\n####");
            int GridWidth = 40;
            for (int r = 1; r <= Game.RowCount; r++)
            {
                for (int c = 1; c <= Game.ColCount; c++)
                {
                    View.CreateLevelGridButton(GridWidth * (r-1), GridWidth *(c-1), Game.LevelGrid[r-1, c-1]);
                }
            }
        }

    }
}
