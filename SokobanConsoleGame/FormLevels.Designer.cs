namespace SokobanConsoleGame
{
    partial class FormLevels
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_FileList = new System.Windows.Forms.ListBox();
            this.btn_LevelsOk = new System.Windows.Forms.Button();
            this.btn_LevelsCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_FileList
            // 
            this.lst_FileList.FormattingEnabled = true;
            this.lst_FileList.ItemHeight = 25;
            this.lst_FileList.Location = new System.Drawing.Point(164, 63);
            this.lst_FileList.Name = "lst_FileList";
            this.lst_FileList.Size = new System.Drawing.Size(310, 429);
            this.lst_FileList.TabIndex = 7;
            this.lst_FileList.SelectedIndexChanged += new System.EventHandler(this.lst_FileList_SelectedIndexChanged_1);
            // 
            // btn_LevelsOk
            // 
            this.btn_LevelsOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_LevelsOk.Location = new System.Drawing.Point(419, 545);
            this.btn_LevelsOk.Name = "btn_LevelsOk";
            this.btn_LevelsOk.Size = new System.Drawing.Size(147, 50);
            this.btn_LevelsOk.TabIndex = 8;
            this.btn_LevelsOk.Text = "Ok";
            this.btn_LevelsOk.UseVisualStyleBackColor = true;
            // 
            // btn_LevelsCancel
            // 
            this.btn_LevelsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_LevelsCancel.Location = new System.Drawing.Point(253, 545);
            this.btn_LevelsCancel.Name = "btn_LevelsCancel";
            this.btn_LevelsCancel.Size = new System.Drawing.Size(147, 50);
            this.btn_LevelsCancel.TabIndex = 9;
            this.btn_LevelsCancel.Text = "Cancel";
            this.btn_LevelsCancel.UseVisualStyleBackColor = true;
            // 
            // FormLevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 671);
            this.ControlBox = false;
            this.Controls.Add(this.btn_LevelsCancel);
            this.Controls.Add(this.btn_LevelsOk);
            this.Controls.Add(this.lst_FileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLevels";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_FileList;
        private System.Windows.Forms.Button btn_LevelsOk;
        private System.Windows.Forms.Button btn_LevelsCancel;
    }
}