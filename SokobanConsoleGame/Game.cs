using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SokobanConsoleGame
{
    public class Game : IGame, iFileable
    {
        Filer Filer;
        private Parts[,] LevelGrid;
        private int RowCount;
        private int ColCount;
        private Stack MoveStack = new Stack();
        public Position PlayerPos;
        public string LevelString{ get; set; }
        public int MoveCount { get; set; }
        public Game(Filer filer)
        {
            Filer = filer;
        }
        public bool Load(string newLevel)
        {
            if (CheckStringValidGameString(newLevel))
            {
                LevelString = newLevel;
                setupGrid();
                return true;
            }
            return false;
        }
        public bool CheckStringValidGameString(string newLevel)
        {
            if (!Filer.CheckLineLengths(newLevel) ||
                !Filer.CheckPlayersGoalsBlocks(newLevel) ||
                !Filer.Converter.checkValidString(newLevel))
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
            bool moved = false;
            Position newPos = GetNewPos(moveDirection, PlayerPos);
            Position besideNewPos = GetNewPos(moveDirection, newPos);
            Parts newPosPart = GetMovable(newPos);
            if (newPosPart == Parts.Empty)
            {
                MovePlayer(newPos, moveDirection);
                moved = true;
            }
            else if (newPosPart != Parts.Wall)
            {
                Parts besideNewPossPart = GetMovable(besideNewPos);
                if (besideNewPossPart != Parts.Wall &&
                    besideNewPossPart != Parts.Block)
                {
                    MoveBlock(besideNewPos);
                    MovePlayer(newPos, moveDirection);
                    moved = true;
                }
            }
            return moved;
        }
        private void MoveBlock(Position pos)
        {
            if (GetMovable(pos) == Parts.Goal)
                LevelGrid[pos.Row, pos.Column] = Parts.BlockOnGoal;
            else LevelGrid[pos.Row, pos.Column] = Parts.Block;
        }
        private void MovePlayer(Position newPos, Direction moveDirection)
        {
            LevelGrid[PlayerPos.Row, PlayerPos.Column] = Parts.Empty;
            LevelGrid[newPos.Row, newPos.Column] = Parts.Player;
            PlayerPos = newPos;
            //Parts[,] savedState = DeepCopy(LevelGrid); // i.e. not a reference
            MoveStack.Push(DeepCopy(LevelGrid));
            MoveCount++;

        }
        public static T DeepCopy<T>(T other)
        {
            // gets a copy of the object not a reference to the object
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
            if (MoveStack.Count > 0)
            {
                MoveStack.Pop(); // remove last move
                LevelGrid = (Parts[,])MoveStack.Peek(); // get move before last move
            }
        }
        public Direction GetReverseDirection(Direction lastDirection)
        {
            Direction reversedDirection = Direction.Up;
            switch (lastDirection)
            {
                case Direction.Down:
                    reversedDirection = Direction.Up;
                    break;
                case Direction.Up:
                    reversedDirection = Direction.Down;
                    break;
                case Direction.Right:
                    reversedDirection = Direction.Left;
                    break;
                case Direction.Left:
                    reversedDirection = Direction.Right;
                    break;
                default:
                    break;
            }
            return reversedDirection;
        }
        public int GetRowCount() { return RowCount; }
        public int GetColumnCount() { return ColCount; }
    }
}
