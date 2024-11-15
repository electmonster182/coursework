
namespace _24_21_25_Coursework
{
    partial class AdminCreateQuestion
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
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtAnwser = new System.Windows.Forms.TextBox();
            this.btnCreateQuestion = new System.Windows.Forms.Button();
            this.btnReturnToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(187, 83);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(273, 20);
            this.txtQuestion.TabIndex = 0;
            // 
            // txtAnwser
            // 
            this.txtAnwser.Location = new System.Drawing.Point(187, 151);
            this.txtAnwser.Name = "txtAnwser";
            this.txtAnwser.Size = new System.Drawing.Size(273, 20);
            this.txtAnwser.TabIndex = 1;
            // 
            // btnCreateQuestion
            // 
            this.btnCreateQuestion.Location = new System.Drawing.Point(196, 216);
            this.btnCreateQuestion.Name = "btnCreateQuestion";
            this.btnCreateQuestion.Size = new System.Drawing.Size(173, 47);
            this.btnCreateQuestion.TabIndex = 2;
            this.btnCreateQuestion.Text = "button1";
            this.btnCreateQuestion.UseVisualStyleBackColor = true;
            this.btnCreateQuestion.Click += new System.EventHandler(this.btnCreateQuestion_Click);
            // 
            // btnReturnToMenu
            // 
            this.btnReturnToMenu.Location = new System.Drawing.Point(0, -5);
            this.btnReturnToMenu.Name = "btnReturnToMenu";
            this.btnReturnToMenu.Size = new System.Drawing.Size(173, 47);
            this.btnReturnToMenu.TabIndex = 3;
            this.btnReturnToMenu.Text = "button1";
            this.btnReturnToMenu.UseVisualStyleBackColor = true;
            this.btnReturnToMenu.Click += new System.EventHandler(this.btnReturnToMenu_Click);
            // 
            // AdminCreateQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReturnToMenu);
            this.Controls.Add(this.btnCreateQuestion);
            this.Controls.Add(this.txtAnwser);
            this.Controls.Add(this.txtQuestion);
            this.Name = "AdminCreateQuestion";
            this.Text = "AdminCreateQuestion";
            this.Load += new System.EventHandler(this.AdminCreateQuestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtAnwser;
        private System.Windows.Forms.Button btnCreateQuestion;
        private System.Windows.Forms.Button btnReturnToMenu;
    }
}