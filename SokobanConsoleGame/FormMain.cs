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
        protected const int STARTX = 120;
        protected const int STARTY = 40;
        protected const int GAP = 0;
        //private int GridSize = 40;
        //private int HighlightX;
        //private int HighlightY;
        private string DefaultFileName;
        private Graphics Graphics;
        //private Parts PartType = Parts.Wall;

        
        // Setup methods
        public FormMain()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
            //ToggleMoveCountVisibility(false);
            //ToggleChooseDesignerSizeVisibility(false);
            //btn_SaveDesign.Visible = false;
            //btn_QuitDesign.Visible = false;
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }

        // Use arrows for navigation

        //// game and design buttons and images
        //public void CreateLevelGridButton(int row, int col, Parts part)
        //{
        //    Point p = new Point(col + 120, row + STARTY + 50);
        //    Button newButton = new Button();
        //    newButton.Name = String.Format("{0}_{1}", row/40, col/40);
        //    newButton.Visible = true;
        //    newButton.Width = 40;
        //    newButton.Height = 40;
        //    newButton.Location = p;
        //    newButton.Click += new EventHandler(Design_buttonClick);
        //    newButton.BackgroundImage = Ctrl.GetMyPartImage(part);
        //    newButton.BackgroundImageLayout = ImageLayout.Stretch;
        //    this.Controls.Add(newButton);
        //}
        //private void HighlightPartType(Color color)
        //{
        //    Pen pen = new Pen(color);
        //    pen.Width = 5;
        //    Graphics.DrawRectangle(pen, new Rectangle(HighlightX - 2, HighlightY - 2, 43, 43));
        //}
        //public void SetIntialHighlightArea()
        //{
        //    HighlightX = STARTX;
        //    HighlightY = STARTY;
        //    HighlightPartType(Color.Red);
        //}
        //public void CreateSelectTypeButtons()
        //{
        //    int nextXPos = 120;
        //    foreach (Parts part in Enum.GetValues(typeof(Parts)))
        //    {
        //        Point p = new Point(nextXPos, STARTY);
        //        Button newButton = new Button();
        //        newButton.Name = part.ToString();
        //        newButton.Visible = true;
        //        newButton.Width = 40;
        //        newButton.Height = 40;
        //        newButton.Location = p;
        //        newButton.Click += new EventHandler(PartType_buttonClick);
        //        newButton.BackgroundImage = Ctrl.GetMyPartImage(part);
        //        newButton.BackgroundImageLayout = ImageLayout.Stretch;
        //        this.Controls.Add(newButton);
        //        nextXPos += 50;
        //    }
        //}

        // set text fields
        public void SetDefaultFileName(string name)
        {
            DefaultFileName = name;
        }

        // Visibility Toggles

        //public void ToogleGameButtonsVisiablity(bool toggle)
        //{
        //    btn_GetLevels.Visible = toggle;
        //    btn_start.Visible = toggle;
        //    if (toggle)
        //    {
        //        btn_Design.Visible = true;
        //        btn_SaveDesign.Visible = false;
        //    }
        //    else
        //    {
        //        btn_Design.Visible = false;
        //        btn_SaveDesign.Visible = true;
        //    }
        //}
        private void start_button_Click_1(object sender, EventArgs e)
        {
            Ctrl.SetupGame(DefaultFileName);
        }
        private void btn_GetLevels_Click(object sender, EventArgs e)
        {
            Ctrl.GetLevels();
        }
      
        // Designer buttons
        private void btn_Design_Click(object sender, EventArgs e)
        {
            Ctrl.SetupDesignForm();
            //ToggleMoveCountVisibility(false);
            //ToogleGameButtonsVisiablity(false);
            ////ClearGameGrid(e);
            //ToggleChooseDesignerSizeVisibility(true);
            //btn_QuitDesign.Visible = true;
            //PlayingGame = false;
        }
        //private void btn_StartDesign_Click(object sender, EventArgs e)
        //{
        //    ToggleChooseDesignerSizeVisibility(false);
        //    Ctrl.SetupDesigner(Convert.ToInt32(nup_Rows.Value), Convert.ToInt32(nup_Cols.Value));
        //}
        //private void btn_SaveDesign_Click(object sender, EventArgs e)
        //{
        //    if (Ctrl.CheckDesignBeforeSave())
        //    {
        //        if (Ctrl.SaveDesign())
        //            ClearDesignArea();
        //    }
        //    //else SetNotification("Must have: One Player, Equal Number of Goals and Boxes\n"+
        //                         //"and be surrounded by Walls");
        //}
        private void btn_QuitDesign_Click(object sender, EventArgs e)
        {
            Ctrl.QuitDesign();
        }
    }
}
