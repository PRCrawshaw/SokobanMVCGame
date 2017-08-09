using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SokobanGame
{
    public class Game : iGame, iFileable
    {
        public Filer Filer;
        public Parts[,] LevelGrid;
        public Stack MoveStack = new Stack();
        public Stack SavedStack = new Stack();
        protected int SavedMoveCount;
        public Position[] ChangedPositions = new Position[3];
        protected const int OLDPOS = 0;
        protected const int NEWPOS = 1;
        protected const int BESIDENEWPOS = 2;
        
        // Getter, Setters
        public Position PlayerPos { get; set; }
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public string LevelString{ get; set; }
        public int MoveCount { get; set; }
        
        // Methods
        public Game(Filer filer)
        {
            Filer = filer;
        }
        public bool Load(string fileName)
        {
            string newLevel = Filer.Load(fileName);
            if (newLevel != "File does not exist")
            {
                if (CheckStringValidGameString(newLevel))
                {
                    MoveCount = 0;
                    MoveStack.Clear();
                    LevelString = newLevel;
                    setupGrid();
                    return true;
                }
            }
            return false;
        }
        public bool LoadLevel(string newLevel)
        {
            if (CheckStringValidGameString(newLevel))
            {
                MoveCount = 0;
                MoveStack.Clear();
                LevelString = newLevel;
                setupGrid();
                return true;
            }
            return false;
        }
        public string[] GetFileList()
        {
            return Filer.GetFileList();
        }
        public bool CheckStringValidGameString(string newLevel)
        {
            if (!Filer.CheckLineLengths(newLevel) ||
                !Filer.CheckPlayersGoalsBlocks(newLevel) ||
                !Filer.Converter.checkValidString(newLevel) ||
                !Filer.CheckWallsOnEdges(newLevel))
            {
                return false;
            }
            return true;
        }
        private void setupGrid()
        {
            LevelString = Regex.Replace(LevelString, " ", "-");
            string[] lines = Regex.Split(LevelString, "\n");
            RowCount = lines.Length;
            ColCount = lines[0].Length;
            LevelGrid = new Parts[lines.Length, lines[0].Length];
            for (int r=0; r<lines.Length; r++)
            {
                for (int c=0; c<lines[r].Length; c++)
                {
                    if (lines[r][c] == '@' || lines[r][c] == '+')
                    {
                        PlayerPos = new Position(r, c);
                    }
                    LevelGrid[r, c] = (Parts)lines[r][c];
                }
            }
            // set original state
            SavedStack.Push(DeepCopy(LevelGrid));
            MoveStack.Push(DeepCopy(LevelGrid));
        }
        public Parts GetMovable(Position pos)
        {
            Parts part = WhatsAt(pos.Row, pos.Column);
            return part;
        }
        public Parts WhatsAt(int row, int column)
        {
            Parts part = LevelGrid[row, column];
            return part;
        }
        public bool isFinished()
        {
            return CheckAllBlocksOnGoals();
        }
        private bool CheckAllBlocksOnGoals()
        {
            // assumes checking done before hand to ensure equal number of blocks and goals
            // and game correctly changes goals to blocks on goals
            for (int r=0; r<RowCount; r++)
            {
                for (int c=0; c<ColCount; c++)
                {
                    if (WhatsAt(r, c) == Parts.Block)
                        return false;
                }
            }
            return true; 
        }
        public bool Move(Direction moveDirection)
        {
            //Console.WriteLine("Move Player: " + moveDirection);
            bool moved = false;
            ChangedPositions[OLDPOS] = PlayerPos;
            ChangedPositions[NEWPOS] = GetNewPos(moveDirection, PlayerPos); 
            Parts newPosPart = GetMovable(ChangedPositions[NEWPOS]);
            if (newPosPart == Parts.Empty || newPosPart == Parts.Goal)
            {
                MovePlayer(newPosPart);
                moved = true;
            }
            else if (newPosPart != Parts.Wall)
            {
                ChangedPositions[BESIDENEWPOS] = GetNewPos(moveDirection, ChangedPositions[NEWPOS]);
                Parts besideNewPossPart = GetMovable(ChangedPositions[BESIDENEWPOS]);
                if (besideNewPossPart != Parts.Wall &&
                    besideNewPossPart != Parts.Block)
                {
                    MoveBlock();
                    MovePlayer(newPosPart);
                    moved = true;
                }
            }
            return moved;
        }
        private void MoveBlock()
        {
            Position pos = ChangedPositions[BESIDENEWPOS];
            if (GetMovable(pos) == Parts.Goal)
                LevelGrid[pos.Row, pos.Column] = Parts.BlockOnGoal;
            else LevelGrid[pos.Row, pos.Column] = Parts.Block;
        }
        private void MovePlayer(Parts newPosPart)
        {
            Parts oldposPart = LevelGrid[PlayerPos.Row, PlayerPos.Column];
            Position newPos = ChangedPositions[NEWPOS];
            if (oldposPart == Parts.Player || oldposPart == Parts.Block)
                LevelGrid[PlayerPos.Row, PlayerPos.Column] = Parts.Empty;
            else LevelGrid[PlayerPos.Row, PlayerPos.Column] = Parts.Goal;

            if (newPosPart == Parts.Empty || newPosPart == Parts.Block)
                LevelGrid[newPos.Row, newPos.Column] = Parts.Player;
            else LevelGrid[newPos.Row, newPos.Column] = Parts.PlayerOnGoal;

            PlayerPos = newPos;
            MoveStack.Push(DeepCopy(LevelGrid)); // i.e. not a reference
            MoveCount++;
        }
        public void SaveState()
        {
            SavedStack = DeepCopy(MoveStack);
            SavedMoveCount = MoveCount;
        }
        public void ResumeGame()
        {
            MoveStack = DeepCopy(SavedStack);
            LevelGrid = DeepCopy((Parts[,])SavedStack.Peek());
            MoveCount = SavedMoveCount;
            ResetPlayerPos();
        }
        public static T DeepCopy<T>(T other)
        {
            // returns a copy of the object not a reference to the object
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
        private Position GetNewPos(Direction moveDirection, Position posToCheck)
        { 
            switch (moveDirection)
            {
                case Direction.Down:
                    posToCheck.Row++;
                    break;
                case Direction.Up:
                    posToCheck.Row--;
                    break;
                case Direction.Right:
                    posToCheck.Column++;
                    break;
                case Direction.Left:
                    posToCheck.Column--;
                    break;
            }
            return posToCheck;

        }
        public void Restart()
        {
            setupGrid();
            MoveCount = 0;
        }
        public void Undo()
        {
            if (MoveStack.Count > 1)
            {
                MoveStack.Pop(); // remove last move
                LevelGrid = DeepCopy((Parts[,])MoveStack.Peek()); // get move before last move
                ResetPlayerPos();
                MoveCount--;
            }
            else
            {
                MoveStack.Clear();
                setupGrid();
                MoveCount--;
            }
        }
        private void ResetPlayerPos()
        {
            for (int r=0; r<RowCount; r++)
            {   
                for (int c=0; c<ColCount; c++)
                {
                    if (LevelGrid[r, c] == Parts.Player)
                    {
                        PlayerPos = new Position(r, c);
                        break;
                    }                       
                }                
            }
        }
        public int GetRowCount() { return RowCount; }
        public int GetColumnCount() { return ColCount; }
        //private void OutputLevelGrid()
        //{
        //    string textGrid = "";
        //    for (int r = 0; r < RowCount; r++)
        //    {
        //        for (int c = 0; c < ColCount; c++)
        //        {
        //            char partLetter = (char)LevelGrid[r, c];
        //        textGrid += partLetter;
        //        }
        //    textGrid += "|";
        //    }
        //    textGrid += "\n";
        //    Console.WriteLine("LevelGrid: " + textGrid);

        //}
        //private void OutputStack()
        //{
        //    string stack = "";
        //    Stack stackCopy = DeepCopy(MoveStack);
        //    Console.WriteLine("stackCopy count: " + stackCopy.Count);
        //    int stackCount = stackCopy.Count;
        //    for (int i=0; i<stackCount; i++)
        //    {
        //        Parts[,] part = (Parts[,])stackCopy.Pop();
        //        for (int r=0; r < RowCount; r++)
        //        {
        //            for (int c=0; c < ColCount; c++)
        //            {                      
        //                char partLetter = (char)part[r, c];
        //                stack += partLetter;
        //            }
        //            stack += "|";
        //        }
        //        stack += "end line\n";
        //    }
        //    Console.WriteLine(stack);

        //}
    }
}
