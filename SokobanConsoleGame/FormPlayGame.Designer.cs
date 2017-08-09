namespace SokobanConsoleGame
{
    partial class FormPlayGame
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
            this.btn_Undo = new System.Windows.Forms.Button();
            this.lbl_Notification = new System.Windows.Forms.Label();
            this.lbl_MoveCountNo = new System.Windows.Forms.Label();
            this.lbl_MoveCount = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_GameClose = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Resume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Undo
            // 
            this.btn_Undo.Location = new System.Drawing.Point(27, 167);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(183, 67);
            this.btn_Undo.TabIndex = 10;
            this.btn_Undo.TabStop = false;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click_1);
            // 
            // lbl_Notification
            // 
            this.lbl_Notification.AutoSize = true;
            this.lbl_Notification.Location = new System.Drawing.Point(460, 25);
            this.lbl_Notification.Name = "lbl_Notification";
            this.lbl_Notification.Size = new System.Drawing.Size(0, 25);
            this.lbl_Notification.TabIndex = 9;
            // 
            // lbl_MoveCountNo
            // 
            this.lbl_MoveCountNo.AutoSize = true;
            this.lbl_MoveCountNo.Location = new System.Drawing.Point(367, 25);
            this.lbl_MoveCountNo.Name = "lbl_MoveCountNo";
            this.lbl_MoveCountNo.Size = new System.Drawing.Size(24, 25);
            this.lbl_MoveCountNo.TabIndex = 8;
            this.lbl_MoveCountNo.Text = "0";
            // 
            // lbl_MoveCount
            // 
            this.lbl_MoveCount.AutoSize = true;
            this.lbl_MoveCount.Location = new System.Drawing.Point(236, 25);
            this.lbl_MoveCount.Name = "lbl_MoveCount";
            this.lbl_MoveCount.Size = new System.Drawing.Size(134, 25);
            this.lbl_MoveCount.TabIndex = 7;
            this.lbl_MoveCount.Text = "Move Count:";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(27, 75);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(183, 67);
            this.btn_reset.TabIndex = 6;
            this.btn_reset.TabStop = false;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click_1);
            // 
            // btn_GameClose
            // 
            this.btn_GameClose.Location = new System.Drawing.Point(27, 256);
            this.btn_GameClose.Name = "btn_GameClose";
            this.btn_GameClose.Size = new System.Drawing.Size(183, 67);
            this.btn_GameClose.TabIndex = 11;
            this.btn_GameClose.TabStop = false;
            this.btn_GameClose.Text = "Close";
            this.btn_GameClose.UseVisualStyleBackColor = true;
            this.btn_GameClose.Click += new System.EventHandler(this.btn_GameClose_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(1017, 75);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(183, 67);
            this.btn_Save.TabIndex = 12;
            this.btn_Save.TabStop = false;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Resume
            // 
            this.btn_Resume.Location = new System.Drawing.Point(1017, 167);
            this.btn_Resume.Name = "btn_Resume";
            this.btn_Resume.Size = new System.Drawing.Size(183, 67);
            this.btn_Resume.TabIndex = 13;
            this.btn_Resume.TabStop = false;
            this.btn_Resume.Text = "Resume";
            this.btn_Resume.UseVisualStyleBackColor = true;
            this.btn_Resume.Click += new System.EventHandler(this.btn_Resume_Click);
            // 
            // FormPlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 998);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Resume);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_GameClose);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.lbl_Notification);
            this.Controls.Add(this.lbl_MoveCountNo);
            this.Controls.Add(this.lbl_MoveCount);
            this.Controls.Add(this.btn_reset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPlayGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Undo;
        private System.Windows.Forms.Label lbl_Notification;
        private System.Windows.Forms.Label lbl_MoveCountNo;
        private System.Windows.Forms.Label lbl_MoveCount;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_GameClose;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Resume;
    }
}