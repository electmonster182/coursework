﻿
namespace _24_21_25_Coursework
{
    partial class HomePage
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
            this.btnsidebar = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnEasyQuiz = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnAdminSettings = new System.Windows.Forms.Button();
            this.btnRandomQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnsidebar
            // 
            this.btnsidebar.BackColor = System.Drawing.Color.White;
            this.btnsidebar.Enabled = false;
            this.btnsidebar.Location = new System.Drawing.Point(0, -18);
            this.btnsidebar.Name = "btnsidebar";
            this.btnsidebar.Size = new System.Drawing.Size(96, 474);
            this.btnsidebar.TabIndex = 0;
            this.btnsidebar.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 38);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.White;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(0, 43);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(96, 70);
            this.btnSignOut.TabIndex = 9;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnEasyQuiz
            // 
            this.btnEasyQuiz.BackColor = System.Drawing.Color.White;
            this.btnEasyQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEasyQuiz.Location = new System.Drawing.Point(95, 114);
            this.btnEasyQuiz.Name = "btnEasyQuiz";
            this.btnEasyQuiz.Size = new System.Drawing.Size(171, 70);
            this.btnEasyQuiz.TabIndex = 10;
            this.btnEasyQuiz.Text = "Easy Quiz";
            this.btnEasyQuiz.UseVisualStyleBackColor = false;
            this.btnEasyQuiz.Click += new System.EventHandler(this.btnEasyQuiz_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.White;
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Location = new System.Drawing.Point(-9, 368);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(105, 70);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "Settings";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnAdminSettings
            // 
            this.btnAdminSettings.BackColor = System.Drawing.Color.White;
            this.btnAdminSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminSettings.Location = new System.Drawing.Point(-9, 282);
            this.btnAdminSettings.Name = "btnAdminSettings";
            this.btnAdminSettings.Size = new System.Drawing.Size(105, 70);
            this.btnAdminSettings.TabIndex = 12;
            this.btnAdminSettings.Text = "Admin settings";
            this.btnAdminSettings.UseVisualStyleBackColor = false;
            this.btnAdminSettings.Click += new System.EventHandler(this.btnAdminSettings_Click);
            // 
            // btnRandomQuestion
            // 
            this.btnRandomQuestion.BackColor = System.Drawing.Color.White;
            this.btnRandomQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomQuestion.Location = new System.Drawing.Point(102, 199);
            this.btnRandomQuestion.Name = "btnRandomQuestion";
            this.btnRandomQuestion.Size = new System.Drawing.Size(171, 70);
            this.btnRandomQuestion.TabIndex = 13;
            this.btnRandomQuestion.Text = "random";
            this.btnRandomQuestion.UseVisualStyleBackColor = false;
            this.btnRandomQuestion.Click += new System.EventHandler(this.btnRandomQuestion_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRandomQuestion);
            this.Controls.Add(this.btnAdminSettings);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnEasyQuiz);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnsidebar);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnsidebar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnEasyQuiz;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnAdminSettings;
        private System.Windows.Forms.Button btnRandomQuestion;
    }
}