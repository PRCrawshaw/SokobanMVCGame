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
        public void ResetForm()
        {
            this.Invalidate();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }
        public void CreateLevelGridImage(int row, int col, Parts part)
        {
            int startX = 120;
            int startY = 40;
            int rectCol = col + startX;
            int rectRow = row + startY;
            Graphics.DrawRectangle(Pens.Black, new Rectangle(rectCol, rectRow, 40, 40));
            Rectangle inner = new Rectangle(rectCol + 1, rectRow + 1, 40, 40);
            Graphics.FillRectangle(Brushes.LightGray, inner);
            Graphics.DrawImage(GetMyPartImage(part), inner);
        }
        private void start_button_Click(object sender, EventArgs e)
        {
            Ctrl.SetupGame();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    Ctrl.Move(Direction.Left);
                    break;
                case Keys.Right:
                    Ctrl.Move(Direction.Right);
                    break;
                case Keys.Up:
                    Ctrl.Move(Direction.Up);
                    break;
                case Keys.Down:
                    Ctrl.Move(Direction.Down);
                    break;
                default:
                    MessageBox.Show("Use the arrow keys to move the player.");
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
            newButton.BackgroundImage = GetMyPartImage(part);
            newButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(newButton);
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
        public void SetButtonHighlight()
        {
            btn_start.Focus();
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

        private void start_button_Click_1(object sender, EventArgs e)
        {
            Ctrl.SetupGame();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
