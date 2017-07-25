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
            this.nup_Cols = new System.Windows.Forms.NumericUpDown();
            this.nup_Rows = new System.Windows.Forms.NumericUpDown();
            this.lbl_NoCols = new System.Windows.Forms.Label();
            this.lbl_NoRows = new System.Windows.Forms.Label();
            this.btn_StartDesign = new System.Windows.Forms.Button();
            this.btn_SaveDesign = new System.Windows.Forms.Button();
            this.btn_QuitDesign = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Rows)).BeginInit();
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
            this.btn_GetLevels.Location = new System.Drawing.Point(42, 350);
            this.btn_GetLevels.Name = "btn_GetLevels";
            this.btn_GetLevels.Size = new System.Drawing.Size(183, 67);
            this.btn_GetLevels.TabIndex = 7;
            this.btn_GetLevels.Text = "Get Levels";
            this.btn_GetLevels.UseVisualStyleBackColor = true;
            this.btn_GetLevels.Click += new System.EventHandler(this.btn_GetLevels_Click);
            // 
            // btn_Design
            // 
            this.btn_Design.Location = new System.Drawing.Point(42, 443);
            this.btn_Design.Name = "btn_Design";
            this.btn_Design.Size = new System.Drawing.Size(183, 67);
            this.btn_Design.TabIndex = 8;
            this.btn_Design.Text = "Design Level";
            this.btn_Design.UseVisualStyleBackColor = true;
            this.btn_Design.Click += new System.EventHandler(this.btn_Design_Click);
            // 
            // nup_Cols
            // 
            this.nup_Cols.Location = new System.Drawing.Point(483, 128);
            this.nup_Cols.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nup_Cols.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nup_Cols.Name = "nup_Cols";
            this.nup_Cols.Size = new System.Drawing.Size(80, 31);
            this.nup_Cols.TabIndex = 9;
            this.nup_Cols.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // nup_Rows
            // 
            this.nup_Rows.Location = new System.Drawing.Point(483, 81);
            this.nup_Rows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nup_Rows.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nup_Rows.Name = "nup_Rows";
            this.nup_Rows.Size = new System.Drawing.Size(80, 31);
            this.nup_Rows.TabIndex = 10;
            this.nup_Rows.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lbl_NoCols
            // 
            this.lbl_NoCols.AutoSize = true;
            this.lbl_NoCols.Location = new System.Drawing.Point(258, 128);
            this.lbl_NoCols.Name = "lbl_NoCols";
            this.lbl_NoCols.Size = new System.Drawing.Size(225, 25);
            this.lbl_NoCols.TabIndex = 11;
            this.lbl_NoCols.Text = "Number of Columns....";
            // 
            // lbl_NoRows
            // 
            this.lbl_NoRows.AutoSize = true;
            this.lbl_NoRows.Location = new System.Drawing.Point(258, 83);
            this.lbl_NoRows.Name = "lbl_NoRows";
            this.lbl_NoRows.Size = new System.Drawing.Size(224, 25);
            this.lbl_NoRows.TabIndex = 12;
            this.lbl_NoRows.Text = "Number of Rows.........";
            // 
            // btn_StartDesign
            // 
            this.btn_StartDesign.Location = new System.Drawing.Point(380, 183);
            this.btn_StartDesign.Name = "btn_StartDesign";
            this.btn_StartDesign.Size = new System.Drawing.Size(183, 67);
            this.btn_StartDesign.TabIndex = 13;
            this.btn_StartDesign.Text = " Start";
            this.btn_StartDesign.UseVisualStyleBackColor = true;
            this.btn_StartDesign.Click += new System.EventHandler(this.btn_StartDesign_Click);
            // 
            // btn_SaveDesign
            // 
            this.btn_SaveDesign.Location = new System.Drawing.Point(42, 443);
            this.btn_SaveDesign.Name = "btn_SaveDesign";
            this.btn_SaveDesign.Size = new System.Drawing.Size(183, 67);
            this.btn_SaveDesign.TabIndex = 14;
            this.btn_SaveDesign.Text = "Save Design";
            this.btn_SaveDesign.UseVisualStyleBackColor = true;
            this.btn_SaveDesign.Click += new System.EventHandler(this.btn_SaveDesign_Click);
            // 
            // btn_QuitDesign
            // 
            this.btn_QuitDesign.Location = new System.Drawing.Point(42, 535);
            this.btn_QuitDesign.Name = "btn_QuitDesign";
            this.btn_QuitDesign.Size = new System.Drawing.Size(183, 67);
            this.btn_QuitDesign.TabIndex = 15;
            this.btn_QuitDesign.Text = "Quit Design";
            this.btn_QuitDesign.UseVisualStyleBackColor = true;
            this.btn_QuitDesign.Click += new System.EventHandler(this.btn_QuitDesign_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 1013);
            this.Controls.Add(this.btn_QuitDesign);
            this.Controls.Add(this.btn_SaveDesign);
            this.Controls.Add(this.btn_StartDesign);
            this.Controls.Add(this.lbl_NoRows);
            this.Controls.Add(this.lbl_NoCols);
            this.Controls.Add(this.nup_Rows);
            this.Controls.Add(this.nup_Cols);
            this.Controls.Add(this.btn_Design);
            this.Controls.Add(this.btn_GetLevels);
            this.Controls.Add(this.btn_start);
            this.Name = "FormMain";
            this.Text = "Sokoban";
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Rows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_GetLevels;
        private System.Windows.Forms.Button btn_Design;
        private System.Windows.Forms.NumericUpDown nup_Cols;
        private System.Windows.Forms.NumericUpDown nup_Rows;
        private System.Windows.Forms.Label lbl_NoCols;
        private System.Windows.Forms.Label lbl_NoRows;
        private System.Windows.Forms.Button btn_StartDesign;
        private System.Windows.Forms.Button btn_SaveDesign;
        private System.Windows.Forms.Button btn_QuitDesign;
    }
}