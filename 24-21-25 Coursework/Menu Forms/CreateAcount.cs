using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        bool CreateButtonClick = false;

        bool Rightclicked1 = true;
        bool Rightclicked2 = false;
        bool Rightclicked3 = false;
        bool Rightclicked4 = false;

        bool Avatar1 = false;
        bool Avatar2 = false;
        bool Avatar3 = false;
        bool Avatar4 = false;
        public CreateAcount()
        {
            InitializeComponent();
            players = readFileToList();
           
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

               

            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message); 
            }

            
        }



       
        private void btnCreateAcount_Click(object sender, EventArgs e)
        {

            
            CreateButtonClick = true;
            if (txtPassword2.Text == "admin" && UsernameValid == true)
            {
                btnCreateAcount.Enabled = true;
                CreateAccountAsBin();
            }
            if (PasswordValid == true && UsernameValid == true && txtPassword2.Text == txtConfirmPassword.Text)
            {
                btnCreateAcount.Enabled = true;
                
                SetAvatar();
                CreateAccountAsBin();
                List<Player> players = readFileToList();
                foreach (Player player in players)
                {
                  this.Hide();
                  Form Login = new Menu(thisPlayer);
                  Login.ShowDialog();
                  this.Close();
                }
            }
            
        }
     

        private void txtUsername2_TextChanged(object sender, EventArgs e)
        {
            
            string Username = txtUsername2.Text.Trim().ToLower();
            UsernameValid = UsernameValidation(Username);


            if (txtPassword2.Text == "admin" && UsernameValid == true)
            {
                btnCreateAcount.Enabled = true;
                
            }
            else if (PasswordValid == true && UsernameValid == true && txtPassword2.Text == txtConfirmPassword.Text)
            {
                btnCreateAcount.Enabled = true;
            }
            else
                btnCreateAcount.Enabled = false;
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
            if (txtPassword2.Text == "admin" && UsernameValid == true)
            {
                btnCreateAcount.Enabled = true;

            }
            else if (PasswordValid == true && UsernameValid == true && txtPassword2.Text == txtConfirmPassword.Text)
            {
                btnCreateAcount.Enabled = true;
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
            
            if(Length == true)
            {
                lblPasswordLength.Visible = false;
                
            }
            if(CountainsUpper == true && ContainsNumber == true && ContainsSpecChar == true)
            {
                lblCharecter.Visible = false;
                
            }
            if(CountainsUpper == false || ContainsNumber == false || ContainsSpecChar == false || Length == false)
                return false;
            else if (CountainsUpper == true || ContainsNumber == true || ContainsSpecChar == true || Length == true)
                return true;

            return false;
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
            if (Username == "")
            {
                txtUsername2Verify.ForeColor = Color.Red;
                txtUsername2Verify.Text = "Username too short";
                return false;
            }
            if (UsernameInUse == false)
            {
                txtUsername2Verify.ForeColor = Color.Red;
                txtUsername2Verify.Text = "Username already in use";
                return false;
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
            if(txtConfirmPassword.Text == txtPassword2.Text )
            {
                lblPasswordSame.Visible = false;
            }
            txtPassword2.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            if (btnShowpassword.Checked)
            {
                btnShowpassword.Checked = false;
            }

            if (txtPassword2.Text == "admin" && UsernameValid == true)
            {
                btnCreateAcount.Enabled = true;

            }
            else if (PasswordValid == true && UsernameValid == true && txtPassword2.Text == txtConfirmPassword.Text)
            {
                btnCreateAcount.Enabled = true;
            }
            else
                btnCreateAcount.Enabled = false;
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
                    MessageBox.Show("Please Ensure password and username are valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

      
        
        private void CreateAcount_Load(object sender, EventArgs e)
        {
            // Get the current screen resolution
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Resize the form to a percentage of the screen size
            this.Width = (int)(screenBounds.Width * 0.57);
            this.Height = (int)(screenBounds.Height * 0.54);

            PicBoxAvatar1.Visible = true;
            PicBoxAvatar2.Visible = false;
            PicBoxAvatar3.Visible = false;
            PicBoxAvatar4.Visible = false;
            ResetStats();
            btnLamboTest1Acceleration.Visible = true;
            btnLamboTest1Control.Visible = true;
            btnLamboTest1Speed.Visible = true;
            thisPlayer.Avatar = PicBoxAvatar1.Image;
        }
     
       private void SetAvatar()
        {
            
            if (Avatar1)
            {
                thisPlayer.Avatar = PicBoxAvatar1.Image;


            }
            else if (Avatar2)
            {
                thisPlayer.Avatar = PicBoxAvatar2.Image;


            }
            else if (Avatar3)

            {
                thisPlayer.Avatar = PicBoxAvatar3.Image;


            }
            else if (Avatar4)

            {
                thisPlayer.Avatar = PicBoxAvatar4.Image;

            }
            
        }
        
        
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnRightCar_Click(object sender, EventArgs e)
        {
            do
            {

                if (Rightclicked1)
                {
                    ResetStats();
                    PicBoxAvatar4.Visible = false;
                    PicBoxAvatar1.Visible = true;
                   
                    Rightclicked2 = true;
                    Rightclicked1 = false;

                    Avatar1 = true;
                    Avatar2 = false;
                    Avatar3 = false;
                    Avatar4 = false;
                    txtCarName.Text = "Lamborghini Aventador";
                    btnLamboTest1Acceleration.Visible = true;
                    btnLamboTest1Control.Visible = true;
                    btnLamboTest1Speed.Visible = true;
                    return;
                    
                }
                if (Rightclicked2)
                {
                    ResetStats();
                    Rightclicked2 = false;
                    PicBoxAvatar1.Visible = false;
                    PicBoxAvatar2.Visible = true;
                  
                    Rightclicked3 = true;

                    Avatar1 = false;
                    Avatar2 = true;
                    Avatar3 = false;   
                    Avatar4 = false;
                    txtCarName.Text = "   BMW M5";
                    btnBMWAcceleration.Visible = true;  
                    btnBMWControl.Visible = true;   
                    btnBMWTopSpeed.Visible = true;
                    return;
                    
                }
                if (Rightclicked3)
                {
                    ResetStats();
                    PicBoxAvatar2.Visible = false;
                    PicBoxAvatar3.Visible = true;
                
                    Rightclicked4 = true;
                    Rightclicked3 = false;

                    Avatar3 = true;
                    Avatar1 = false;
                    Avatar2 = false;
                    Avatar4 = false;
                    txtCarName.Text = "    Nissan GTR";
                    btnGTRAcceleration.Visible = true;
                    btnGTRControl.Visible = true;
                    btnGTRSpeed.Visible = true;
                    return;
                    
                 }
                if (Rightclicked4)
                {
                    ResetStats();
                    PicBoxAvatar3.Visible = false;
                    PicBoxAvatar4.Visible = true;
                 
                    Rightclicked1 = true;
                    Rightclicked4 = false;

                    Avatar4 = true;
                    Avatar1 = false;
                    Avatar2 = false;
                    Avatar3 = false;
                    txtCarName.Text = "    Audi R8";
                    btnAudiAcceleration.Visible = true;
                    btnAudioTopSpeed.Visible = true;    
                    btnAudiControl.Visible = true;
                    return;
                   
                }
            }
            while (CreateButtonClick);   
        }
        public void ResetStats()
        {
            btnAudiAcceleration.Visible = false;
            btnAudioTopSpeed.Visible = false;
            btnAudiControl.Visible = false;

            btnBMWAcceleration.Visible = false;
            btnBMWControl.Visible = false;
            btnBMWTopSpeed.Visible = false;

            btnLamboTest1Acceleration.Visible = false;
            btnLamboTest1Control.Visible = false;
            btnLamboTest1Speed.Visible = false;

            btnGTRAcceleration.Visible = false;
            btnGTRControl.Visible = false;
            btnGTRSpeed.Visible = false;
        }

        private void btnLeftCar_Click(object sender, EventArgs e)
        {
            do
            {
                if (Rightclicked1)  // Moving backward from Avatar1
                {
                    ResetStats();
                    PicBoxAvatar1.Visible = false;
                    PicBoxAvatar4.Visible = true;
                    Rightclicked4 = true;
                    Rightclicked1 = false;

                    Avatar1 = false;
                    Avatar2 = false;
                    Avatar3 = false;
                    Avatar4 = true;
                    txtCarName.Text = "    Audi R8";
                    btnAudiAcceleration.Visible = true;
                    btnAudioTopSpeed.Visible = true;
                    btnAudiControl.Visible = true;
                    return;
                    
                }
                if (Rightclicked2)  // Moving backward from Avatar2
                {
                    ResetStats();
                    PicBoxAvatar2.Visible = false;
                    PicBoxAvatar1.Visible = true;
                    Rightclicked1 = true;
                    Rightclicked2 = false;

                    Avatar2 = false;
                    Avatar1 = true;
                    Avatar3 = false;
                    Avatar4 = false;
                    txtCarName.Text = "Lamborghini Aventador";
                    btnLamboTest1Acceleration.Visible = true;
                    btnLamboTest1Control.Visible = true;
                    btnLamboTest1Speed.Visible = true;
                    return;
                    
                }
                if (Rightclicked3)  // Moving backward from Avatar3
                {
                    ResetStats();
                    PicBoxAvatar3.Visible = false;
                    PicBoxAvatar2.Visible = true;
                    Rightclicked2 = true;
                    Rightclicked3 = false;

                    Avatar3 = false;
                    Avatar2 = true;
                    Avatar1 = false;
                    Avatar4 = false;
                    txtCarName.Text = "    BMW M5";
                    btnBMWAcceleration.Visible = true;
                    btnBMWControl.Visible = true;
                    btnBMWTopSpeed.Visible = true;
                    return;
                    
                }
                if (Rightclicked4)  // Moving backward from Avatar4
                {
                    ResetStats();
                    PicBoxAvatar4.Visible = false;
                    PicBoxAvatar3.Visible = true;
                    Rightclicked3 = true;
                    Rightclicked4 = false;

                    Avatar4 = false;
                    Avatar3 = true;
                    Avatar1 = false;
                    Avatar2 = false;
                    txtCarName.Text = "    Nissan GTR";
                    btnGTRAcceleration.Visible = true;
                    btnGTRControl.Visible = true;
                    btnGTRSpeed.Visible = true;
                    return;
                    
                }
            }
            while (CreateButtonClick);
        }

       
    }
}
