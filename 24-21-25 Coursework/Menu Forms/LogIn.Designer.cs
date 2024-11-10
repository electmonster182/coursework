
namespace _24_21_25_Coursework
{
    partial class LogIn
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblDontHaveAcount = new System.Windows.Forms.LinkLabel();
            this.btnShowpasswordLogIn = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCarQuizText = new System.Windows.Forms.Button();
            this.txtEnterPassword = new System.Windows.Forms.TextBox();
            this.txtEnterUsername = new System.Windows.Forms.TextBox();
            this.btnbackground = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(279, 159);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(233, 26);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Tag = "";
            this.txtUsername.Click += new System.EventHandler(this.txtUsername_Click);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtPassword.Location = new System.Drawing.Point(279, 222);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(233, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.White;
            this.btnLogIn.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.Black;
            this.btnLogIn.Location = new System.Drawing.Point(328, 303);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(123, 47);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lblDontHaveAcount
            // 
            this.lblDontHaveAcount.AutoSize = true;
            this.lblDontHaveAcount.BackColor = System.Drawing.Color.White;
            this.lblDontHaveAcount.DisabledLinkColor = System.Drawing.Color.White;
            this.lblDontHaveAcount.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDontHaveAcount.Location = new System.Drawing.Point(254, 371);
            this.lblDontHaveAcount.Name = "lblDontHaveAcount";
            this.lblDontHaveAcount.Size = new System.Drawing.Size(272, 19);
            this.lblDontHaveAcount.TabIndex = 6;
            this.lblDontHaveAcount.TabStop = true;
            this.lblDontHaveAcount.Text = "Don\'t have an account click here";
            this.lblDontHaveAcount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDontHaveAcount_LinkClicked);
            // 
            // btnShowpasswordLogIn
            // 
            this.btnShowpasswordLogIn.AutoSize = true;
            this.btnShowpasswordLogIn.BackColor = System.Drawing.Color.White;
            this.btnShowpasswordLogIn.Location = new System.Drawing.Point(279, 268);
            this.btnShowpasswordLogIn.Name = "btnShowpasswordLogIn";
            this.btnShowpasswordLogIn.Size = new System.Drawing.Size(102, 17);
            this.btnShowpasswordLogIn.TabIndex = 4;
            this.btnShowpasswordLogIn.Text = "Show Password";
            this.btnShowpasswordLogIn.UseVisualStyleBackColor = false;
            this.btnShowpasswordLogIn.CheckedChanged += new System.EventHandler(this.btnShowpasswordLogIn_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(11, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 38);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCarQuizText
            // 
            this.btnCarQuizText.BackColor = System.Drawing.Color.White;
            this.btnCarQuizText.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarQuizText.ForeColor = System.Drawing.Color.Black;
            this.btnCarQuizText.Location = new System.Drawing.Point(318, 34);
            this.btnCarQuizText.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.btnCarQuizText.Name = "btnCarQuizText";
            this.btnCarQuizText.Size = new System.Drawing.Size(144, 63);
            this.btnCarQuizText.TabIndex = 21;
            this.btnCarQuizText.TabStop = false;
            this.btnCarQuizText.Text = "Car Quiz";
            this.btnCarQuizText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarQuizText.UseVisualStyleBackColor = false;
            // 
            // txtEnterPassword
            // 
            this.txtEnterPassword.BackColor = System.Drawing.Color.White;
            this.txtEnterPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEnterPassword.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterPassword.ForeColor = System.Drawing.Color.Black;
            this.txtEnterPassword.Location = new System.Drawing.Point(279, 197);
            this.txtEnterPassword.Name = "txtEnterPassword";
            this.txtEnterPassword.ReadOnly = true;
            this.txtEnterPassword.Size = new System.Drawing.Size(200, 19);
            this.txtEnterPassword.TabIndex = 22;
            this.txtEnterPassword.Text = "Enter Username";
            this.txtEnterPassword.TextChanged += new System.EventHandler(this.txtEnterPassword_TextChanged);
            // 
            // txtEnterUsername
            // 
            this.txtEnterUsername.BackColor = System.Drawing.Color.White;
            this.txtEnterUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEnterUsername.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterUsername.ForeColor = System.Drawing.Color.Black;
            this.txtEnterUsername.Location = new System.Drawing.Point(279, 134);
            this.txtEnterUsername.Name = "txtEnterUsername";
            this.txtEnterUsername.ReadOnly = true;
            this.txtEnterUsername.Size = new System.Drawing.Size(200, 19);
            this.txtEnterUsername.TabIndex = 23;
            this.txtEnterUsername.Text = "Enter Password";
            // 
            // btnbackground
            // 
            this.btnbackground.BackColor = System.Drawing.Color.White;
            this.btnbackground.Enabled = false;
            this.btnbackground.Location = new System.Drawing.Point(174, 12);
            this.btnbackground.Name = "btnbackground";
            this.btnbackground.Size = new System.Drawing.Size(435, 417);
            this.btnbackground.TabIndex = 1000000;
            this.btnbackground.UseVisualStyleBackColor = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEnterUsername);
            this.Controls.Add(this.txtEnterPassword);
            this.Controls.Add(this.btnCarQuizText);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShowpasswordLogIn);
            this.Controls.Add(this.lblDontHaveAcount);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnbackground);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DoubleBuffered = true;
            this.Name = "LogIn";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.LinkLabel lblDontHaveAcount;
        private System.Windows.Forms.CheckBox btnShowpasswordLogIn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCarQuizText;
        private System.Windows.Forms.TextBox txtEnterPassword;
        private System.Windows.Forms.TextBox txtEnterUsername;
        private System.Windows.Forms.Button btnbackground;
    }
}

