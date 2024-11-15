
namespace _24_21_25_Coursework
{
    partial class Settings
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnChangeUsername = new System.Windows.Forms.Button();
            this.btnChangepassword = new System.Windows.Forms.Button();
            this.btnShowpassword = new System.Windows.Forms.CheckBox();
            this.txtConfirmPasswordDisplay = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtUsername2Verify = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.txtPasswordDisplay2 = new System.Windows.Forms.TextBox();
            this.txtUsername2 = new System.Windows.Forms.TextBox();
            this.txtWriteUsername2 = new System.Windows.Forms.TextBox();
            this.txtPassword2Verify = new System.Windows.Forms.TextBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 451);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnChangeUsername
            // 
            this.btnChangeUsername.BackColor = System.Drawing.Color.White;
            this.btnChangeUsername.Location = new System.Drawing.Point(171, 366);
            this.btnChangeUsername.Name = "btnChangeUsername";
            this.btnChangeUsername.Size = new System.Drawing.Size(106, 30);
            this.btnChangeUsername.TabIndex = 1;
            this.btnChangeUsername.Text = "Change Username";
            this.btnChangeUsername.UseVisualStyleBackColor = false;
            this.btnChangeUsername.Click += new System.EventHandler(this.btnChangeUsername_Click);
            // 
            // btnChangepassword
            // 
            this.btnChangepassword.BackColor = System.Drawing.Color.White;
            this.btnChangepassword.Location = new System.Drawing.Point(309, 366);
            this.btnChangepassword.Name = "btnChangepassword";
            this.btnChangepassword.Size = new System.Drawing.Size(106, 30);
            this.btnChangepassword.TabIndex = 2;
            this.btnChangepassword.Text = "Change Password";
            this.btnChangepassword.UseVisualStyleBackColor = false;
            this.btnChangepassword.Click += new System.EventHandler(this.btnChangepassword_Click);
            // 
            // btnShowpassword
            // 
            this.btnShowpassword.AutoSize = true;
            this.btnShowpassword.BackColor = System.Drawing.Color.White;
            this.btnShowpassword.Location = new System.Drawing.Point(190, 230);
            this.btnShowpassword.Name = "btnShowpassword";
            this.btnShowpassword.Size = new System.Drawing.Size(102, 17);
            this.btnShowpassword.TabIndex = 19;
            this.btnShowpassword.Text = "Show Password";
            this.btnShowpassword.UseVisualStyleBackColor = false;
            this.btnShowpassword.CheckedChanged += new System.EventHandler(this.btnShowpassword_CheckedChanged);
            // 
            // txtConfirmPasswordDisplay
            // 
            this.txtConfirmPasswordDisplay.BackColor = System.Drawing.Color.White;
            this.txtConfirmPasswordDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPasswordDisplay.Enabled = false;
            this.txtConfirmPasswordDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPasswordDisplay.ForeColor = System.Drawing.Color.Black;
            this.txtConfirmPasswordDisplay.Location = new System.Drawing.Point(190, 170);
            this.txtConfirmPasswordDisplay.Name = "txtConfirmPasswordDisplay";
            this.txtConfirmPasswordDisplay.ReadOnly = true;
            this.txtConfirmPasswordDisplay.Size = new System.Drawing.Size(200, 19);
            this.txtConfirmPasswordDisplay.TabIndex = 24;
            this.txtConfirmPasswordDisplay.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtConfirmPassword.Location = new System.Drawing.Point(190, 204);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 26);
            this.txtConfirmPassword.TabIndex = 18;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // txtUsername2Verify
            // 
            this.txtUsername2Verify.BackColor = System.Drawing.Color.White;
            this.txtUsername2Verify.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername2Verify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername2Verify.ForeColor = System.Drawing.Color.Red;
            this.txtUsername2Verify.Location = new System.Drawing.Point(190, 77);
            this.txtUsername2Verify.Name = "txtUsername2Verify";
            this.txtUsername2Verify.ReadOnly = true;
            this.txtUsername2Verify.Size = new System.Drawing.Size(200, 19);
            this.txtUsername2Verify.TabIndex = 22;
            // 
            // txtPassword2
            // 
            this.txtPassword2.BackColor = System.Drawing.Color.White;
            this.txtPassword2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtPassword2.Location = new System.Drawing.Point(190, 144);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(200, 26);
            this.txtPassword2.TabIndex = 17;
            this.txtPassword2.TextChanged += new System.EventHandler(this.txtPassword2_TextChanged);
            // 
            // txtPasswordDisplay2
            // 
            this.txtPasswordDisplay2.BackColor = System.Drawing.Color.White;
            this.txtPasswordDisplay2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPasswordDisplay2.Enabled = false;
            this.txtPasswordDisplay2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordDisplay2.ForeColor = System.Drawing.Color.Black;
            this.txtPasswordDisplay2.Location = new System.Drawing.Point(190, 119);
            this.txtPasswordDisplay2.Name = "txtPasswordDisplay2";
            this.txtPasswordDisplay2.ReadOnly = true;
            this.txtPasswordDisplay2.Size = new System.Drawing.Size(200, 19);
            this.txtPasswordDisplay2.TabIndex = 21;
            this.txtPasswordDisplay2.Text = "Enter Password";
            // 
            // txtUsername2
            // 
            this.txtUsername2.BackColor = System.Drawing.Color.White;
            this.txtUsername2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtUsername2.Location = new System.Drawing.Point(190, 45);
            this.txtUsername2.Name = "txtUsername2";
            this.txtUsername2.Size = new System.Drawing.Size(200, 26);
            this.txtUsername2.TabIndex = 16;
            this.txtUsername2.TextChanged += new System.EventHandler(this.txtUsername2_TextChanged);
            // 
            // txtWriteUsername2
            // 
            this.txtWriteUsername2.BackColor = System.Drawing.Color.White;
            this.txtWriteUsername2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWriteUsername2.Enabled = false;
            this.txtWriteUsername2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWriteUsername2.ForeColor = System.Drawing.Color.Black;
            this.txtWriteUsername2.Location = new System.Drawing.Point(190, 20);
            this.txtWriteUsername2.Name = "txtWriteUsername2";
            this.txtWriteUsername2.ReadOnly = true;
            this.txtWriteUsername2.Size = new System.Drawing.Size(200, 19);
            this.txtWriteUsername2.TabIndex = 20;
            this.txtWriteUsername2.Text = "Enter Username";
            // 
            // txtPassword2Verify
            // 
            this.txtPassword2Verify.BackColor = System.Drawing.Color.White;
            this.txtPassword2Verify.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword2Verify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword2Verify.ForeColor = System.Drawing.Color.Red;
            this.txtPassword2Verify.Location = new System.Drawing.Point(190, 247);
            this.txtPassword2Verify.Multiline = true;
            this.txtPassword2Verify.Name = "txtPassword2Verify";
            this.txtPassword2Verify.ReadOnly = true;
            this.txtPassword2Verify.Size = new System.Drawing.Size(200, 100);
            this.txtPassword2Verify.TabIndex = 23;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(74, 24);
            this.btnHome.TabIndex = 30;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnShowpassword);
            this.Controls.Add(this.txtConfirmPasswordDisplay);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtUsername2Verify);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.txtPasswordDisplay2);
            this.Controls.Add(this.txtUsername2);
            this.Controls.Add(this.txtWriteUsername2);
            this.Controls.Add(this.txtPassword2Verify);
            this.Controls.Add(this.btnChangepassword);
            this.Controls.Add(this.btnChangeUsername);
            this.Controls.Add(this.button1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnChangeUsername;
        private System.Windows.Forms.Button btnChangepassword;
        private System.Windows.Forms.CheckBox btnShowpassword;
        private System.Windows.Forms.TextBox txtConfirmPasswordDisplay;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtUsername2Verify;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.TextBox txtPasswordDisplay2;
        private System.Windows.Forms.TextBox txtUsername2;
        private System.Windows.Forms.TextBox txtWriteUsername2;
        private System.Windows.Forms.TextBox txtPassword2Verify;
        private System.Windows.Forms.Button btnHome;
    }
}