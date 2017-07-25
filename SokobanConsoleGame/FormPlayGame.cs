using SokobanGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SokobanConsoleGame
{
    public partial class FormPlayGame : Form
    {
        public Controller Ctrl;
        private Graphics Graphics;
        protected const int STARTX = 120;
        protected const int STARTY = 40;
        protected const int GAP = 0;
        private int GridSize = 40;

        private string GameFileName { get; set; }
        public bool PlayingGame { get; set; }


        public FormPlayGame()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (PlayingGame)
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
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        // prevent the arrow keys from changing the button focus
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return false;
        }
        public void CreateLevelGridImage(int row, int col, Parts part)
        {
            int rectCol = col + STARTX;
            int rectRow = row + STARTY;
            Pen pen = new Pen(Color.FromArgb(255, 42, 42, 42));
            Graphics.DrawRectangle(pen, new Rectangle(
                rectCol, rectRow, GridSize + GAP, GridSize + GAP));
            Rectangle inner = new Rectangle(rectCol + GAP, rectRow + GAP, 40, 40);
            Graphics.FillRectangle(Brushes.LightGray, inner);
            Graphics.DrawImage(GetMyPartImage(part), inner);
        }
        public void PlacePieces(Game game)
        {
            int GridWidth = 40;
            for (int r = 1; r <= game.RowCount; r++)
            {
                for (int c = 1; c <= game.ColCount; c++)
                {
                    CreateLevelGridImage(
                        GridWidth * (r - 1), GridWidth * (c - 1), game.LevelGrid[r - 1, c - 1]);
                }
            }
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


        public void SetMoves(int moves)
        {
            lbl_MoveCountNo.Text = moves.ToString();
        }
        public void SetNotification(string message)
        {
            lbl_Notification.Visible = true;
            lbl_Notification.Text = message;
            //SetButtonHighlight();
        }

        public void ClearGameGrid(EventArgs e)
        {
            this.Graphics.Clear(FormMain.ActiveForm.BackColor);
            this.CreateGraphics().Clear(FormMain.ActiveForm.BackColor);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ClearGameGrid(e);
            Ctrl.SetupGame(GameFileName);
        }

        private void btn_GameClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Undo_Click_1(object sender, EventArgs e)
        {
            Ctrl.Undo();
        }
    }
}
