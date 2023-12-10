
namespace Chromaticity
{
    partial class CIEXYZ
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chromaticPicBox = new System.Windows.Forms.PictureBox();
            this.BezierPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chromaticPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BezierPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chromaticPicBox
            // 
            this.chromaticPicBox.Location = new System.Drawing.Point(621, 56);
            this.chromaticPicBox.Name = "chromaticPicBox";
            this.chromaticPicBox.Size = new System.Drawing.Size(500, 500);
            this.chromaticPicBox.TabIndex = 0;
            this.chromaticPicBox.TabStop = false;
            // 
            // BezierPictureBox
            // 
            this.BezierPictureBox.Location = new System.Drawing.Point(47, 56);
            this.BezierPictureBox.Name = "BezierPictureBox";
            this.BezierPictureBox.Size = new System.Drawing.Size(500, 500);
            this.BezierPictureBox.TabIndex = 1;
            this.BezierPictureBox.TabStop = false;
            // 
            // CIEXYZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.BezierPictureBox);
            this.Controls.Add(this.chromaticPicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CIEXYZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CIEXYZ";
            ((System.ComponentModel.ISupportInitialize)(this.chromaticPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BezierPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox chromaticPicBox;
        private System.Windows.Forms.PictureBox BezierPictureBox;
    }
}

