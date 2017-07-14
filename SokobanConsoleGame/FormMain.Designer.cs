using System;

namespace SokobanGame
{
    public partial class FormMain
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
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lbl_MoveCount = new System.Windows.Forms.Label();
            this.lbl_MoveCountNo = new System.Windows.Forms.Label();
            this.lbl_Notification = new System.Windows.Forms.Label();
            this.btn_Undo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(42, 81);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(183, 61);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start Game";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.start_button_Click_1);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(42, 183);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(183, 67);
            this.btn_reset.TabIndex = 1;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lbl_MoveCount
            // 
            this.lbl_MoveCount.AutoSize = true;
            this.lbl_MoveCount.Location = new System.Drawing.Point(234, 13);
            this.lbl_MoveCount.Name = "lbl_MoveCount";
            this.lbl_MoveCount.Size = new System.Drawing.Size(134, 25);
            this.lbl_MoveCount.TabIndex = 2;
            this.lbl_MoveCount.Text = "Move Count:";
            // 
            // lbl_MoveCountNo
            // 
            this.lbl_MoveCountNo.AutoSize = true;
            this.lbl_MoveCountNo.Location = new System.Drawing.Point(365, 13);
            this.lbl_MoveCountNo.Name = "lbl_MoveCountNo";
            this.lbl_MoveCountNo.Size = new System.Drawing.Size(24, 25);
            this.lbl_MoveCountNo.TabIndex = 3;
            this.lbl_MoveCountNo.Text = "0";
            // 
            // lbl_Notification
            // 
            this.lbl_Notification.AutoSize = true;
            this.lbl_Notification.Location = new System.Drawing.Point(478, 13);
            this.lbl_Notification.Name = "lbl_Notification";
            this.lbl_Notification.Size = new System.Drawing.Size(18, 25);
            this.lbl_Notification.TabIndex = 4;
            this.lbl_Notification.Text = " ";
            // 
            // btn_Undo
            // 
            this.btn_Undo.Location = new System.Drawing.Point(42, 300);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(183, 67);
            this.btn_Undo.TabIndex = 5;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 890);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.lbl_Notification);
            this.Controls.Add(this.lbl_MoveCountNo);
            this.Controls.Add(this.lbl_MoveCount);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_start);
            this.Name = "FormMain";
            this.Text = "Sokoban";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_MoveCount;
        private System.Windows.Forms.Label lbl_MoveCountNo;
        private System.Windows.Forms.Label lbl_Notification;
        private System.Windows.Forms.Button btn_Undo;
    }
}