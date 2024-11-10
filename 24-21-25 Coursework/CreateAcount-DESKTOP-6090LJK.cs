using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_21_25_Coursework
{
    public partial class CreateAcount : Form
    {
        bool UsernameValid = false;
        bool PasswordValid = false;
        
        Player thisPlayer = new Player(); //create an identifier of type Player (doesn't contain anything yet)
        List<Player> players = new List<Player>(); //create an identifier for a list of players
        public CreateAcount()
        {
            InitializeComponent();
            readFileToList();
        }
        private void readFileToList()
        {
            Stream sr;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                sr = File.OpenRead("Players.bin");
                players = (List<Player>)bf.Deserialize(sr);
                sr.Close();
            }
            catch (Exception)
            {

            }
        }

        private void CreateAccountAsBin()
        {          
            thisPlayer.Username = txtUsername2.Text;
            thisPlayer.Password = txtPassword2.Text;
            
            Stream sw;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {

                thisPlayer = new Player(thisPlayer.Username, thisPlayer.Password);
                players.Add(thisPlayer);
                sw = File.OpenWrite("Players.bin");
                bf.Serialize(sw, players);
                sw.Close();
                this.Hide();
                Form form = new LogIn();
                form.ShowDialog();
                this.Close();

            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateAcount_load(object sender, EventArgs e)
        {

        }
        private void ReadFromBinFile()
        {
          
        }
        
        private void btnCreateAcount_Click(object sender, EventArgs e)
        {
            
            
        }
     

        private void txtUsername2_TextChanged(object sender, EventArgs e)
        {
            
            string Username = txtUsername2.Text.Trim().ToLower();
            UsernameValid = UsernameValidation(Username);
        }

        private void txtUsername2Verify_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword2Verify_TextChanged(object sender, EventArgs e)
        {                        
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


        private void txtValidAcountCreate_TextChanged(object sender, EventArgs e)
        {
          

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
                    break; // Exit the loop early if a capital letter is found
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



        private bool UsernameValidation(string Username)
            {
            bool small = false;
            bool big = false;
           //if (IsUsernameInUsetxt() == true)
           // {
           //     txtUsername2Verify.ForeColor = Color.Red;
           //     txtUsername2Verify.Text = ("Username already in use");
           //     return false;
           // }
                
            /*else*/ if (Username.Length < 3)
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

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword2.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            if (btnShowpassword.Checked)
            {
                btnShowpassword.Checked = false;
            }
        }

        private void btnShowpassword_CheckedChanged(object sender, EventArgs e)
        {
                      
            txtPassword2.UseSystemPasswordChar = !btnShowpassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !btnShowpassword.Checked;
        }

        private void CreateAcountMessage()
        {
            if (txtPassword2.Text != txtConfirmPassword.Text)
                MessageBox.Show("Please ensure passwords are the same", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (txtUsername2.Text == txtPassword2.Text)
                    MessageBox.Show("Username and Password can not be the same.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (UsernameValid == false && PasswordValid == false)
                    MessageBox.Show("Please ensure password and username are valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    //Register(txtPassword2.Text, txtUsername2.Text);
                }
            }
        }

        private void btnReturnToLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new LogIn();
            form.ShowDialog();
            this.Close();
        }
    }
}
