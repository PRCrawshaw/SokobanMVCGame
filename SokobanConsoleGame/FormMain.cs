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

        public FormMain()
        {
            CreateLevelGridButton(40, 40, Parts.Player);
            InitializeComponent();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }

        public void CreateLevelGridButton(int row, int col, Parts part)
        {
            Point p = new Point(col,
                50);
            Button newButton = new Button();
            newButton.Name = String.Format("{0}_{1}", row, col);
            newButton.Visible = true;
            newButton.Width = 100;
            newButton.Height = 100;
            newButton.Location = p;
            //newButton.Click += new EventHandler(levelGrid_buttonClick);
            if (part != Parts.Empty)
            {
                newButton = GetMyPart(part, newButton);
                newButton.BackgroundImageLayout = ImageLayout.Stretch;
            }
            this.Controls.Add(newButton);
        }

        public Button GetMyPart(Parts part, Button button)
        {
            switch (part)
            {
                case Parts.Wall:
                    button.BackgroundImage = Image.FromFile("Wall.jpg");
                    break;
                case Parts.Block:
                    button.BackgroundImage = Image.FromFile("Block.png");
                    break;
                case Parts.Goal:
                    button.BackgroundImage = Image.FromFile("Goal.jpg");
                    break;
                case Parts.BlockOnGoal:
                    button.BackgroundImage = Image.FromFile("BlockOnGoal.jpg");
                    break;
                case Parts.PlayerOnGoal:
                    button.BackgroundImage = Image.FromFile("PlayerOnGoal.jpg");
                    break;
                case Parts.Player:
                    button.BackgroundImage = Image.FromFile("Player.png");
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
