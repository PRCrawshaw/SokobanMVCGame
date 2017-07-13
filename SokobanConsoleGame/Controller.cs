using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            View.CreateLevelGridImage(10, 10, Parts.Goal);
            SetupGame();
        }
        public void SetupGame()
        {
            Game.Load("#######\n#     #\n#    .#\n#    $#\n# @   #\n#######");
            PlacePieces();
        }

        public void Move(Direction direction)
        {
            Game.Move(direction);
            PlacePieces();
            if (Game.isFinished())
            {
                MessageBox.Show("You won");
                View.ResetForm();
            }


        }

        private void PlacePieces()
        {
            View.SetButtonHighlight();
            int GridWidth = 40;
            for (int r = 1; r <= Game.RowCount; r++)
            {
                for (int c = 1; c <= Game.ColCount; c++)
                {
                    View.CreateLevelGridImage(GridWidth * (r - 1), GridWidth * (c - 1), Game.LevelGrid[r - 1, c - 1]);
                }
            }
        }
    }
}
