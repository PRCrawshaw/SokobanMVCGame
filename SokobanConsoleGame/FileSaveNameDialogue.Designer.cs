namespace SokobanConsoleGame
{
    partial class FileSaveNameDialogue
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_Filename = new System.Windows.Forms.Label();
            this.txt_Filename = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(314, 205);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(137, 46);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(477, 205);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(137, 46);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "Ok";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // lbl_Filename
            // 
            this.lbl_Filename.AutoSize = true;
            this.lbl_Filename.Location = new System.Drawing.Point(107, 88);
            this.lbl_Filename.Name = "lbl_Filename";
            this.lbl_Filename.Size = new System.Drawing.Size(106, 25);
            this.lbl_Filename.TabIndex = 2;
            this.lbl_Filename.Text = "File name";
            // 
            // txt_Filename
            // 
            this.txt_Filename.Location = new System.Drawing.Point(250, 81);
            this.txt_Filename.Name = "txt_Filename";
            this.txt_Filename.Size = new System.Drawing.Size(344, 31);
            this.txt_Filename.TabIndex = 3;
            // 
            // FileSaveNameDialogue
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(637, 280);
            this.Controls.Add(this.txt_Filename);
            this.Controls.Add(this.lbl_Filename);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSaveNameDialogue";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FileSaveNameDialogue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_Filename;
        private System.Windows.Forms.TextBox txt_Filename;
    }
}