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
    public partial class RadioButtonQuestion : Form
    {
        private Timer questionTimer;
        private int timeRemaining;
        bool timerfinished = false;
        Questions selectedQuestion;
        public RadioButtonQuestion()
        {
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

            if (timeRemaining <= 0)
            {
                questionTimer.Stop();
                MessageBox.Show("Time's up!");
                btnCheckAnswer_Click(null, null); // Trigger answer check
                timerfinished = true;
            }
        }

        private void RadioButtonQuestion_Load(object sender, EventArgs e)
        {
            questionTimer = new Timer();
            questionTimer.Interval = 1000; // 1 second
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
            txtScoreBoard.Text = "0";
            thisplayer.Score = 0;
        }
    }
}
