namespace SokobanConsoleGame
{
    partial class FormDesignGame
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
            this.btn_QuitDesign = new System.Windows.Forms.Button();
            this.btn_SaveDesign = new System.Windows.Forms.Button();
            this.btn_StartDesign = new System.Windows.Forms.Button();
            this.lbl_NoRows = new System.Windows.Forms.Label();
            this.lbl_NoCols = new System.Windows.Forms.Label();
            this.nup_Rows = new System.Windows.Forms.NumericUpDown();
            this.nup_Cols = new System.Windows.Forms.NumericUpDown();
            this.lbl_Notification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cols)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_QuitDesign
            // 
            this.btn_QuitDesign.Location = new System.Drawing.Point(22, 172);
            this.btn_QuitDesign.Name = "btn_QuitDesign";
            this.btn_QuitDesign.Size = new System.Drawing.Size(183, 67);
            this.btn_QuitDesign.TabIndex = 22;
            this.btn_QuitDesign.Text = "Quit Design";
            this.btn_QuitDesign.UseVisualStyleBackColor = true;
            this.btn_QuitDesign.Click += new System.EventHandler(this.btn_QuitDesign_Click);
            // 
            // btn_SaveDesign
            // 
            this.btn_SaveDesign.Location = new System.Drawing.Point(22, 79);
            this.btn_SaveDesign.Name = "btn_SaveDesign";
            this.btn_SaveDesign.Size = new System.Drawing.Size(183, 67);
            this.btn_SaveDesign.TabIndex = 21;
            this.btn_SaveDesign.Text = "Save Design";
            this.btn_SaveDesign.UseVisualStyleBackColor = true;
            this.btn_SaveDesign.Click += new System.EventHandler(this.btn_SaveDesign_Click);
            // 
            // btn_StartDesign
            // 
            this.btn_StartDesign.Location = new System.Drawing.Point(360, 181);
            this.btn_StartDesign.Name = "btn_StartDesign";
            this.btn_StartDesign.Size = new System.Drawing.Size(183, 67);
            this.btn_StartDesign.TabIndex = 20;
            this.btn_StartDesign.Text = " Start";
            this.btn_StartDesign.UseVisualStyleBackColor = true;
            this.btn_StartDesign.Click += new System.EventHandler(this.btn_StartDesign_Click);
            // 
            // lbl_NoRows
            // 
            this.lbl_NoRows.AutoSize = true;
            this.lbl_NoRows.Location = new System.Drawing.Point(238, 81);
            this.lbl_NoRows.Name = "lbl_NoRows";
            this.lbl_NoRows.Size = new System.Drawing.Size(224, 25);
            this.lbl_NoRows.TabIndex = 19;
            this.lbl_NoRows.Text = "Number of Rows.........";
            // 
            // lbl_NoCols
            // 
            this.lbl_NoCols.AutoSize = true;
            this.lbl_NoCols.Location = new System.Drawing.Point(238, 126);
            this.lbl_NoCols.Name = "lbl_NoCols";
            this.lbl_NoCols.Size = new System.Drawing.Size(225, 25);
            this.lbl_NoCols.TabIndex = 18;
            this.lbl_NoCols.Text = "Number of Columns....";
            // 
            // nup_Rows
            // 
            this.nup_Rows.Location = new System.Drawing.Point(463, 79);
            this.nup_Rows.Maximum = new decimal(new int[] {
            14,
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
            this.nup_Rows.TabIndex = 17;
            this.nup_Rows.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // nup_Cols
            // 
            this.nup_Cols.Location = new System.Drawing.Point(463, 126);
            this.nup_Cols.Maximum = new decimal(new int[] {
            14,
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
            this.nup_Cols.TabIndex = 16;
            this.nup_Cols.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lbl_Notification
            // 
            this.lbl_Notification.AutoSize = true;
            this.lbl_Notification.Location = new System.Drawing.Point(238, 15);
            this.lbl_Notification.Name = "lbl_Notification";
            this.lbl_Notification.Size = new System.Drawing.Size(0, 25);
            this.lbl_Notification.TabIndex = 23;
            // 
            // FormDesignGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 1244);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Notification);
            this.Controls.Add(this.btn_QuitDesign);
            this.Controls.Add(this.btn_SaveDesign);
            this.Controls.Add(this.btn_StartDesign);
            this.Controls.Add(this.lbl_NoRows);
            this.Controls.Add(this.lbl_NoCols);
            this.Controls.Add(this.nup_Rows);
            this.Controls.Add(this.nup_Cols);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(120, 120);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDesignGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.nup_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_QuitDesign;
        private System.Windows.Forms.Button btn_SaveDesign;
        private System.Windows.Forms.Button btn_StartDesign;
        private System.Windows.Forms.Label lbl_NoRows;
        private System.Windows.Forms.Label lbl_NoCols;
        private System.Windows.Forms.NumericUpDown nup_Rows;
        private System.Windows.Forms.NumericUpDown nup_Cols;
        private System.Windows.Forms.Label lbl_Notification;
    }
}