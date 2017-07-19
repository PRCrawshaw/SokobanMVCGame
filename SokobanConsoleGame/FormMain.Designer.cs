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
            this.lst_FileList = new System.Windows.Forms.ListBox();
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
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(42, 167);
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
            this.btn_Undo.Location = new System.Drawing.Point(42, 259);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(183, 67);
            this.btn_Undo.TabIndex = 5;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // lst_FileList
            // 
            this.lst_FileList.FormattingEnabled = true;
            this.lst_FileList.ItemHeight = 25;
            this.lst_FileList.Location = new System.Drawing.Point(253, 81);
            this.lst_FileList.Name = "lst_FileList";
            this.lst_FileList.Size = new System.Drawing.Size(310, 429);
            this.lst_FileList.TabIndex = 6;
            this.lst_FileList.Visible = false;
            this.lst_FileList.SelectedIndexChanged += new System.EventHandler(this.lst_FileList_SelectedIndexChanged);
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
            this.Controls.Add(this.lst_FileList);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.lbl_Notification);
            this.Controls.Add(this.lbl_MoveCountNo);
            this.Controls.Add(this.lbl_MoveCount);
            this.Controls.Add(this.btn_reset);
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
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_MoveCount;
        private System.Windows.Forms.Label lbl_MoveCountNo;
        private System.Windows.Forms.Label lbl_Notification;
        private System.Windows.Forms.Button btn_Undo;
        private System.Windows.Forms.ListBox lst_FileList;
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