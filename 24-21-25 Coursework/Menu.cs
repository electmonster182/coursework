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
using WMPLib;

namespace _24_21_25_Coursework
{
   
    public partial class  Menu : Form
    {

        Player thisplayer;

        public Menu(Player player)
        {
            InitializeComponent();
            thisplayer = player;
        }

        private void btnAdminSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new AdminCreateQuestion(thisplayer);
            form.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form form = new LogIn();
                form.ShowDialog();
                this.Close();
            }
        }

        private void btnEasyQuiz_Click(object sender, EventArgs e)
        {
            if (thisplayer.Progression == 0)
            {
                this.Hide();
                Form form = new Drag_Drop(thisplayer);
                form.ShowDialog();
                this.Close();
            }
            else 
            {
                DialogResult result = MessageBox.Show("Would you like to continue where you left off", "Quick Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (thisplayer.Progression == 1)
                    {
                        this.Hide();
                        Form form = new Random_Question(thisplayer);
                        form.ShowDialog();
                        this.Close();
                    }
                    else if (thisplayer.Progression == 2)
                    {
                        this.Hide();
                        Form form = new RadioButtonQuestion(thisplayer);
                        form.ShowDialog();
                        this.Close();
                    }
                    else if (thisplayer.Progression == 3)
                    {
                        this.Hide();
                        Form form = new ComboBoxQuestion(thisplayer);
                        form.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                        Form form = new Drag_Drop(thisplayer);
                        form.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    thisplayer.Score = 0;
                    FileManager.UpdateScore(thisplayer);
                    thisplayer.Progression = 0;
                    FileManager.UpdateProgresion(thisplayer);
                    this.Hide();
                    Form form = new Drag_Drop(thisplayer);
                    form.ShowDialog();
                    this.Close();
                }
            }
                        
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Settings(thisplayer);
            form.ShowDialog();
            this.Close();
        }

        private void btnRandomQuestion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new RadioButtonQuestion(thisplayer);
            form.ShowDialog();
            this.Close();
        }

        private void EnsureAdminUser()
        {
            List<Player> players = FileManager.ReadPlayersToList();
            
            bool adminExists = players.Any(player =>  player.SuperAdmin);

           
            if (!adminExists)
            {
                Player admin = new Player
                {
                   SuperAdmin = true
                };
                players.Add(admin);

                
                FileManager.WritePlayersFile(players);
            }
        }

        private void Question_Template_Load(object sender, EventArgs e)
        {
            EnsureAdminUser();
            txtUsername.Text = thisplayer.Username;           
            PicBoxAvatar.Image = thisplayer.Avatar;
            txtHighScore.Text = thisplayer.HighScore.ToString();

            if (!File.Exists("Players.bin"))
            FileManager.CreateQuestionFile();
            //QuestionCheck();
            btnAdminSettings.Visible = false;
            if(thisplayer.Admin || thisplayer.SuperAdmin == true)
            {
                btnAdminSettings.Visible = true;
            }

            if(thisplayer.StopMessage == false)
            {
                if (thisplayer.FirstLog == false)
                {
                    thisplayer.FirstLog = true;
                    UpdateLog(thisplayer);
                    MessageBox.Show("Welcome to the Car Quiz! Choose between two modes: Easy Quiz or Hard Quiz. If you want to update your username or password, go to Settings and make the changes there. Enjoy and have fun! ", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (thisplayer.FirstLog == true)
                {
                    MessageBox.Show("Welcome back", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                thisplayer.StopMessage = true;
            }
            if(thisplayer.Progression == 0)
            {
                thisplayer.Score = 0;
                
            }
            

          

        }
        public static void UpdateLog(Player thisPlayer) //updates a users high score attribute and writes it to the players.bin file
        {
            List<Player> players = new List<Player>();
            players.AddRange(FileManager.ReadPlayersToList());
            
                foreach (Player player in players)
                {
                    if (player.Username == thisPlayer.Username)
                    {
                        player.FirstLog = thisPlayer.FirstLog;
                        FileManager.WritePlayersFile(players);
                    }
                }            
        }

        private void btnLeaderBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new LeaderBoard(thisplayer);
            form.ShowDialog();
            this.Close();
        }
        //public void QuestionCheck()
        //{
        //    FileManager.CreateQuestionFile();
        //    List<Questions> questions = FileManager.ReadQuestionsToList();
        //    if (questions.Count == 0)
        //    {
        //        Questions thisQuestion = new Questions();
        //        List<Questions> AllQuestions = new List<Questions>();

        //        thisQuestion.Question = "What company created the aventador";
        //        thisQuestion.Anwser = "Lamborghini";
        //        thisQuestion.QuestionUsed = false;

        //        AllQuestions = FileManager.ReadQuestionsToList();

        //        try
        //        {
        //            AllQuestions.Add(thisQuestion);

        //            Stream sw = File.OpenWrite("Questions.bin");
        //            BinaryFormatter bf = new BinaryFormatter();
        //            bf.Serialize(sw, AllQuestions);
        //            sw.Close();

        //            MessageBox.Show("Question created successfully.");


                    
        //        }
        //        catch 
        //        {

        //        }
                
                
        //    }

        //}

    }
}
