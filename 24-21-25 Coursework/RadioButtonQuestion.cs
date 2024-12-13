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
        Player thisplayer;
        public RadioButtonQuestion(Player player)
        {
            thisplayer = player;
            InitializeComponent();
        }
        private void StartNewQuestion()
        {
            timeRemaining = 30; 
            questionTimer.Start();
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
                foreach (var radioButton in this.Controls.OfType<RadioButton>()) radioButton.Enabled = false;
                timerfinished = true;
                answerCheck();
            }
        }

        private void RadioButtonQuestion_Load(object sender, EventArgs e)
        {
            FormStart();
            // Get the current screen resolution
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Resize the form to a percentage of the screen size
            this.Width = (int)(screenBounds.Width * 0.57);
            this.Height = (int)(screenBounds.Height * 0.54);
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
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            HelpReset();
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
            bool AllChecked = false;
            int timeBonus = CalculateTimeBonus(timeRemaining);
            FileManager.UpdateScore(thisplayer);
            questionTimer.Stop();
            if (Lamborghini1.Checked != true && Lamborghini2.Checked != true && Lamborghini3.Checked != true)
            {
                MessageBox.Show("You must answer all questions!");
            }
            else if (Ferrari1.Checked != true && Ferrari2.Checked != true && Ferrari3.Checked != true)
            {
                MessageBox.Show("You must answer all questions!");
            }
            else if (Porsche1.Checked != true && Porsche2.Checked != true && Porsche3.Checked != true)
            {
                MessageBox.Show("You must answer all questions!");
            }
            else
              AllChecked = true;
            if (AllChecked)
            {
                foreach (var radioButton in this.Controls.Cast<Control>().SelectMany(c => c.Controls.OfType<RadioButton>())) radioButton.Enabled = false;
                foreach (var radioButton in this.Controls.OfType<RadioButton>()) radioButton.Enabled = false;
                //Ferrari3 is the second radio button and ferrari2 is the third radio button
                if (Ferrari3.Checked == true)
                {
                    FerrariCheck2.Visible = true;
                    thisplayer.Score = thisplayer.Score + 1 + timeBonus;
                    txtScoreBoard.Text = thisplayer.Score.ToString();
                    FileManager.UpdateHighScore(thisplayer);
                    txtHighScore.Text = thisplayer.HighScore.ToString();
                }
                else if (Ferrari2.Checked == true)
                    FerrariWrong3.Visible = true;

                else if (Ferrari1.Checked == true)
                    FerrariWrong1.Visible = true;

                //Porches3 is the first radio button and Porche1 is the third radio button
                if (Porsche3.Checked == true)
                {
                    PorscheCheck1.Visible = true;
                    thisplayer.Score = thisplayer.Score + 1 + timeBonus;
                    txtScoreBoard.Text = thisplayer.Score.ToString();
                    FileManager.UpdateHighScore(thisplayer);
                    txtHighScore.Text = thisplayer.HighScore.ToString();
                }
                else if (Porsche2.Checked == true)
                    PorscheWrong2.Visible = true;

                else if (Porsche1.Checked == true)
                    PorscheWrong3.Visible = true;


                if (Lamborghini3.Checked == true)
                {
                    LamboCheck3.Visible = true;
                    thisplayer.Score = thisplayer.Score + 1 + timeBonus;
                    txtScoreBoard.Text = thisplayer.Score.ToString();
                    FileManager.UpdateHighScore(thisplayer);
                    txtHighScore.Text = thisplayer.HighScore.ToString();
                }
                else if (Lamborghini1.Checked == true)
                    LamboWrong1.Visible = true;

                else if (Lamborghini2.Checked == true)
                    LamboWrong2.Visible = true;
            }
            btnNext.Enabled = true;
            btnCheckAnswer.Enabled = false;
            thisplayer.Progression = 3;
            FileManager.UpdateProgresion(thisplayer);
            
           
        }
        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {

            answerCheck();

        }
        private void CorrectionReset()
        {
            LamboWrong1.Visible = false;
            LamboWrong2.Visible = false;
            LamboCheck3.Visible = false;
            FerrariCheck2.Visible = false;
            FerrariWrong1.Visible = false;
            FerrariWrong3.Visible = false;
            PorscheCheck1.Visible = false;
            PorscheWrong2.Visible = false;
            PorscheWrong3.Visible = false;
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new ComboBoxQuestion(thisplayer);
            Home.ShowDialog();
            this.Close();
        }
        private void FormStart()
        {
            CorrectionReset();
            questionTimer = new Timer();
            questionTimer.Interval = 1000; // 1 second
            questionTimer.Tick += QuestionTimer_Tick;
            if (timerfinished == false)
                StartNewQuestion();
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
            
            

            // updating quick resume
            thisplayer.Progression = 2;
            FileManager.UpdateProgresion(thisplayer);
        }

        private void Question1_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new RadioButtonQuestion(thisplayer);
            Home.ShowDialog();
            this.Close();
        }

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
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
