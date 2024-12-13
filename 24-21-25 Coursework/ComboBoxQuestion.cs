using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_21_25_Coursework
{
    public partial class ComboBoxQuestion : Form
    {
        Player thisplayer;
        private Timer questionTimer;
        private int timeRemaining;
        bool timerfinished = false;
        public ComboBoxQuestion(Player player)
        {
            thisplayer = player;
            InitializeComponent();
        }
        private void StartNewQuestion()
        {
            timeRemaining = 30; // Start countdown from 30 seconds
            questionTimer.Start();
        }
        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;

            // Update the timer display (optional text box or label)
            txtTimer.Text = timeRemaining.ToString();

            if (timeRemaining < 5)
                txtTimer.ForeColor = Color.Red;

            if (timeRemaining <= 0)
            {
                questionTimer.Stop();
                MessageBox.Show("Time's up!");
                btnCheckAnswer_Click(null, null); // Trigger answer check
                timerfinished = true;
            }
        }
        private void ComboBoxQuestion_Load(object sender, EventArgs e)
        {
            questionTimer = new Timer();
            questionTimer.Interval = 1000; // 1 second
            questionTimer.Tick += QuestionTimer_Tick;
            if (timerfinished == false)
                StartNewQuestion();
            txtHelp.Visible = false;
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
            Wrong1.Visible = false;
            Wrong2.Visible = false;
            Wrong3.Visible = false;
            Correct1.Visible = false; 
            Correct2.Visible = false;
            Correct3.Visible = false;

            //Updating quick resume
            thisplayer.Progression = 3;
            FileManager.UpdateProgresion(thisplayer);


            // Get the current screen resolution
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Resize the form to a percentage of the screen size
            this.Width = (int)(screenBounds.Width * 0.57);
            this.Height = (int)(screenBounds.Height * 0.54);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            questionTimer.Stop();

            DialogResult result = MessageBox.Show("Are you sure you want to go to home page?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                AnswerCheck();
                this.Hide();
                Form Login = new Menu(thisplayer);
                Login.ShowDialog();
                this.Close();
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
        private int CalculateTimeBonus(int timeLeft)
        {
            if (timeLeft > 20) return 5;
            if (timeLeft > 10) return 3;
            if (timeLeft > 0) return 1;
            return 0;
        }
        private void AnswerCheck()
        {
            CoBox1.Enabled = false;
            CoBox2.Enabled = false;
            CoBox3.Enabled = false;
            questionTimer.Stop();
            int timeBonus = CalculateTimeBonus(timeRemaining);
            btnFinish.Enabled = true;
            btnCheckAnswer.Enabled = false;
                if (CoBox1.Text == "300 MPH")
                {
                    thisplayer.Score = thisplayer.Score + 1 + timeBonus;
                    Correct1.Visible = true;
                }
                else
                {
                    Wrong1.Visible = true;
                   
                }
                if (CoBox2.Text == "v8")
                {
                    Correct2.Visible = true;    
                    thisplayer.Score = thisplayer.Score + 1 + timeBonus;
                }
                else
                {
                    Wrong2.Visible = true;
                    
                }
                if(CoBox3.Text == "Answer2")
                {
                    thisplayer.Score = thisplayer.Score + 1 + timeBonus;
                    Correct3.Visible = true;
                }
                else
                {
                    Wrong3.Visible = true;

                }
                 
               txtScoreBoard.Text = thisplayer.Score.ToString();
                FileManager.UpdateScore(thisplayer);
                FileManager.UpdateHighScore(thisplayer);
                   
        }
        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            AnswerCheck();

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Login = new LeaderBoard(thisplayer);
            Login.ShowDialog();
            this.Close();
        }

        private void picBackGround_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
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
            txtHelp.Visible = false;
            txtHighScore.Visible = true;
            txtHighScoreText.Visible = true;
            txtScoreBoard.Visible = true;
            your_score.Visible = true;
            PicBoxAvatar.Visible = true;
            txtUsername.Visible = true;
            txtUsernameText.Visible = true;
            txtTimer.Visible = true;
        }
    }
}
