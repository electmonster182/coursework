using System;
using System.Windows.Forms;
using System.IO;

namespace _24_21_25_Coursework
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void lblDontHaveAcount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form form = new CreateAcount();
            form.ShowDialog();
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string wordToCheck = txtUsername.Text.ToLower() + ","+txtPassword.Text; // The word to check

            if (IsWordInFile(wordToCheck))
            {
                MessageBox.Show("Log in successful");

                // Navigate to the next form
                this.Hide();
                Form form = new Question1();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password incorrect");
            }
        }
        private bool IsWordInFile(string word)
        {
            string fileName = @"C:\Users\killi\OneDrive - C2k\Desktop\User details\UserDetails.txt";

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    // Check if the line contains the word
                    if (line.IndexOf(word) >= 0) 
                    {
                        return true; // Word found
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("file was not found");
            }

            return false; // Word not found
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            if (btnShowpasswordLogIn.Checked)
            {
                btnShowpasswordLogIn.Checked = false;
            }
        }

        private void btnShowpasswordLogIn_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !btnShowpasswordLogIn.Checked;
            
        }
    }
}
