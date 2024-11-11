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
    [Serializable]
    public partial class CreateAcount : Form
    {
        bool UsernameValid = false;
        bool PasswordValid = false;
        
        Player thisPlayer = new Player();
        List<Player> players = new List<Player>(); 
        public CreateAcount()
        {
            InitializeComponent();
            players = readFileToList();
            this.FormBorderStyle = FormBorderStyle.None;
        }
    

        public List<Player> readFileToList() 
        {
            List<Player> players = new List<Player>();
            Stream sr;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                sr = File.OpenRead("Players.bin");
                players = (List<Player>)bf.Deserialize(sr);
                sr.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

            return players;
        }

        private void CreateAccountAsBin()
        {

            thisPlayer.Username = txtUsername2.Text.ToLower().Trim();
            thisPlayer.Password = txtPassword2.Text;

            
            List<Player> players = readFileToList();  

           
            players.Add(thisPlayer);

            
            Stream sw;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
               
                sw = File.Open("Players.bin", FileMode.Create); 
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

       
       

        private void btnCreateAcount_Click(object sender, EventArgs e)
        {

            
          
            HasAvatar = Avatarselection(); 
            if (PasswordValid == true && UsernameValid == true && txtPassword2.Text == txtConfirmPassword.Text && HasAvatar == true)
            {
                CreateAcountMessage();
                SetAvatar();
                CreateAccountAsBin();               
            }
            else CreateAcountMessage();

        }
     

        private void txtUsername2_TextChanged(object sender, EventArgs e)
        {
            
            string Username = txtUsername2.Text.Trim().ToLower();
            UsernameValid = UsernameValidation(Username);
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



        private bool UsernameValidation(string Username)
            {
            bool small = false;
            bool big = false;
            bool UsernameInUse = true;
            
            List<Player> players = readFileToList(); 

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
            {
                MessageBox.Show("Please ensure passwords are the same", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordValid = false;
            }


            else if (txtUsername2.Text == txtPassword2.Text)
            {
                MessageBox.Show("Username and Password can not be the same.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordValid = false;
            }

            else if (UsernameValid == false && PasswordValid == false || PasswordValid == false || UsernameValid == false)
            {
                if (UsernameValid == false && PasswordValid == false)
                {
                    MessageBox.Show("Please Ensureassword and username are valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PasswordValid = false;
                }
                else if (PasswordValid == false)
                {
                    MessageBox.Show("Insure Password Is Valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PasswordValid = false;
                }
                else if (UsernameValid == false)
                {
                    MessageBox.Show("Insure Username Is Valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PasswordValid = false;
                }

            }
            else if (HasAvatar == false)
            {
                MessageBox.Show("Please choose an avatar.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Account Created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordValid = true;
            }
            PasswordValid = true;


        }

        private void btnReturnToLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new LogIn();
            form.ShowDialog();
            this.Close();
        }

      
        bool HasAvatar = false;
        private void CreateAcount_Load(object sender, EventArgs e)
        {

            HasAvatar = Avatarselection();           
            PNGborder1.Visible = false;
            PNGborder2.Visible = false;
            PNGborder3.Visible = false;
            PNGborder4.Visible = false;
            PGNborder5.Visible = false;
        }


      

        
       private void SetAvatar()
        {
            if (PNGborder1.Visible)
            {
                thisPlayer.Avatar = PicBoxAvatar1.Image;
               

            }
            else if (PNGborder2.Visible)
            {
                thisPlayer.Avatar = PicBoxAvatar2.Image;
                

            }
            else if (PNGborder3.Visible)

            {
                thisPlayer.Avatar = PicBoxAvatar3.Image;
                

            }
            else if (PNGborder4.Visible)

            {
                thisPlayer.Avatar = PicBoxAvatar4.Image;
               
            }
            else if (PGNborder5.Visible)

            {
                thisPlayer.Avatar = btnImportImage.Image;
               
            }
        }
        private bool Avatarselection()
        {
            if (PNGborder1.Visible)             
            {
                
                return true;
               
            }
            else if (PNGborder2.Visible)               
            {
                
                return true;
               
            }
            else if (PNGborder3.Visible)
               
            {
               
                return true;
               
            }
            else if (PNGborder4.Visible)
               
            {
              
                return true;
            }
            else if (PGNborder5.Visible)
              
            {
               
                return true;
            }
            else
            {
                
                return false;
                
                    
            }
        }
        private void btnImportImage_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileOpen = new OpenFileDialog();
                fileOpen.Title = "Open a PGN image file";
                fileOpen.Filter = "PGN Files (*.PGN)| *.PGN";

                if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                    btnImportImage.Image = Image.FromFile(fileOpen.FileName);
                }
                fileOpen.Dispose();

                if (btnImportImage.Image != null)
                {
                    thisPlayer.Avatar = thisPlayer.Avatar;
                }
                readFileToList();
                foreach (Player player in players)
                {
                    if (player.Username == thisPlayer.Username)
                    {

                        Stream sw;
                        BinaryFormatter bf = new BinaryFormatter();
                        player.Avatar = thisPlayer.Avatar;
                        try
                        {
                            sw = File.OpenWrite("Players.bin");
                            bf.Serialize(sw, players);
                            sw.Close();
                        }
                        catch (SerializationException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        readFileToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            PNGborder1.Visible = false;
            PNGborder2.Visible = false;
            PNGborder3.Visible = false;
            PNGborder4.Visible = false;
            PGNborder5.Visible = true;
        }
        private void readPlayersToList2()
        {
            Stream sr;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                sr = File.OpenRead("Players.bin");
                players = (List<Player>)bf.Deserialize(sr);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PicBoxAvatar1_Click(object sender, EventArgs e)
        {
            
           
            PNGborder1.Visible = true;
            PNGborder2.Visible = false;
            PNGborder3.Visible = false;
            PNGborder4.Visible = false;
            PGNborder5.Visible = false;
        }

        private void PicBoxAvatar2_Click(object sender, EventArgs e)
        {
            PNGborder1.Visible = false;
            PNGborder2.Visible = true;
            PNGborder3.Visible = false;
            PNGborder4.Visible = false;
            PGNborder5.Visible = false;
        }

        private void PicBoxAvatar3_Click(object sender, EventArgs e)
        {
            PNGborder1.Visible = false;
            PNGborder2.Visible = false;
            PNGborder3.Visible = true;
            PNGborder4.Visible = false;
            PGNborder5.Visible = false;
        }

        private void PicBoxAvatar4_Click(object sender, EventArgs e)
        {
            PNGborder1.Visible = false;
            PNGborder2.Visible = false;
            PNGborder3.Visible = false;
            PNGborder4.Visible = true;
            PGNborder5.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
