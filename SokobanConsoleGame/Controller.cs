﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SokobanConsoleGame;
using System.Drawing;

namespace SokobanGame
{
    public class Controller
    {
        Game Game;
        iView View;
        FormPlayGame Form_PlayGame = new FormPlayGame();
        FormDesignGame Form_DesignGame = new FormDesignGame();
        Controller Ctrl;
        private int redrawCount = 0;
        protected const int JITTER_REDRAW = 10;
        public const string DEFAULT_FILENAME = "Level1.txt";
        private string DesignLevelFileName = "";
        public bool isFinished = false;
        public Parts[,] DesignLevel = new Parts[1,1];
        private string DesignGameString;
        private int GridWidth = 40;

        public Controller(Game game, iView view)
        {
            Game = game;
            View = view;

            Ctrl = this;
            Form_PlayGame = new FormPlayGame();
            SetDefaultFileName(DEFAULT_FILENAME);
        }
        
        // Game play methods
        public void SetupGame(string fileName)
        {
            Form_PlayGame.Left = 300;
            Form_PlayGame.Top = 300;
            EventArgs e = new EventArgs();
            Form_PlayGame.ClearGameGrid(e);
            Form_PlayGame.AddController(Ctrl);
            if (!Game.Load(fileName))
            {
                MessageBox.Show(
                "This is not a valid file",
                "Invalid Game", MessageBoxButtons.OK);
                SetDefaultFileName(DEFAULT_FILENAME);
                Game.Load(DEFAULT_FILENAME);
            }
            Form_PlayGame.Height = Game.RowCount * GridWidth + 60;
            Form_PlayGame.Width = Game.ColCount * GridWidth + 140 + 120;
            Form_PlayGame.SetSaveResumeButtonPosition(Game.ColCount * GridWidth + 140);
            Form_PlayGame.SetMoves(0);
            Form_PlayGame.PlayingGame = true;
            Form_PlayGame.SetNotification("");

            isFinished = false;
            Form_PlayGame.Show();
            Form_PlayGame.PlacePieces(Game);
        }
        public Image GetMyPartImage(Parts part)
        {
            Image image = Image.FromFile("Empty.png"); // default image
            switch (part)
            {
                case Parts.Wall:
                    image = Image.FromFile("Wall.png");
                    break;
                case Parts.Block:
                    image = Image.FromFile("Block.png");
                    break;
                case Parts.Goal:
                    image = Image.FromFile("Goal.png");
                    break;
                case Parts.BlockOnGoal:
                    image = Image.FromFile("BlockOnGoal.png");
                    break;
                case Parts.PlayerOnGoal:
                    image = Image.FromFile("PlayerOnGoal.png");
                    break;
                case Parts.Player:
                    image = Image.FromFile("Player.png");
                    break;
                case Parts.Empty:
                    image = Image.FromFile("Empty.png");
                    break;
                default:
                    break;
            }
            return image;
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
        public void Move(Direction direction)
        {
            if (Game.Move(direction) && !isFinished)
            {
                Form_PlayGame.SetMoves(Game.MoveCount);
                if (redrawCount > JITTER_REDRAW) // decreases jitters
                {
                    Form_PlayGame.PlacePieces(Game);       // redraws all pieces
                    redrawCount = 0;
                }
                else
                {
                    PlaceMovedPieces(); // places new changed pieces on top of old pieces
                    redrawCount++;
                }
                Form_PlayGame.SetNotification("");
                if (Game.isFinished())
                {
                    isFinished = true;
                    if (DisplayYesNoMessageBox(
                        "You have won. Do you wish to load another level?", "Game Over"))
                    {
                        string fileName = GetLevels();
                        if (fileName != "")
                            SetupGame(fileName);
                    }
                }
            }
            else
            {
                if (isFinished)
                    Form_PlayGame.SetNotification("You've already won");
                else Form_PlayGame.SetNotification("Can't move into a wall.");
            }
        }
        private void PlaceMovedPieces()
        {
            int GridWidth = 40;
            foreach (Position pos in Game.ChangedPositions)
            {
                Form_PlayGame.CreateLevelGridImage(GridWidth * (pos.Row),
                    GridWidth * (pos.Column),
                    Game.LevelGrid[pos.Row, pos.Column]);
            }
        }
        public void Undo()
        {
            if (!isFinished)
            {
                Game.Undo();
                Form_PlayGame.PlacePieces(Game);
                if (Game.MoveCount >= 0)
                    Form_PlayGame.SetMoves(Game.MoveCount);
            }
            else
            {
                Form_PlayGame.SetNotification("Hit reset if you wish to reload the game.");
            }
        }
        public void SaveState()
        {
            Game.SaveState();
        }    
        public void ResumeState()
        {
            Game.ResumeGame();
            Form_PlayGame.SetMoves(Game.MoveCount);
            Form_PlayGame.PlacePieces(Game);
        }  
        // Get Level methods
        public string GetLevels()
        {
            FormLevels frm_Levels = new FormLevels();
            string fileName = "";
            string[] fileListWithPath = GetFileList();
            string[] fileList = new string[fileListWithPath.Length];
            for (int i = 0; i < fileListWithPath.Length; i++)
            {
                fileList[i] = fileListWithPath[i].Substring(fileListWithPath[i].LastIndexOf('\\') + 1);
            }
            frm_Levels.SetupItemList(fileList);
            if (frm_Levels.ShowDialog() == DialogResult.OK)
            {
                fileName = frm_Levels.Filename;
                SetDefaultFileName(frm_Levels.Filename);
                //SetupGame(frm_Levels.Filename);
            }
            frm_Levels.Dispose();
            return fileName;
        }
        public string[] GetFileList()
        {
            return Game.GetFileList();
        }
        public void SetDefaultFileName(string filename)
        {
            View.SetDefaultFileName(filename);
            Form_PlayGame.SetDefaultFileName(filename);
        }

        // Designer methods
        public void SetupDesignForm()
        {
            Form_DesignGame.AddController(Ctrl);
            ToggleDesignButtons(true);
            Form_DesignGame.Height = 600;
            Form_DesignGame.Show();
        }
        public void SetupNewDesigner(int rows, int cols)
        {
            InitializeDesignLevel(rows, cols);
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
                    Form_DesignGame.CreateLevelGridButton(
                        GridWidth * (r - 1), GridWidth * (c - 1), part);
                }
            }
            Form_DesignGame.CreateSelectTypeButtons();
            Form_DesignGame.SetIntialHighlightArea();
        }
        public void LoadExistingLevelDesign()
        {
            ToggleDesignButtons(false);
            DesignLevelFileName = GetLevels();
            Game existingGame = new Game(new Filer(new Converter()));
            existingGame.Load(DesignLevelFileName);
            int rows = existingGame.RowCount;
            int cols = existingGame.ColCount;
            InitializeDesignLevel(rows, cols);
            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    DesignLevel[r - 1, c - 1] = existingGame.LevelGrid[r - 1, c - 1];
                    Form_DesignGame.CreateLevelGridButton(
                        GridWidth * (r - 1), GridWidth * (c - 1), existingGame.WhatsAt(r-1,c-1));
                }
            }
            Form_DesignGame.SetIntialHighlightArea();
            Form_DesignGame.CreateSelectTypeButtons();
        }
        private void InitializeDesignLevel(int rows, int cols)
        {
            Form_DesignGame.Height = Game.RowCount * GridWidth + 60;
            Form_DesignGame.Width = Game.ColCount * GridWidth + 140;
            DesignLevel = new Parts[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    DesignLevel[r, c] = Parts.Empty;
                }
            }
        }
        private bool CheckIfOutsideEdge(int r, int c, int rows, int cols)
        {
            if (r == 1 || r == rows || c == 1 || c == cols)
                return true;
            else return false;
        }

        public bool SaveDesign()
        {
            string filename = ShowGetFilenameDialogBox(DesignLevelFileName);
            if (filename != "Cancelled" && filename != "")
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
                    ToggleDesignButtons(false);
                }
            }
            else
                ToggleDesignButtons(false);

        }
        private void ToggleDesignButtons(bool toggle)
        {
            Form_DesignGame.ToggleChooseDesignerSizeVisibility(toggle);
            if (!toggle)
            {
                Form_DesignGame.ClearDesignArea();
                DesignLevelFileName = "";
            }
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
            //Console.WriteLine("DesignLevel: " + DesignGameString);
        }
        public string ShowGetFilenameDialogBox(string fileName)
        {
            FileSaveNameDialogue FilenameDialogue = new FileSaveNameDialogue();
            FilenameDialogue.SetName(fileName);
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
    }
}
