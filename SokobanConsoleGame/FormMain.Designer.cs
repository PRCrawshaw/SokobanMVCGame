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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "block38.png");
            this.imageList1.Images.SetKeyName(1, "blocktarget38.jpg");
            this.imageList1.Images.SetKeyName(2, "empty38.jpg");
            this.imageList1.Images.SetKeyName(3, "player38.png");
            this.imageList1.Images.SetKeyName(4, "playertarget38.jpg");
            this.imageList1.Images.SetKeyName(5, "target38.jpg");
            this.imageList1.Images.SetKeyName(6, "wall38.jpg");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 890);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ImageList imageList1;
    }
}