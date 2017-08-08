using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SokobanConsoleGame;

namespace SokobanGame
{
    public class Controller
    {
        Game Game;
        iView View;
        private int redrawCount = 0;
        protected const int JITTER_REDRAW = 10;
        public const string DEFAULT_FILENAME = "Level1.txt";
        public bool isFinished = false;
        public Parts[,] DesignLevel = new Parts[1,1];
        private string DesignGameString;

        public Controller(Game game, iView view)
        {
            Game = game;
            View = view;
            View.SetDefaultFileName(DEFAULT_FILENAME);
        }
        
        // Game play methods
        public void SetupGame(string fileName)
        {
            if (!Game.Load(fileName))
            {
                MessageBox.Show(
                "This is not a valid file",
                "Invalid Game", MessageBoxButtons.OK);
                View.SetDefaultFileName(DEFAULT_FILENAME);
                Game.Load(DEFAULT_FILENAME);
            }
            View.SetMoves(0);
            View.PlayingGame = true;
            View.ToggleMoveCountVisibility(true);
            View.ToogleNotificationVisiablity(true);
            View.ToogleListBoxVisiablity(false);
            View.SetNotification("");
            PlacePieces();
            isFinished = false;
        }
        public void Load(string fileName)
        {
            if (!Game.Load(fileName))
            {
                MessageBox.Show(
                    "This is not a valid file",
                    "Invalid Game", MessageBoxButtons.OK);
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
                    isFinished = true;
                    if (DisplayYesNoMessageBox(
                        "You have won. Do you wish to load another level?", "Game Over"))
                    {
                        GetLevels();
                    }
                }
            }
            else
            {
                if (isFinished)
                    View.SetNotification("You've already won");
                else View.SetNotification("Can't move into a wall.");
            }
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
        // Get Level methods
        public void GetLevels()
        {
            EventArgs e = new EventArgs();
            View.ToggleMoveCountVisibility(false);
            View.ToogleListBoxVisiablity(true);
            View.ClearGameGrid(e);
            string[] fileListWithPath = GetFileList();
            string[] fileList = new string[fileListWithPath.Length];
            for (int i = 0; i < fileListWithPath.Length; i++)
            {
                fileList[i] = fileListWithPath[i].Substring(fileListWithPath[i].LastIndexOf('\\') + 1);
            }
            View.SetupItemList(fileList);
        }
        public string[] GetFileList()
        {
            return Game.GetFileList();
        }
        // Designer methods
        public void SetupDesigner(int rows, int cols)
        {
            InitializeDesignLevel(rows, cols);
            View.SetIntialHighlightArea();
            int GridWidth = 40;
            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    Parts part;
                    if (CheckIfOutsideEdge(r, c, rows, cols))
                    {
                        part = Parts.Wall;
                        DesignLevel[r-1, c-1] = Parts.Wall;
                    }
                    else part = Parts.Empty;
                    View.CreateLevelGridButton(
                        GridWidth * (r - 1), GridWidth * (c - 1), part);
                }
            }
            View.CreateSelectTypeButtons();
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
        public bool SaveDesign()
        {
            string filename = ShowGetFilenameDialogBox();
            if (filename != "Cancelled")
            {
                if (filename.Substring(Math.Max(0, filename.Length - 4)) != ".txt")
                    filename = filename + ".txt";
                filename = "Levels\\" + filename;
                Game.Filer.Save(filename, DesignGameString);
                return true;
            }
            return false;
        }
        public bool CheckDesignBeforeSave()
        {
            // if valid no player, boxes, goals
            bool result = false;
            ConvertDesignLevelToString();
            if (!Game.CheckStringValidGameString(DesignGameString))
            {
                MessageBox.Show(
                    "You need a single player and an equal number of goals and boxes",
                    "Invalid Game", MessageBoxButtons.OK);          
            }
            else
            {
                if (!Game.Filer.CheckWallsOnEdges(DesignGameString))
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
        public void QuitDesign()
        {
            int size = DesignLevel.GetLength(0);
            if (size != 1)
            {
                if (DisplayYesNoMessageBox(
                    "Do you wish to save this design", "Quit Design"))
                {
                    SaveDesign();
                }
                else
                {
                    ToggleDesignButtons();
                }
            }
            else
                ToggleDesignButtons();

        }
        private void ToggleDesignButtons()
        {
            View.ToggleChooseDesignerSizeVisibility(false);
            View.ToogleGameButtonsVisiablity(true);
            View.ClearDesignArea();

        }
        private bool DisplayYesNoMessageBox(string message, string caption)
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
        private void ConvertDesignLevelToString()
        {
            DesignGameString = "";
            int rows = DesignLevel.GetLength(0);
            int cols = DesignLevel.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    char partLetter = (char)DesignLevel[r, c];
                    DesignGameString += partLetter;
                }
                if (r != rows - 1)
                    DesignGameString += "\n";
            }
            DesignGameString = Regex.Replace(DesignGameString, "-", " ");
            Console.WriteLine("DesignLevel: " + DesignGameString);
        }
        public string ShowGetFilenameDialogBox()
        {
            FileSaveNameDialogue FilenameDialogue = new FileSaveNameDialogue();
            string fileName = "";
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (FilenameDialogue.ShowDialog() == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                fileName = FilenameDialogue.GetName();
            }
            else
            {
                fileName = "Cancelled";
            }
            FilenameDialogue.Dispose();
            return fileName;
        }
        private bool CheckIfOutsideEdge(int r, int c, int rows, int cols)
        {
            if (r == 1 || r == rows || c == 1 || c == cols)
                return true;
            else return false;
        }
    }
}
