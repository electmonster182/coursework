
namespace _24_21_25_Coursework
{
    partial class Question_Template
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
            this.PicBoxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBoxAvatar
            // 
            this.PicBoxAvatar.Location = new System.Drawing.Point(700, 0);
            this.PicBoxAvatar.Name = "PicBoxAvatar";
            this.PicBoxAvatar.Size = new System.Drawing.Size(100, 74);
            this.PicBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxAvatar.TabIndex = 0;
            this.PicBoxAvatar.TabStop = false;
            this.PicBoxAvatar.Click += new System.EventHandler(this.PicBoxAvatar_Click);
            // 
            // Question_Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PicBoxAvatar);
            this.Name = "Question_Template";
            this.Text = "Question_Template";
            this.Load += new System.EventHandler(this.Question_Template_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBoxAvatar;
    }
}