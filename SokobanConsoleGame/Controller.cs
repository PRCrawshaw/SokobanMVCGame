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
        private int redrawCount = 0;
        protected const int JITTER_REDRAW = 10;
        public bool isFinished = false;
        public Controller(Game game, iView view)
        {
            Game = game;
            View = view;
        }
        public void SetupGame(string fileName)
        {
            //Game.Load("#######\n#     #\n#    .#\n#    $#\n# @   #\n#######");
            if (Game.Load(fileName))
            {
                PlacePieces();
                View.SetMoves(0);
            }
        }
        public string[] GetFileList()
        {
            return Game.GetFileList();
        }
        public void Load(string fileName)
        {
            Game.Load(fileName);
        }
        public void Move(Direction direction)
        {
            if (Game.Move(direction) && !isFinished)
            {
                View.SetMoves(Game.MoveCount);
                if (redrawCount > JITTER_REDRAW) // decreases jitters
                {
                    PlacePieces();       // redraws all pieces
                    redrawCount = 0;
                }
                else
                {
                    PlaceMovedPieces(); // places new changed pieces on top of old pieces
                    redrawCount++;
                }
                View.SetNotification("");
                if (Game.isFinished())
                {
                    View.SetNotification("You won");
                    //View.ResetForm();
                    isFinished = true;
                }
            }
            else
            {
                if (isFinished)
                    View.SetNotification("You've already won");
                else View.SetNotification("Can't move into a wall.");
            }
        }
        private void PlacePieces()
        {
            int GridWidth = 40;
            for (int r = 1; r <= Game.RowCount; r++)
            {
                for (int c = 1; c <= Game.ColCount; c++)
                {
                    View.CreateLevelGridImage(
                        GridWidth * (r - 1), GridWidth * (c - 1), Game.LevelGrid[r - 1, c - 1]);
                }
            }
            View.SetButtonHighlight();
        }
        private void PlaceMovedPieces()
        {
            int GridWidth = 40;
            foreach (Position pos in Game.ChangedPositions)
            {
                    View.CreateLevelGridImage(GridWidth * (pos.Row), 
                        GridWidth * (pos.Column), 
                        Game.LevelGrid[pos.Row, pos.Column]);
            }
            View.SetButtonHighlight();
        }
        public void Undo()
        {
            if (!isFinished)
            {
                Game.Undo();
                PlacePieces();
                View.SetMoves(Game.MoveCount);
            }
            else
            {
                View.SetNotification("Hit reset if you wish to reload the game.");
            }
        }
    }
}
