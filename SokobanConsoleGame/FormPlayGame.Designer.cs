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
            this.SuspendLayout();
            // 
            // btn_Undo
            // 
            this.btn_Undo.Location = new System.Drawing.Point(24, 271);
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
            this.lbl_MoveCountNo.Location = new System.Drawing.Point(347, 25);
            this.lbl_MoveCountNo.Name = "lbl_MoveCountNo";
            this.lbl_MoveCountNo.Size = new System.Drawing.Size(24, 25);
            this.lbl_MoveCountNo.TabIndex = 8;
            this.lbl_MoveCountNo.Text = "0";
            // 
            // lbl_MoveCount
            // 
            this.lbl_MoveCount.AutoSize = true;
            this.lbl_MoveCount.Location = new System.Drawing.Point(216, 25);
            this.lbl_MoveCount.Name = "lbl_MoveCount";
            this.lbl_MoveCount.Size = new System.Drawing.Size(134, 25);
            this.lbl_MoveCount.TabIndex = 7;
            this.lbl_MoveCount.Text = "Move Count:";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(24, 179);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(183, 67);
            this.btn_reset.TabIndex = 6;
            this.btn_reset.TabStop = false;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_GameClose
            // 
            this.btn_GameClose.Location = new System.Drawing.Point(24, 360);
            this.btn_GameClose.Name = "btn_GameClose";
            this.btn_GameClose.Size = new System.Drawing.Size(183, 67);
            this.btn_GameClose.TabIndex = 11;
            this.btn_GameClose.TabStop = false;
            this.btn_GameClose.Text = "Close";
            this.btn_GameClose.UseVisualStyleBackColor = true;
            this.btn_GameClose.Click += new System.EventHandler(this.btn_GameClose_Click);
            // 
            // FormPlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 998);
            this.Controls.Add(this.btn_GameClose);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.lbl_Notification);
            this.Controls.Add(this.lbl_MoveCountNo);
            this.Controls.Add(this.lbl_MoveCount);
            this.Controls.Add(this.btn_reset);
            this.Name = "FormPlayGame";
            this.Text = "FormPlayGame";
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
    }
}