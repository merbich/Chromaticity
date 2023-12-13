
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
            this.ColorPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CRGBRadioButton = new System.Windows.Forms.RadioButton();
            this.WhiteGammutRadioButton = new System.Windows.Forms.RadioButton();
            this.SRGBRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chromaticPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BezierPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chromaticPicBox
            // 
            this.chromaticPicBox.Location = new System.Drawing.Point(518, 56);
            this.chromaticPicBox.Name = "chromaticPicBox";
            this.chromaticPicBox.Size = new System.Drawing.Size(500, 500);
            this.chromaticPicBox.TabIndex = 0;
            this.chromaticPicBox.TabStop = false;
            // 
            // BezierPictureBox
            // 
            this.BezierPictureBox.Location = new System.Drawing.Point(12, 56);
            this.BezierPictureBox.Name = "BezierPictureBox";
            this.BezierPictureBox.Size = new System.Drawing.Size(500, 500);
            this.BezierPictureBox.TabIndex = 1;
            this.BezierPictureBox.TabStop = false;
            this.BezierPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BezierPictureBox_MouseDown);
            this.BezierPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BezierPictureBox_MouseMove);
            this.BezierPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BezierPictureBox_MouseUp);
            // 
            // ColorPointsCheckBox
            // 
            this.ColorPointsCheckBox.AutoSize = true;
            this.ColorPointsCheckBox.Location = new System.Drawing.Point(1024, 56);
            this.ColorPointsCheckBox.Name = "ColorPointsCheckBox";
            this.ColorPointsCheckBox.Size = new System.Drawing.Size(149, 24);
            this.ColorPointsCheckBox.TabIndex = 2;
            this.ColorPointsCheckBox.Text = "Draw color points";
            this.ColorPointsCheckBox.UseVisualStyleBackColor = true;
            this.ColorPointsCheckBox.CheckStateChanged += new System.EventHandler(this.ColorPointsCheckBox_CheckStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CRGBRadioButton);
            this.groupBox1.Controls.Add(this.WhiteGammutRadioButton);
            this.groupBox1.Controls.Add(this.SRGBRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(1024, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color model";
            // 
            // CRGBRadioButton
            // 
            this.CRGBRadioButton.AutoSize = true;
            this.CRGBRadioButton.Location = new System.Drawing.Point(7, 89);
            this.CRGBRadioButton.Name = "CRGBRadioButton";
            this.CRGBRadioButton.Size = new System.Drawing.Size(79, 24);
            this.CRGBRadioButton.TabIndex = 2;
            this.CRGBRadioButton.TabStop = true;
            this.CRGBRadioButton.Text = "CIERGB";
            this.CRGBRadioButton.UseVisualStyleBackColor = true;
            this.CRGBRadioButton.CheckedChanged += new System.EventHandler(this.CRGBRadioButton_CheckedChanged);
            // 
            // WhiteGammutRadioButton
            // 
            this.WhiteGammutRadioButton.AutoSize = true;
            this.WhiteGammutRadioButton.Location = new System.Drawing.Point(7, 58);
            this.WhiteGammutRadioButton.Name = "WhiteGammutRadioButton";
            this.WhiteGammutRadioButton.Size = new System.Drawing.Size(113, 24);
            this.WhiteGammutRadioButton.TabIndex = 1;
            this.WhiteGammutRadioButton.TabStop = true;
            this.WhiteGammutRadioButton.Text = "Wide Gamut";
            this.WhiteGammutRadioButton.UseVisualStyleBackColor = true;
            this.WhiteGammutRadioButton.CheckedChanged += new System.EventHandler(this.WhiteGammutRadioButton_CheckedChanged);
            // 
            // SRGBRadioButton
            // 
            this.SRGBRadioButton.AutoSize = true;
            this.SRGBRadioButton.Location = new System.Drawing.Point(7, 27);
            this.SRGBRadioButton.Name = "SRGBRadioButton";
            this.SRGBRadioButton.Size = new System.Drawing.Size(66, 24);
            this.SRGBRadioButton.TabIndex = 0;
            this.SRGBRadioButton.TabStop = true;
            this.SRGBRadioButton.Text = "SRGB";
            this.SRGBRadioButton.UseVisualStyleBackColor = true;
            this.SRGBRadioButton.CheckedChanged += new System.EventHandler(this.SRGBRadioButton_CheckedChanged);
            // 
            // CIEXYZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ColorPointsCheckBox);
            this.Controls.Add(this.BezierPictureBox);
            this.Controls.Add(this.chromaticPicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CIEXYZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CIEXYZ";
            ((System.ComponentModel.ISupportInitialize)(this.chromaticPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BezierPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chromaticPicBox;
        private System.Windows.Forms.PictureBox BezierPictureBox;
        private System.Windows.Forms.CheckBox ColorPointsCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CRGBRadioButton;
        private System.Windows.Forms.RadioButton WhiteGammutRadioButton;
        private System.Windows.Forms.RadioButton SRGBRadioButton;
    }
}

