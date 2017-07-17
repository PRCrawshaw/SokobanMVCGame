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
        private int GridSize = 40;
        private string DefaultFileName = "Level1.txt";
        private Graphics Graphics;
        private Parts PartType = Parts.Wall;
        private int HighlightX;
        private int HighlightY;
        public bool PlayingGame { get; set; }
        //private int MoveOver = 0;

        public FormMain()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
            ToggleMoveCountVisibility(false);
            ToggleChooseDesignerSizeVisibility(false);
            btn_SaveDesign.Visible = false;
        }
        public void ToggleMoveCountVisibility(bool toggle)
        {
            lbl_MoveCount.Visible = toggle;
            lbl_MoveCountNo.Visible = toggle;
        }
        public void ToggleChooseDesignerSizeVisibility(bool toggle)
        {
            lbl_NoCols.Visible = toggle;
            lbl_NoRows.Visible = toggle;
            nup_Cols.Visible = toggle;
            nup_Rows.Visible = toggle;
            btn_StartDesign.Visible = toggle;
        }
        public void ToogleNotificationVisiablity(bool toggle)
        {
            lbl_Notification.Visible = toggle;
        }
        public void ToogleListBoxVisiablity(bool toggle)
        {
            lst_FileList.Visible = toggle;
        }
        public void ToogleGameButtonsVisiablity(bool toggle)
        {
            btn_GetLevels.Visible = toggle;
            btn_reset.Visible = toggle;
            btn_start.Visible = toggle;
            btn_Undo.Visible = toggle;
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
        public void ResetForm()
        {
            Ctrl.SetupGame(DefaultFileName);
            this.Invalidate();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
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
        private void start_button_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            Ctrl.SetupGame(DefaultFileName);
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
            newButton.BackgroundImage = GetMyPartImage(part);
            newButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(newButton);
        }
        private void Design_buttonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string[] row_col = clickedButton.Name.Split('_');
            Ctrl.DesignLevel[int.Parse(row_col[0]), int.Parse(row_col[1])] = PartType;
            clickedButton.BackgroundImage = GetMyPartImage(PartType);
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
                newButton.BackgroundImage = GetMyPartImage(part);
                newButton.BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(newButton);
                nextXPos += 50;
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
        public void SetButtonHighlight()
        {
            btn_reset.Focus();
        }
        public void DisplayMain()
        {
            throw new NotImplementedException();
        }
        public void FinishGame(string bestPlayer, string bestScore, int thisScore)
        {
            throw new NotImplementedException();
        }
        public void SetMoves(int moves)
        {
            ToggleMoveCountVisibility(true);
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
            Ctrl.SetupGame(DefaultFileName);
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            Ctrl.SetupGame(DefaultFileName);
        }
        private void btn_Undo_Click(object sender, EventArgs e)
        {
            Ctrl.Undo();
        }
        private void btn_GetLevels_Click(object sender, EventArgs e)
        {
            Ctrl.GetLevels();
            //ToggleMoveCountVisibility(false);
            //ToogleListBoxVisiablity(true);
            //lst_FileList.Items.Clear();
            //ClearGameGrid();
            //string[] fileListWithPath = Ctrl.GetFileList();
            //string[] fileList = new string[fileListWithPath.Length];
            //for (int i=0; i<fileListWithPath.Length; i++)
            //{
            //    fileList[i] = fileListWithPath[i].Substring(fileListWithPath[i].LastIndexOf('\\') + 1);
            //}
            //lst_FileList.Items.AddRange(fileList); 
        }
        public void SetupItemList(string[] fileList)
        {
            lst_FileList.Items.Clear();
            lst_FileList.Items.AddRange(fileList);
        }
        private void lst_FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToogleListBoxVisiablity(false);
            ClearGameGrid();
            DefaultFileName = lst_FileList.SelectedItem.ToString();
            Ctrl.SetupGame(DefaultFileName);
            PlayingGame = true;
        }
        public void ClearGameGrid()
        {
            this.CreateGraphics().Clear(FormMain.ActiveForm.BackColor);
        }
        // Designer buttones
        private void btn_Design_Click(object sender, EventArgs e)
        {
            ToggleMoveCountVisibility(false);
            ToogleGameButtonsVisiablity(false);
            ClearGameGrid();
            ToggleChooseDesignerSizeVisibility(true);
            PlayingGame = false;
        }
        public void DesignerLoadLevel()
        {
            throw new NotImplementedException();
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
                Ctrl.SaveDesign();
                ClearDesignArea();
            }
            else SetNotification("Must have: One Player, Equal Number of Goals and Boxes\n"+
                                 "and be surrounded by Walls");
        }
        private void ClearDesignArea()
        {
            ToogleGameButtonsVisiablity(true);
            ToggleChooseDesignerSizeVisibility(false);
            DeleteDesignButtons();
            SetNotification("");
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
    }
}
