
namespace _24_21_25_Coursework
{
    partial class Random_Question
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
            this.txtAwser = new System.Windows.Forms.TextBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnCheckAnswer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(502, 120);
            this.txtQuestion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(446, 31);
            this.txtQuestion.TabIndex = 0;
            this.txtQuestion.TextChanged += new System.EventHandler(this.txtQuestion_TextChanged);
            // 
            // txtAwser
            // 
            this.txtAwser.Location = new System.Drawing.Point(502, 272);
            this.txtAwser.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAwser.Name = "txtAwser";
            this.txtAwser.Size = new System.Drawing.Size(446, 31);
            this.txtAwser.TabIndex = 1;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(150, 44);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "button1";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnCheckAnswer
            // 
            this.btnCheckAnswer.Location = new System.Drawing.Point(633, 511);
            this.btnCheckAnswer.Margin = new System.Windows.Forms.Padding(6);
            this.btnCheckAnswer.Name = "btnCheckAnswer";
            this.btnCheckAnswer.Size = new System.Drawing.Size(205, 44);
            this.btnCheckAnswer.TabIndex = 3;
            this.btnCheckAnswer.Text = "Check Answer";
            this.btnCheckAnswer.UseVisualStyleBackColor = true;
            
            // 
            // Random_Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.btnCheckAnswer);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.txtAwser);
            this.Controls.Add(this.txtQuestion);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Random_Question";
            this.Text = "Random_Question";
            this.Load += new System.EventHandler(this.Random_Question_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtAwser;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCheckAnswer;
    }
}