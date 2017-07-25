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
        private int HighlightX;
        private int HighlightY;
        private string DefaultFileName;
        private Graphics Graphics;
        private Parts PartType = Parts.Wall;

        
        // Setup methods
        public FormMain()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
            //ToggleMoveCountVisibility(false);
            ToggleChooseDesignerSizeVisibility(false);
            btn_SaveDesign.Visible = false;
            btn_QuitDesign.Visible = false;
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }

        // Use arrows for navigation

        // game and design buttons and images
        public void CreateLevelGridButton(int row, int col, Parts part)
        {
            Point p = new Point(col + 120, row + STARTY + 50);
            Button newButton = new Button();
            newButton.Name = String.Format("{0}_{1}", row/40, col/40);
            newButton.Visible = true;
            newButton.Width = 40;
            newButton.Height = 40;
            newButton.Location = p;
            newButton.Click += new EventHandler(Design_buttonClick);
            newButton.BackgroundImage = Ctrl.GetMyPartImage(part);
            newButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(newButton);
        }
        private void HighlightPartType(Color color)
        {
            Pen pen = new Pen(color);
            pen.Width = 5;
            Graphics.DrawRectangle(pen, new Rectangle(HighlightX - 2, HighlightY - 2, 43, 43));
        }
        public void SetIntialHighlightArea()
        {
            HighlightX = STARTX;
            HighlightY = STARTY;
            HighlightPartType(Color.Red);
        }
        public void CreateSelectTypeButtons()
        {
            int nextXPos = 120;
            foreach (Parts part in Enum.GetValues(typeof(Parts)))
            {
                Point p = new Point(nextXPos, STARTY);
                Button newButton = new Button();
                newButton.Name = part.ToString();
                newButton.Visible = true;
                newButton.Width = 40;
                newButton.Height = 40;
                newButton.Location = p;
                newButton.Click += new EventHandler(PartType_buttonClick);
                newButton.BackgroundImage = Ctrl.GetMyPartImage(part);
                newButton.BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(newButton);
                nextXPos += 50;
            }
        }
        //public void SetButtonHighlight()
        //{
        //    btn_reset.Focus();
        //}

        // set text fields
        public void SetDefaultFileName(string name)
        {
            DefaultFileName = name;
        }

        // Visibility Toggles
        public void ToggleChooseDesignerSizeVisibility(bool toggle)
        {
            lbl_NoCols.Visible = toggle;
            lbl_NoRows.Visible = toggle;
            nup_Cols.Visible = toggle;
            nup_Rows.Visible = toggle;
            btn_StartDesign.Visible = toggle;
        }
        public void ToogleGameButtonsVisiablity(bool toggle)
        {
            btn_GetLevels.Visible = toggle;
            //btn_reset.Visible = toggle;
            btn_start.Visible = toggle;
            //btn_Undo.Visible = toggle;
            if (toggle)
            {
                btn_Design.Visible = true;
                btn_SaveDesign.Visible = false;
            }
            else
            {
                btn_Design.Visible = false;
                btn_SaveDesign.Visible = true;
            }
        }
        public void ClearDesignArea()
        {
            ToogleGameButtonsVisiablity(true);
            ToggleChooseDesignerSizeVisibility(false);
            DeleteDesignButtons();
            //SetNotification("");
            btn_QuitDesign.Visible = false;
        }
        private void DeleteDesignButtons()
        {
            int noRows = Convert.ToInt32(nup_Rows.Value);
            int noCols = Convert.ToInt32(nup_Cols.Value);
            for (int r = 0; r < noRows; r++)
            {
                for (int c = 0; c < noCols; c++)
                {
                    string btnName = r.ToString() + "_" + c.ToString();
                    Button btn = this.Controls.Find(btnName, true).FirstOrDefault() as Button;
                    this.Controls.Remove(btn);
                }
            }
            foreach (Parts part in Enum.GetValues(typeof(Parts)))
            {
                string btnName = part.ToString();
                Button btn = this.Controls.Find(btnName, true).FirstOrDefault() as Button;
                this.Controls.Remove(btn);
            }
            HighlightPartType(Color.FromArgb(255, 242, 242, 242));
        }

        // button clicks
        private void Design_buttonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string[] row_col = clickedButton.Name.Split('_');
            Ctrl.DesignLevel[int.Parse(row_col[0]), int.Parse(row_col[1])] = PartType;
            clickedButton.BackgroundImage = Ctrl.GetMyPartImage(PartType);
            clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void PartType_buttonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PartType = (Parts)Enum.Parse(typeof(Parts), clickedButton.Name);
            HighlightPartType(Color.FromArgb(255, 242, 242, 242)); // background colour      
            HighlightX = clickedButton.Location.X;
            HighlightY = clickedButton.Location.Y;
            HighlightPartType(Color.Red);
        }
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
            //ToggleMoveCountVisibility(false);
            ToogleGameButtonsVisiablity(false);
            //ClearGameGrid(e);
            ToggleChooseDesignerSizeVisibility(true);
            btn_QuitDesign.Visible = true;
            //PlayingGame = false;
        }
        private void btn_StartDesign_Click(object sender, EventArgs e)
        {
            ToggleChooseDesignerSizeVisibility(false);
            Ctrl.SetupDesigner(Convert.ToInt32(nup_Rows.Value), Convert.ToInt32(nup_Cols.Value));
        }
        private void btn_SaveDesign_Click(object sender, EventArgs e)
        {
            if (Ctrl.CheckDesignBeforeSave())
            {
                if (Ctrl.SaveDesign())
                    ClearDesignArea();
            }
            //else SetNotification("Must have: One Player, Equal Number of Goals and Boxes\n"+
                                 //"and be surrounded by Walls");
        }
        private void btn_QuitDesign_Click(object sender, EventArgs e)
        {
            Ctrl.QuitDesign();
        }
    }
}
