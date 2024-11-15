using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace _24_21_25_Coursework
{
    public partial class Settings : Form
    {   bool PasswordValid = false;
        bool UsernameValid = false;
        public Player thisPlayer { get; set; }
        public Settings(Player player)
        {
            thisPlayer = player;
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            
        }
        private void ChangePasswordMessage()
        {
            if (txtPassword2.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Please ensure passwords are the same", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if (PasswordValid == false)
            {
                MessageBox.Show("Insure Password Is Valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Password Changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordValid = true;
            }
        }

        private bool UsernameValidation(string Username)
        {
            bool small = false;
            bool big = false;
            bool UsernameInUse = true;

            List<Player> players = FileManager.ReadPlayersToList();

            foreach (Player player in players)
            {
                if (player.Username == Username)
                {

                    UsernameInUse = false;
                }
            }
            if (UsernameInUse == false)
            {
                txtUsername2Verify.ForeColor = Color.Red;
                txtUsername2Verify.Text = "Username already in use";
            }
            else if (Username.Length < 3)
            {
                txtUsername2Verify.ForeColor = Color.Red;
                txtUsername2Verify.Text = "Username too short.";
                small = true;
                return false;
            }
            else if (Username.Length > 20)
            {
                txtUsername2Verify.ForeColor = Color.Red;
                txtUsername2Verify.Text = "Username too long.";
                big = true;
                return false;
            }
            else if (small == false && big == false)
            {
                txtUsername2Verify.ForeColor = Color.Green;
                txtUsername2Verify.Text = "Username valid.";
                return true;
            }
            return false;
        }


        private void ChangeUsernameValid()
        {
            
            if (UsernameValid == false)
            {
                MessageBox.Show("Insure Username Is Valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordValid = false;
            }
            else
            {
                MessageBox.Show("Username Changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordValid = true;
            }
            PasswordValid = true;
        }
       

        private void txtUsername2_TextChanged(object sender, EventArgs e)
        {
            string Username = txtUsername2.Text.Trim().ToLower();
            UsernameValid = UsernameValidation(Username);
        }
        private bool PasswordValidation(String Password)
        {
            bool Length = false;
            bool CountainsUpper = false;
            bool ContainsNumber = false;
            bool ContainsSpecChar = false;

            string specialcharectors = "! # $ % & ' ( ) * + , - . / : ; < = > ? @ [ ] ^ _ { | } ~";
            string numbers = " 1 2 3 4 5 6 7 8 9 0";
            if (Password.Length < 5)
                Length = false;
            else if (Password.Length > 30)
                Length = false;
            else
                Length = true;

            for (int i = 0; i < Password.Length; i++)
            {
                if (char.IsUpper(Password[i]))
                {
                    CountainsUpper = true;
                    break;
                }
            }
            for (int i = 0; i < Password.Length; i++)
            {
                if (specialcharectors.Contains(Password[i]))
                {
                    ContainsSpecChar = true;
                    break;
                }
            }
            for (int i = 0; i < Password.Length; i++)
            {
                if (numbers.Contains(Password[i]))
                {
                    ContainsNumber = true;
                    break;
                }
            }

            if (Length && CountainsUpper && ContainsNumber && ContainsSpecChar)
            {
                txtPassword2Verify.ForeColor = Color.Green;
                txtPassword2Verify.Text = "Password valid.";
                return true;
            }
            else
            {
                txtPassword2Verify.ForeColor = Color.Red;
                txtPassword2Verify.Text = "Password must contain";
                txtPassword2Verify.Text += Length == false ? "  between 5 and 30 characters long" : "";
                txtPassword2Verify.Text += CountainsUpper == false ? ", upper case letter" : "";
                txtPassword2Verify.Text += ContainsNumber == false ? " number" : "";
                txtPassword2Verify.Text += ContainsSpecChar == false ? " special character" : "";
                return false;
            }
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            string Password = txtPassword2.Text;
            PasswordValid = PasswordValidation(Password);

            txtPassword2.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            if (btnShowpassword.Checked)
            {
                btnShowpassword.Checked = false;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword2.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;   
        }

        private void btnShowpassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword2.UseSystemPasswordChar = !btnShowpassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !btnShowpassword.Checked;
        }

        private void btnChangepassword_Click(object sender, EventArgs e)
        {
            if (PasswordValid == true)
                ChangePassword();
            ChangePasswordMessage();
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            if (UsernameValid == true)
                ChangeUsername();
            ChangeUsernameValid();
        }
        private void ChangeUsername()
        {
            string oldUsername = thisPlayer.Username;

            thisPlayer.Username = txtUsername2.Text.ToLower().Trim();
            
            List<Player> players = FileManager.ReadPlayersToList();

            int index = players.FindIndex(player => player.Username == oldUsername);

            // Check if the player was found
            if (index != -1)
            {
                players[index].Username = thisPlayer.Username;
            }


            players.Add(thisPlayer);

            FileManager.WritePlayersFile(players);

        }
            private void ChangePassword()
            {

            List<Player> players = FileManager.ReadPlayersToList(); /*readFileToList();*/ 

            int index = players.FindIndex(player => player.Username == thisPlayer.Username);

            // Check if the player was found
            if (index != -1)
            {
                players[index].Password = txtPassword2.Text;
            }


            players.Add(thisPlayer);

            FileManager.WritePlayersFile(players);
  
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new HomePage(thisPlayer);
            form.ShowDialog();
            this.Close();
        }
        
    }
}
