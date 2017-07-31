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
            this.btn_GetLevels = new System.Windows.Forms.Button();
            this.btn_Design = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
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
            // btn_GetLevels
            // 
            this.btn_GetLevels.Location = new System.Drawing.Point(42, 172);
            this.btn_GetLevels.Name = "btn_GetLevels";
            this.btn_GetLevels.Size = new System.Drawing.Size(183, 67);
            this.btn_GetLevels.TabIndex = 7;
            this.btn_GetLevels.Text = "Get Levels";
            this.btn_GetLevels.UseVisualStyleBackColor = true;
            this.btn_GetLevels.Click += new System.EventHandler(this.btn_GetLevels_Click);
            // 
            // btn_Design
            // 
            this.btn_Design.Location = new System.Drawing.Point(42, 271);
            this.btn_Design.Name = "btn_Design";
            this.btn_Design.Size = new System.Drawing.Size(183, 67);
            this.btn_Design.TabIndex = 8;
            this.btn_Design.Text = "Design Level";
            this.btn_Design.UseVisualStyleBackColor = true;
            this.btn_Design.Click += new System.EventHandler(this.btn_Design_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(42, 484);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(183, 61);
            this.btn_Quit.TabIndex = 9;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 1013);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Design);
            this.Controls.Add(this.btn_GetLevels);
            this.Controls.Add(this.btn_start);
            this.Location = new System.Drawing.Point(120, 120);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sokoban";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_GetLevels;
        private System.Windows.Forms.Button btn_Design;
        private System.Windows.Forms.Button btn_Quit;
    }
}