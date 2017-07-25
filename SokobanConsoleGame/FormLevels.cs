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
    public partial class FormLevels : Form
    {
        public Controller Ctrl;
        public string Filename = "";

        public FormLevels()
        {
            InitializeComponent();
        }
        public void AddController(Controller ctrl)
        {
            Ctrl = ctrl;
        }

        public void SetupItemList(string[] fileList)
        {
            lst_FileList.Items.Clear();
            lst_FileList.Items.AddRange(fileList);
        }
        private void lst_FileList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Filename = lst_FileList.SelectedItem.ToString();
        }
    }
}
