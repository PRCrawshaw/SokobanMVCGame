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
        public Parts[,] DesignLevel;
        public Controller(Game game, iView view)
        {
            Game = game;
            View = view;
        }
        public void SetupGame(string fileName)
        {
            if (Game.Load(fileName))
            {
                View.SetMoves(0);
                View.PlayingGame = true;
                View.ToggleMoveCountVisibility(true);
                View.ToogleNotificationVisiablity(true);
                View.ToogleListBoxVisiablity(false);
                View.SetNotification("");
                PlacePieces();
                isFinished = false;
            }
        }
        public void SetupDesigner(int rows, int cols)
        {
            InitializeDesignLevel(rows, cols);
            int GridWidth = 40;
            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    View.CreateLevelGridButton(
                        GridWidth * (r - 1), GridWidth * (c - 1), Parts.Empty);
                }
            }
            View.CreateSelectTypeButtons();
        }
        public bool CheckDesignBeforeSave()
        {
            // if valid no player, boxes, goals
            bool result = false;
            string gameString = ConvertDesignLevelToString();
            if (!Game.CheckStringValidGameString(gameString))
            {
                MessageBox.Show(
                    "You need a single player and an equal number of goals and boxes",
                    "Invalid Game", MessageBoxButtons.OK);          
            }
            else
            {
                if (!Game.Filer.CheckWallsOnEdges(gameString))
                {
                    if (DisplayYesNoMessageBox(
                    "You do not have walls on all outside edges. Do you wish to save anyway?",
                    "Missing Walls"))
                    {
                        result = true;
                    }
                }
                else result = true;
            }
            return result;
        }
        public bool DisplayYesNoMessageBox(string message, string caption)
        {
            bool response = false;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                response = true;
            }
            return response;
        }
        public string ConvertDesignLevelToString()
        {
            string textGrid = "";
            int rows = DesignLevel.GetLength(0);
            int cols = DesignLevel.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    char partLetter = (char)DesignLevel[r, c];
                    textGrid += partLetter;
                }
                textGrid += "|";
            }
            Console.WriteLine("DesignLevel: " + textGrid);
            return textGrid;
        }
        private void InitializeDesignLevel(int rows, int cols)
        {
            DesignLevel = new Parts[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    DesignLevel[r, c] = Parts.Empty;
                }
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
                if (Game.MoveCount >= 0)
                    View.SetMoves(Game.MoveCount);
            }
            else
            {
                View.SetNotification("Hit reset if you wish to reload the game.");
            }
        }
    }
}
