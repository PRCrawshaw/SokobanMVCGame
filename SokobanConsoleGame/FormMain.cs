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
        //protected const int STARTPOS = 120;
        protected const int STARTX = 120;
        protected const int STARTY = 40;
        protected const int GAP = 0;
        private int GridSize = 40;
        private Graphics Graphics;

        public FormMain()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
            lbl_MoveCount.Visible = false;
            lbl_MoveCountNo.Visible = false;
        }
        public void ResetForm()
        {
            lbl_MoveCount.Visible = false;
            lbl_MoveCountNo.Visible = false;
            lbl_Notification.Visible = false;
            Ctrl.isFinished = false;
            Ctrl.SetupGame();
            this.Invalidate();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }
        public void CreateLevelGridImage(int row, int col, Parts part)
        {
            //int startX = STARTPOS;
            //int startY = 40;
            int rectCol = col + STARTX;
            int rectRow = row + STARTY;
            Pen pen = new Pen(Color.FromArgb(255, 42, 42, 42));
            Graphics.DrawRectangle(pen, new Rectangle(
                rectCol, rectRow, GridSize + GAP, GridSize + GAP));
            Rectangle inner = new Rectangle(rectCol + GAP, rectRow + GAP, 40, 40);
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
            Point p = new Point(col + 240, row + STARTY);
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
            btn_reset.Focus();
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
            lbl_MoveCount.Visible = true;
            lbl_MoveCountNo.Visible = true;
            lbl_MoveCountNo.Text = moves.ToString();
        }
        public void SetNotification(string message)
        {
            lbl_Notification.Visible = true;
            lbl_Notification.Text = message;
            SetButtonHighlight();
        }
        private void start_button_Click_1(object sender, EventArgs e)
        {
            Ctrl.SetupGame();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            Ctrl.isFinished = false;
            Ctrl.SetupGame();
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            Ctrl.Undo();
        }
    }
}
