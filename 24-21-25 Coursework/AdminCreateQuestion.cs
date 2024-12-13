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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace _24_21_25_Coursework
{  

    public partial class AdminCreateQuestion : Form
    {

        bool UserFound = false;
        bool PasswordValid = false;
        bool UsernameValid = false;
        int amount;
        int user;
        int QuestionCount = 0;
        Player thisPlayer;
        Questions thisQuestion = new Questions();
        List<Questions> AllQuestions = new List<Questions>();
        List<Player> players = FileManager.ReadPlayersToList();
        private List<Player> filteredPlayers = new List<Player>();
        List<Questions> question = FileManager.ReadQuestionsToList();
        public AdminCreateQuestion(Player player)
        {
            thisPlayer = player;
            InitializeComponent();
        }

        private void btnCreateQuestion_Click(object sender, EventArgs e)
        {
            thisQuestion.Question = txtQuestion.Text;
            thisQuestion.Anwser = txtAnwser.Text;

            
            if (CheckFilledIn())
            {
                List<Questions> question = FileManager.ReadQuestionsToList();
                QuestionCount = question.Count - 1;
                thisQuestion.QuestionUsed = false;

                AllQuestions = ReadQuestionsToList();

                try
                {
                    AllQuestions.Add(thisQuestion);

                    Stream sw = File.OpenWrite("Questions.bin");
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(sw, AllQuestions);
                    sw.Close();

                    MessageBox.Show("Question created successfully.");

                  
                    txtQuestion.Text = "";
                    txtAnwser.Text = "";
                }
                catch (SerializationException ex)
                {
                    
                }
                catch (IOException ex)
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Please fill in both the question and answer fields.");
            }
        }

        private void EnsureQuestionFileExists()
        {
            string filePath = "Questions.bin";

            if (!File.Exists(filePath))
            {
                try
                {
                   
                    List<Questions> emptyQuestionsList = new List<Questions>();
                    using (Stream sw = File.Open(filePath, FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(sw, emptyQuestionsList);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating questions file: {ex.Message}", "File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckFilledIn()
        {
            return !(string.IsNullOrWhiteSpace(txtQuestion.Text) || string.IsNullOrWhiteSpace(txtAnwser.Text));
        }

        public List<Questions> ReadQuestionsToList()
        {
            List<Questions> allQuestions = new List<Questions>();

            try
            {
                using (Stream sr = File.OpenRead("Questions.bin"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    allQuestions = (List<Questions>)bf.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading questions from file: {ex.Message}");
            }

            return allQuestions;
        }

        private void AdminCreateQuestion_Load(object sender, EventArgs e)
        {
           

            EnsureQuestionFileExists();

            txtConfirmPasswordDisplay.Visible = false;
            txtConfirmPassword.Visible = false;
            txtPassword2.Visible = false;
            txtPassword2Verify.Visible = false;
            txtPasswordDisplay2.Visible = false;
            txtUsername2.Visible = false;
            txtUsername2Verify.Visible = false;
            txtWriteUsername2.Visible = false;
            btnChangeUsername.Visible = false;
            btnChangepassword.Visible = false;
            btnShowpassword.Visible = false;
            txtOldUser.Visible = false;
            txtOldUserText.Visible = false;
            textBox4.Visible = false;
            txtDeleteUserPassword.Visible = false;
            TxtDeleteUser.Visible = false;
            btnDelete.Visible = false;
            btnLeftUser.Visible = false;
            btnRightUser.Visible = false;
            ChBoxAdmin.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            txtDeleteanswer.Visible = false;
            txtDeleteQuestion.Visible = false;
            btnLeftQuestion.Visible = false;
            btnRightQuestion.Visible = false;
            btnDeleteQuestion.Visible = false;


            List<Player> players = FileManager.ReadPlayersToList();
            players = FileManager.ReadPlayersToList();
            players = FileManager.ReadPlayersToList();


            // Filter out SuperAdmin users
            filteredPlayers = players.Where(player => player.SuperAdmin == false).ToList();

            amount = filteredPlayers.Count - 1;
            
            if (filteredPlayers[amount].Admin == true)
            {
                ChBoxAdmin.Checked = true;
            }
            else
                ChBoxAdmin.Checked = false;

            List<Questions> question = FileManager.ReadQuestionsToList();
            QuestionCount = question.Count - 1;
            UserCheck();

        }
     
        public void UserCheck()
        {

            List<Questions> question = FileManager.ReadQuestionsToList();
            if (filteredPlayers.Count == 0)
            {
                btnLeftUser.Enabled = false;
                btnRightUser.Enabled = false;
                TxtDeleteUser.ForeColor = Color.Red;
                TxtDeleteUser.Text = "No Users To Delete";
                btnDelete.Enabled = false;
            }
            else
            {
                TxtDeleteUser.Text = filteredPlayers[amount].Username;
                txtDeleteUserPassword.Text = filteredPlayers[amount].Password;
            }

            if ( question.Count == 0)
            {
                btnLeftQuestion.Enabled = false;
                btnRightQuestion.Enabled = false;
                txtDeleteQuestion.ForeColor = Color.Red;
                txtDeleteQuestion.Text = "No Questions To Delete";
                btnDeleteQuestion.Enabled = false;
            }
            else
            {
                txtDeleteQuestion.Text = question[QuestionCount].Question;
                txtDeleteanswer.Text = question[QuestionCount].Anwser;
            }

        }
        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Menu(thisPlayer);
            form.ShowDialog();
            this.Close();
        }

        private void btnCreateShow_Click(object sender, EventArgs e)
        {
            //Showing
            txtAnwser.Visible = true;
            txtQuestion.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            btnCreateQuestion.Visible = true;

            //Hiding 
            txtConfirmPasswordDisplay.Visible = false;
            txtConfirmPassword.Visible = false;
            txtPassword2.Visible = false;
            txtPassword2Verify.Visible = false; 
            txtPasswordDisplay2.Visible = false;
            txtUsername2.Visible = false;
            txtUsername2Verify.Visible = false;
            txtWriteUsername2.Visible = false;
            btnChangeUsername.Visible = false;
            btnChangepassword.Visible = false;
            btnShowpassword.Visible = false;
            txtOldUser.Visible = false;
            txtOldUserText.Visible = false;
            //Hiding 
            textBox4.Visible = false;
            txtDeleteUserPassword.Visible = false;
            TxtDeleteUser.Visible = false;
            btnDelete.Visible = false;
            btnLeftUser.Visible = false;
            btnRightUser.Visible = false;

            textBox7.Visible = false;
            textBox8.Visible = false;
            txtDeleteanswer.Visible = false;
            txtDeleteQuestion.Visible = false;
            btnLeftQuestion.Visible = false;
            btnRightQuestion.Visible = false;
            btnDeleteQuestion.Visible = false;

            //Resetting text
            txtOldUser.Text = string.Empty;                    
            txtConfirmPassword.Text = string.Empty;
            txtPassword2.Text = string.Empty;
            txtPassword2Verify.Text = string.Empty;
            txtUsername2.Text = string.Empty;
            txtUsername2Verify.Text = string.Empty;
            
        }

        private void btnChangeDetails_Click(object sender, EventArgs e)
        {
            txtAnwser.Visible = false;
            txtQuestion.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            btnCreateQuestion.Visible = false;

            txtConfirmPasswordDisplay.Visible = true;
            txtConfirmPassword.Visible = true;
            txtPassword2.Visible = true;
            txtPassword2Verify.Visible = true;
            txtPasswordDisplay2.Visible = true;
            txtUsername2.Visible = true;
            txtUsername2Verify.Visible = true;
            txtWriteUsername2.Visible = true;
            btnChangeUsername.Visible = true;
            btnChangepassword.Visible = true;
            btnShowpassword.Visible = true;
            txtOldUser.Visible = true;
            txtOldUserText.Visible = true;
            
            textBox4.Visible = false;
            txtDeleteUserPassword.Visible = false;
            TxtDeleteUser.Visible = false;
            btnDelete.Visible = false;
            btnLeftUser.Visible = false;
            btnRightUser.Visible = false;
            ChBoxAdmin.Visible = false;

            textBox7.Visible = false;
            textBox8.Visible = false;
            txtDeleteanswer.Visible = false;
            txtDeleteQuestion.Visible = false;
            btnLeftQuestion.Visible = false;
            btnRightQuestion.Visible = false;
            btnDeleteQuestion.Visible = false;

            txtConfirmPassword.Text = string.Empty;
            txtPassword2.Text = string.Empty;
            txtPassword2Verify.Text = string.Empty;
            txtUsername2.Text = string.Empty;
            txtUsername2Verify.Text = string.Empty;   
            txtOldUser.Text = string.Empty;
            
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
            if(UserFound == false)
            {
                MessageBox.Show("User Not Found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordValid = false;
            }
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


        private void txtUsername2_TextChanged_1(object sender, EventArgs e)
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
        
        private void ChangeUsername()
        {
            string oldUsername = txtOldUser.Text.ToLower().Trim();

            List<Player> players = FileManager.ReadPlayersToList();

            int index = players.FindIndex(player => player.Username == oldUsername);

            // Check if the player was found
            if (index != -1)
            {
                UserFound = true;
                players[index].Username = txtUsername2.Text;
            }
            else
                UserFound = false;  


            players.Add(thisPlayer);

            FileManager.WritePlayersFile(players);

        }
        private void ChangePassword()
        {

            List<Player> players = FileManager.ReadPlayersToList(); /*readFileToList();*/

            int index = players.FindIndex(player => player.Username == txtUsername2.Text);

            // Check if the player was found
            if (index != -1)
            {
                players[index].Password = txtPassword2.Text;
            }


            players.Add(thisPlayer);

            FileManager.WritePlayersFile(players);

        }

        private void btnChangeUsername_Click_1(object sender, EventArgs e)
        {
            if (UsernameValid == true)
                ChangeUsername();
            ChangeUsernameValid();
        }

        private void btnChangepassword_Click_1(object sender, EventArgs e)
        {
            if (PasswordValid == true)
                ChangePassword();
            ChangePasswordMessage();
        }

        private void btnShowpassword_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassword2.UseSystemPasswordChar = !btnShowpassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !btnShowpassword.Checked;
        }

        private void txtConfirmPassword_TextChanged_1(object sender, EventArgs e)
        {
            txtPassword2.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword2_TextChanged_1(object sender, EventArgs e)
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

        private void TxtDeleteUser_TextChanged(object sender, EventArgs e)
        {
            
                    
        }

        private void picBackGround_Click(object sender, EventArgs e)
        {

        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete user.", "Delete Player", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {


                if (filteredPlayers.Count != 0)
                {

                    players.RemoveAt(user);


                    FileManager.WritePlayersFile(players);

                    if (user >= players.Count)
                    {
                        user = players.Count - 1;
                    }

                    
                    TxtDeleteUser.Text = filteredPlayers[amount].Username;
                    txtDeleteUserPassword.Text = filteredPlayers[amount].Password;
                    MessageBox.Show("User deleted.", "Delete Player", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
        }
      
        private void btnLeftUser_Click(object sender, EventArgs e)
        {
            
            amount = amount - 1;
            if (amount == -1)
                amount = filteredPlayers.Count - 1;
            else if (amount > filteredPlayers.Count - 1)
                amount = 0;
            UserCheck();
            TxtDeleteUser.Text = filteredPlayers[amount].Username;
            txtDeleteUserPassword.Text = filteredPlayers[amount].Password;

            ChBoxAdmin.Checked = filteredPlayers[amount].Admin;
        }

        private void btnRightUser_Click(object sender, EventArgs e)
        {
            amount = amount + 1;
            if (amount == -1)
                amount = filteredPlayers.Count - 1;
            else if (amount > filteredPlayers.Count - 1)
                amount = 0;
            UserCheck();
            TxtDeleteUser.Text = filteredPlayers[amount].Username;
            txtDeleteUserPassword.Text = filteredPlayers[amount].Password;

           
            ChBoxAdmin.Checked = filteredPlayers[amount].Admin;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            txtDeleteUserPassword.Visible = true;
            TxtDeleteUser.Visible = true;
            btnDelete.Visible = true;
            btnLeftUser.Visible = true;
            btnRightUser.Visible = true;
            ChBoxAdmin.Visible = true;

            txtConfirmPasswordDisplay.Visible = false;
            txtConfirmPassword.Visible = false;
            txtPassword2.Visible = false;
            txtPassword2Verify.Visible = false;
            txtPasswordDisplay2.Visible = false;
            txtUsername2.Visible = false;
            txtUsername2Verify.Visible = false;
            txtWriteUsername2.Visible = false;
            btnChangeUsername.Visible = false;
            btnChangepassword.Visible = false;
            btnShowpassword.Visible = false;
            txtOldUser.Visible = false;
            txtOldUserText.Visible = false;

            textBox7.Visible = false;
            textBox8.Visible = false;
            txtDeleteanswer.Visible = false;
            txtDeleteQuestion.Visible = false;
            btnLeftQuestion.Visible = false;
            btnRightQuestion.Visible = false;
            btnDeleteQuestion.Visible = false;

            txtAnwser.Visible = false;
            txtQuestion.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            btnCreateQuestion.Visible = false;
        }

        private void ChBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            
            if (filteredPlayers != null && amount >= 0 && amount < filteredPlayers.Count)
            {
               
                filteredPlayers[amount].Admin = ChBoxAdmin.Checked;

                
                FileManager.WritePlayersFile(filteredPlayers);
            }

        }

        private void btnRightQuestion_Click(object sender, EventArgs e)
        {
            List<Questions> question = FileManager.ReadQuestionsToList();


            QuestionCount = QuestionCount + 1;
            if (QuestionCount == -1)
                QuestionCount = question.Count - 1;
            else if (QuestionCount > question.Count - 1)
                QuestionCount = 0;
            UserCheck();
            TxtDeleteUser.Text = question[QuestionCount].Question;
            txtDeleteUserPassword.Text = question[QuestionCount].Anwser;


            
        }

        private void btnLeftQuestion_Click(object sender, EventArgs e)
        {
            List<Questions> question = FileManager.ReadQuestionsToList();


            QuestionCount = QuestionCount - 1;
            if (QuestionCount == -1)
                QuestionCount = question.Count - 1;
            else if (QuestionCount > question.Count - 1)
                QuestionCount = 0;
            UserCheck();
            TxtDeleteUser.Text = question[QuestionCount].Question;
            txtDeleteUserPassword.Text = question[QuestionCount].Anwser;
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete Question.", "Delete Player", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {


                if (question.Count != 0)
                {

                    question.RemoveAt(QuestionCount);


                    FileManager.writeQuestionToFile(question);

                    if (QuestionCount >= question.Count)
                    {
                        QuestionCount = question.Count - 1;
                    }


                    txtDeleteQuestion.Text = question[QuestionCount].Question;
                    txtDeleteanswer.Text = question[QuestionCount].Anwser;
                    MessageBox.Show("Question deleted.", "Delete Player", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            textBox7.Visible = true;
            textBox8.Visible = true;
            txtDeleteanswer.Visible = true;
            txtDeleteQuestion.Visible = true;
            btnLeftQuestion.Visible = true;
            btnRightQuestion.Visible = true;
            btnDeleteQuestion.Visible = true;

            txtConfirmPasswordDisplay.Visible = false;
            txtConfirmPassword.Visible = false;
            txtPassword2.Visible = false;
            txtPassword2Verify.Visible = false;
            txtPasswordDisplay2.Visible = false;
            txtUsername2.Visible = false;
            txtUsername2Verify.Visible = false;
            txtWriteUsername2.Visible = false;
            btnChangeUsername.Visible = false;
            btnChangepassword.Visible = false;
            btnShowpassword.Visible = false;
            txtOldUser.Visible = false;
            txtOldUserText.Visible = false;

            txtAnwser.Visible = false;
            txtQuestion.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            btnCreateQuestion.Visible = false;


            textBox4.Visible = false;
            txtDeleteUserPassword.Visible = false;
            TxtDeleteUser.Visible = false;
            btnDelete.Visible = false;
            btnLeftUser.Visible = false;
            btnRightUser.Visible = false;
            ChBoxAdmin.Visible = false;
        }
    }
}
