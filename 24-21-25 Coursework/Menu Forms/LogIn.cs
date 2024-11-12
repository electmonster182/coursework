
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _24_21_25_Coursework
{
    public partial class LogIn : Form
    {
        Player thisPlayer = new Player(); 
        List<Player> players = new List<Player>();
        
        public LogIn()
        { 
            InitializeComponent();
            readFileToList();
            //this.FormBorderStyle = FormBorderStyle.None;
        }




        public List<Player> readFileToList()
        {
            List<Player> players = new List<Player>(); 
            try
            {
               
                using (Stream sr = File.OpenRead("Players.bin")) 
                {
                    
                    BinaryFormatter bf = new BinaryFormatter();

                    players = (List<Player>)bf.Deserialize(sr);  
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error reading from file: " + ex.Message);
            }

           
            return players;
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
            
            ValidateLogin();
            

        }
        private void EnsurePlayersFileExists()
        {
            string filePath = "Players.bin";

          
            if (!File.Exists(filePath))
            {
               
                try
                {
                    List<Player> emptyPlayersList = new List<Player>();
                    using (Stream sw = File.Open(filePath, FileMode.Create))  
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(sw, emptyPlayersList); 
                    }
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show($"Error creating players file: {ex.Message}", "File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidateLogin()
        {
            string enteredUsername = txtUsername.Text.ToLower().Trim(); 
            string enteredPassword = txtPassword.Text;

           
            List<Player> players = readFileToList(); 

     
            foreach (Player player in players)
            {
                if (player.Username == enteredUsername && player.Password == enteredPassword)
                {
                   
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    this.Hide();                    
                    Form Login = new HomePage(player);
                    Login.ShowDialog();  
                    this.Close();  

                    return true;  
                }
            }

           
            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; 
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

        private void LogIn_Load(object sender, EventArgs e)
        {
            

            EnsurePlayersFileExists();
           
            //btnExit.FlatStyle = FlatStyle.Flat;
            //btnExit.BackColor = System.Drawing.Color.Transparent;

            //btnEnterPasswordText.FlatStyle = FlatStyle.Flat;
            //btnEnterPasswordText.BackColor = System.Drawing.Color.Transparent;

            //btnEnterUsernameText.FlatStyle = FlatStyle.Flat;
            //btnEnterUsernameText.BackColor = System.Drawing.Color.Transparent;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtWriteUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
        }
        
        private void txtPassword_Click(object sender, EventArgs e)
        {
            
        }

        private void txtEnterPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
