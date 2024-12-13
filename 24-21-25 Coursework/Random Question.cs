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
    public partial class Random_Question : Form
    {
        List<Questions> questions = new List<Questions>();
        Questions thisQuestion;
        Player thisplayer;
        private Timer questionTimer;
        private int timeRemaining;
        bool timerfinished = false;
        public Random_Question(Player player)
        {
            InitializeComponent();

            thisplayer = player;
            txtQuestion.Enabled = false;
        }
        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;


            txtTimer.Text = timeRemaining.ToString();
            if (timeRemaining <= 5)
                txtTimer.ForeColor = Color.Red;

            if (timeRemaining <= 0)
            {
                questionTimer.Stop();
                MessageBox.Show("Time's up!");
                btnCheckAnswer_Click(null, null);
                timerfinished = true;
                answerCheck();
            }
        }
        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {

        }
        private void StartNewQuestion()
        {
            timeRemaining = 30;
            questionTimer.Start();
        }

        private void Random_Question_Load(object sender, EventArgs e)
        {
            Correct.Visible = false;
            Wrong.Visible = false;
            questionTimer = new Timer();
            questionTimer.Interval = 1000;
            questionTimer.Tick += QuestionTimer_Tick;
            if (timerfinished == false)
                StartNewQuestion();
            ChooseRandomQuestion();
            txtHelp.Visible = false;
            txtHighScore.Visible = true;
            txtHighScoreText.Visible = true;
            txtScoreBoard.Visible = true;
            your_score.Visible = true;
            PicBoxAvatar.Visible = true;
            txtUsername.Visible = true;
            txtUsernameText.Visible = true;
            txtTimer.Visible = true;
            txtUsername.Text = thisplayer.Username;
            txtScoreBoard.Text = thisplayer.Score.ToString();
            PicBoxAvatar.Image = thisplayer.Avatar;
            txtHighScore.Text = thisplayer.HighScore.ToString();


            //Updating quick resume
            thisplayer.Progression = 1;
            FileManager.UpdateProgresion(thisplayer);
            btnNext.Enabled = false;


            // Get the current screen resolution
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Resize the form to a percentage of the screen size
            this.Width = (int)(screenBounds.Width * 0.57);
            this.Height = (int)(screenBounds.Height * 0.54);
        }

        Questions selectedQuestion;
        public void ChooseRandomQuestion()
        {

            List<Questions> questions = FileManager.ReadQuestionsToList();


            var unusedQuestions = questions.Where(q => !q.QuestionUsed).ToList();


            if (unusedQuestions.Count == 0)
            {
                MessageBox.Show("All questions have been used. Resetting them.");
                ResetQuestionsToUnused(questions);


                unusedQuestions = questions.Where(q => !q.QuestionUsed).ToList();
            }


            Random random = new Random();
            int randomIndex = random.Next(0, unusedQuestions.Count);
            selectedQuestion = unusedQuestions[randomIndex];


            txtQuestion.Text = selectedQuestion.Question;


            selectedQuestion.QuestionUsed = true;


            SaveQuestions(questions);
        }
        public void ResetQuestionsToUnused(List<Questions> questions)
        {
            foreach (var question in questions)
            {
                question.QuestionUsed = false;
            }


            SaveQuestions(questions);
        }
        private void SaveQuestions(List<Questions> questions)
        {
            try
            {

                using (Stream sw = File.OpenWrite("Questions.bin"))
                {

                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(sw, questions);
                }

                Console.WriteLine("Questions have been saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving questions: {ex.Message}");
            }
        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to go to home page?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                questionTimer.Stop();
                this.Hide();
                Form Login = new Menu(thisplayer);
                Login.ShowDialog();
                this.Close();
            }
        }

        private int CalculateTimeBonus(int timeLeft)
        {
            if (timeLeft > 20) return 5;
            if (timeLeft > 10) return 3;
            if (timeLeft > 0) return 1;
            return 0;
        }
        private void answerCheck()
        {
            string userAnswer = txtAwser.Text.Trim().ToLower();
            questionTimer.Stop();

            int timeBonus = CalculateTimeBonus(timeRemaining);


            if (userAnswer == selectedQuestion.Anwser.Trim().ToLower())
            {
                Correct.Visible = true;
                thisplayer.Score = thisplayer.Score + 1 + timeBonus;
                txtScoreBoard.Text = thisplayer.Score.ToString();
                FileManager.UpdateHighScore(thisplayer);
                FileManager.UpdateScore(thisplayer);
                txtHighScore.Text = thisplayer.HighScore.ToString();
            }
            else
                Wrong.Visible = true;

            txtAwser.Enabled = false;
            FileManager.UpdateScore(thisplayer);

            btnNext.Enabled = true;

            btnCheckAnswer.Enabled = false;
            thisplayer.Progression = 2;
            FileManager.UpdateProgresion(thisplayer);
        }
        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            answerCheck();
        }


        private void HelpReset()
        {
            txtHelp.Visible = false;
            txtHighScore.Visible = true;
            txtHighScoreText.Visible = true;
            txtScoreBoard.Visible = true;
            your_score.Visible = true;
            PicBoxAvatar.Visible = true;
            txtUsername.Visible = true;
            txtUsernameText.Visible = true;
        }


        private void pictureBox1_MouseHover_1(object sender, EventArgs e)
        {
            txtHelp.Visible = true;
            txtHighScore.Visible = false;
            txtHighScoreText.Visible = false;
            txtScoreBoard.Visible = false;
            your_score.Visible = false;
            PicBoxAvatar.Visible = false;
            txtUsername.Visible = false;
            txtUsernameText.Visible = false;
            txtTimer.Visible = false;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            HelpReset();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Random_Question(thisplayer);
            Home.ShowDialog();
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new RadioButtonQuestion(thisplayer);
            Home.ShowDialog();
            this.Close();
        }

        private void picBackGround_Click(object sender, EventArgs e)
        {

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
