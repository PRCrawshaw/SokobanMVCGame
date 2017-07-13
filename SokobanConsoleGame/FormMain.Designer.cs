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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 890);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_start);
            this.Name = "FormMain";
            this.Text = "Sokoban";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_reset;
    }
}