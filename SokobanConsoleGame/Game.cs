using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SokobanConsoleGame
{
    public class Game : IGame, iFileable
    {
        iFiler Filer;
        private string levelString;
        private Parts[,] LevelGrid;
        private int RowCount;
        private int ColCount;
        public Position PlayerPos;
        public string LevelString{get{return levelString;}set{levelString = value;}}

        public Game(iFiler filer)
        {
            Filer = filer;
            LevelString = levelString;
            setupGrid();
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
        }

        public Parts GetMovable(Position pos)
        {
            Parts part = WhatsAt(pos.Row, pos.Column);
            return part;
        }
        public bool isFinished()
        {
            throw new NotImplementedException();
        }
        public void Load(string newLevel)
        {
            throw new NotImplementedException();
        }
        public bool Move(Direction moveDirection)
        {
            Position newPos = GetNewPos(moveDirection, PlayerPos);
            Position besideNewPos = GetNewPos(moveDirection, newPos);
            if (GetMovable(newPos) == Parts.Empty)
            {
                MovePlayer(newPos);
                if (GetMovable(besideNewPos) != Parts.Wall ||
                    GetMovable(besideNewPos) != Parts.Block)
                {
                    MovePlayer(newPos);
                    MoveBlock(besideNewPos);
                }
                return true;
            }
            else return false;
        }
        private void MoveBlock(Position pos)
        {
            if (GetMovable(pos) == Parts.Goal)
                LevelGrid[pos.Row, pos.Column] = Parts.BlockOnGoal;
            else LevelGrid[pos.Row, pos.Column] = Parts.Block;
        }

        private void MovePlayer(Position newPos)
        {
            LevelGrid[PlayerPos.Row, PlayerPos.Column] = Parts.Empty;
            LevelGrid[newPos.Row, newPos.Column] = Parts.Player;

        }
        private Position GetNewPos(Direction moveDirection, Position posToCheck)
        { 
            switch (moveDirection)
            {
                case Direction.Down:
                    posToCheck.Column++;
                    break;
                case Direction.Up:
                    posToCheck.Column--;
                    break;
                case Direction.Right:
                    posToCheck.Row++;
                    break;
                case Direction.Left:
                    posToCheck.Row--;
                    break;
            }
            return posToCheck;

        }
        public void Restart()
        {
            throw new NotImplementedException();
        }
        public void Undo()
        {
            throw new NotImplementedException();
        }
        public int GetRowCount() { return RowCount; }
        public int GetColumnCount() { return ColCount; }

        public Parts WhatsAt(int row, int column)
        {
            Parts part = LevelGrid[row, column];
            return part;
        }
    }
}
