using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SokobanGame;

namespace SokobanConsoleGame
{
    public partial class FileSaveNameDialogue : Form
    {
        public FileSaveNameDialogue()
        {
            InitializeComponent();
        }
        public string GetName()
        {
            return txt_Filename.Text;
        }

        public void SetName(string name)
        {
            txt_Filename.Text = name;
        }

        public void SetLabel(string label)
        {
            lbl_Filename.Text = label;
        }
    }
}
