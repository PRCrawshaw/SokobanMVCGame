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
        private string DefaultFileName;
        private Graphics Graphics;
        
        // Setup methods
        public FormMain()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }

        // set text fields
        public void SetDefaultFileName(string name)
        {
            DefaultFileName = name;
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
            Ctrl.SetupDesignForm();
        }
        private void btn_QuitDesign_Click(object sender, EventArgs e)
        {
            Ctrl.QuitDesign();
        }
    }
}
