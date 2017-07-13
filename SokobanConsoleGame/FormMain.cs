using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SokobanGame
{
    public partial class FormMain : Form, iView
    {
        public Controller Ctrl;
        public int StartPos = 120;
        private Graphics Graphics;

        public FormMain()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }
        public void CreateLevelGridImages(int row, int col, Parts part)
        {
            int rectCol = 40 * col;
            int rectRow = 40 * row;
            Graphics.DrawRectangle(Pens.Black, new Rectangle(rectCol, rectRow, 40, 40));
            Rectangle inner = new Rectangle(rectCol + 1, rectRow + 1, 40, 40);
            Graphics.FillRectangle(Brushes.LightGray, inner);
            if (part != Parts.Empty)
            {
                Graphics.DrawImage(GetMyPartImage(part), inner);
            }
        }
        public Image GetMyPartImage(Parts part)
        {
            Image image = Image.FromFile("Empty01.png");
            switch (part)
            {
                case Parts.Wall:
                    image = Image.FromFile("Wall01.png");
                    break;
                case Parts.Block:
                    image = Image.FromFile("Block01.png");
                    break;
                case Parts.Goal:
                    image = Image.FromFile("Goal01.png");
                    break;
                case Parts.BlockOnGoal:
                    image = Image.FromFile("BlockOnGoal01.png");
                    break;
                case Parts.PlayerOnGoal:
                    image = Image.FromFile("PlayerOnGoal01.png");
                    break;
                case Parts.Player:
                    image = Image.FromFile("Player01.png");
                    break;
                case Parts.Empty:
                    image = Image.FromFile("Empty01.png");
                    break;
                default:
                    break;
            }
            return image;
        }
        public void CreateLevelGridButton(int row, int col, Parts part)
        {
            Point p = new Point(col + StartPos, row + StartPos);
            Button newButton = new Button();
            newButton.Name = String.Format("{0}_{1}", row, col);
            newButton.Visible = true;
            newButton.Width = 40;
            newButton.Height = 40;
            newButton.Location = p;
            //newButton.Click += new EventHandler(levelGrid_buttonClick);
            newButton = GetMyPart(part, newButton);
            newButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(newButton);
        }

        public Button GetMyPart(Parts part, Button button)
        {
            switch (part)
            {
                case Parts.Wall:
                    button.BackgroundImage = Image.FromFile("Wall01.png");
                    break;
                case Parts.Block:
                    button.BackgroundImage = Image.FromFile("Block01.png");
                    break;
                case Parts.Goal:
                    button.BackgroundImage = Image.FromFile("Goal01.png");
                    break;
                case Parts.BlockOnGoal:
                    button.BackgroundImage = Image.FromFile("BlockOnGoal01.png");
                    break;
                case Parts.PlayerOnGoal:
                    button.BackgroundImage = Image.FromFile("PlayerOnGoal01.png");
                    break;
                case Parts.Player:
                    button.BackgroundImage = Image.FromFile("Player01.png");
                    break;
                case Parts.Empty:
                    button.BackgroundImage = Image.FromFile("Empty01.png");
                    break;
                default:
                    break;
            }
            return button;
        }

        public void DesignerLoadLevel()
        {
            throw new NotImplementedException();
        }

        public void DesignerNewLevel(int rows, int cols)
        {
            throw new NotImplementedException();
        }

        public void DisplayMain()
        {
            throw new NotImplementedException();
        }

        public void FinishGame(string bestPlayer, string bestScore, int thisScore)
        {
            throw new NotImplementedException();
        }

        public void GameSetup(int moves)
        {
            throw new NotImplementedException();
        }

        public void SetGamePosition(int row, int col, Parts part)
        {
            throw new NotImplementedException();
        }

        public void SetMoves(int moves)
        {
            throw new NotImplementedException();
        }
    }
}
