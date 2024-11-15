using _24_21_25_Coursework;
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
    public partial class Drag_Drop : Form
    {
        public static String selectedPicture;        
        private Image originalPicBoxAImage;
        private Image originalPicBoxBImage;
        private Image originalPicBoxCImage;
        
        
        public Player thisPlayer { get; set; }
        //List<Player> players = new List<Player>();
        private Timer questionTimer;
        private int timeRemaining;

        public Drag_Drop(Player player)
        {
            InitializeComponent();
            thisPlayer = player;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void StartNewQuestion()
        {
            timeRemaining = 30; // Start countdown from 30 seconds
            questionTimer.Start();
        }
        bool timerfinished = false;
        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;

            // Update the timer display (optional text box or label)
            txtTimer.Text = timeRemaining.ToString();

            if (timeRemaining <= 0)
            {
                questionTimer.Stop();
                MessageBox.Show("Time's up!");
                btnCheckDragAwnser_Click_1(null, null); // Trigger answer check
                timerfinished = true;
            }
        }
        private void Drag_Drop_Load(object sender, EventArgs e)
        {
            questionTimer = new Timer();
            questionTimer.Interval = 1000; // 1 second
            questionTimer.Tick += QuestionTimer_Tick;
            if(timerfinished == false)
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
            txtUsername.Text = thisPlayer.Username;
            txtScoreBoard.Text = thisPlayer.Score.ToString();
            PicBoxAvatar.Image = thisPlayer.Avatar;
            originalPicBoxCImage = PicBoxC.Image;
            originalPicBoxAImage = PicBoxA.Image;
            originalPicBoxBImage = PicBoxB.Image;
            PicBox1.AllowDrop = true;
            PicBox2.AllowDrop = true;
            PicBox3.AllowDrop = true;
            PicBoxA.AllowDrop = true;
            PicBoxB.AllowDrop = true;
            PicBoxC.AllowDrop = true;
            PicBoxCheck1.Visible = false;
            PicBoxCheck2.Visible = false;
            PicBoxCheck3.Visible = false;
            PicBoxWrong1.Visible = false;
            PicBoxWrong2.Visible = false;
            PicBoxWrong3.Visible = false;
            txtHighScore.Text = thisPlayer.HighScore.ToString();
            txtScoreBoard.Text = "0";
            thisPlayer.Score = 0;
        }
        private void btnCheckDragAwnser_Click(object sender, EventArgs e)
        {
            

        }
        private void PicBoxA_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void PicBoxB_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PicBoxC_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }       
        private void PicBox1_MouseDown(object sender, MouseEventArgs e)
        {
            selectedPicture = PicBox1.Tag.ToString();
            PicBox1.DoDragDrop(PicBox1.Image, DragDropEffects.Copy);
            
        }
        private void PicBox2_MouseDown_1(object sender, MouseEventArgs e)
        {           
            selectedPicture = PicBox2.Tag.ToString();
            PicBox2.DoDragDrop(PicBox2.Image, DragDropEffects.Copy);
           
        }

        private void PicBox3_MouseDown_1(object sender, MouseEventArgs e)
        {
            selectedPicture = PicBox3.Tag.ToString();
            PicBox3.DoDragDrop(PicBox3.Image, DragDropEffects.Copy);
           
        }
        bool AnwserA = false;
        bool AnwserB = false;
        bool AnwserC = false;
        private void PicBoxA_DragDrop(object sender, DragEventArgs e)
        {
           
            RemoveImageFromOtherBoxes(PicBoxA, (Image)e.Data.GetData(DataFormats.Bitmap));

          
            PicBoxA.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            if (selectedPicture == PicBoxA.Tag.ToString())
            {
                
                AnwserA = true;
            }
            else
            {

             
                AnwserA = false;
            }

        }
        private void PicBoxB_DragDrop_1(object sender, DragEventArgs e)
        {
           
           
            RemoveImageFromOtherBoxes(PicBoxB, (Image)e.Data.GetData(DataFormats.Bitmap));

         
            PicBoxB.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            

            if (selectedPicture == PicBoxB.Tag.ToString())
            {
                
                AnwserB = true;
            }
            else
            {

                
                AnwserB = false;
            }

        }
     
        private void PicBoxC_DragDrop(object sender, DragEventArgs e)
        {
                    
            
            RemoveImageFromOtherBoxes(PicBoxC, (Image)e.Data.GetData(DataFormats.Bitmap));

         
            PicBoxC.Image = (Image)e.Data.GetData(DataFormats.Bitmap);

            if (selectedPicture == PicBoxC.Tag.ToString())
            {
               
                AnwserC = true;
            }
            else
            {

                
                AnwserC = false;
            }

        }

     

        private void btnCheckDragAwnser_Click_1(object sender, EventArgs e)
        {          
            PicBoxA.AllowDrop = false;
            PicBoxB.AllowDrop = false;
            PicBoxC.AllowDrop = false;
            txtScoreBoard.Text = "";
            questionTimer.Stop();
            questionTimer.Stop(); // Stop countdown
            int timeBonus = CalculateTimeBonus(timeRemaining);

            if (AnwserA)
            {
                PicBoxCheck1.Visible = true;
                thisPlayer.Score += 1 + timeBonus;
            }
            else
            {
                PicBoxWrong1.Visible = true;
            }

            if (AnwserB)
            {
                PicBoxCheck2.Visible = true;
                thisPlayer.Score += 1 + timeBonus;
            }
            else
            {
                PicBoxWrong2.Visible = true;
            }

            if (AnwserC)
            {
                PicBoxCheck3.Visible = true;
                thisPlayer.Score += 1 + timeBonus;
            }
            else
            {
                PicBoxWrong3.Visible = true;
            }

            UpdateHighScore(thisPlayer);

            btnCheckDragAwnser.Enabled = false;
            txtScoreBoard.Text = thisPlayer.Score.ToString();
            

            btnCheckDragAwnser.Enabled = false;
            txtScoreBoard.Text = thisPlayer.Score.ToString();
            
        }
        private int CalculateTimeBonus(int timeLeft)
        {
            if (timeLeft > 20) return 5;
            if (timeLeft > 10) return 3;
            if (timeLeft > 0) return 1;
            return 0;
        }


        public void UpdateHighScore(Player thisPlayer) //updates a users high score attribute and writes it to the players.bin file
        {
            List<Player> players = new List<Player>();
            players.AddRange(FileManager.ReadPlayersToList());
            if (thisPlayer.Score > thisPlayer.HighScore)  // to change to highscore
            {
                foreach (Player player in players)
                {
                    if (player.Username == thisPlayer.Username)
                    {
                        player.HighScore = thisPlayer.Score;
                        thisPlayer.HighScore = player.HighScore;
                        FileManager.WritePlayersFile(players);
                    }
                }
            }
        }

        private void RemoveImageFromOtherBoxes(PictureBox currentPicBox, Image imageToRemove)
        {
            
            if (PicBoxA != currentPicBox && PicBoxA.Image == imageToRemove)
            {
                PicBoxA.Image = originalPicBoxAImage;
            }

            
            if (PicBoxB != currentPicBox && PicBoxB.Image == imageToRemove)
            {
                PicBoxB.Image = originalPicBoxBImage;
            }

            
            if (PicBoxC != currentPicBox && PicBoxC.Image == imageToRemove)
            {
                PicBoxC.Image = originalPicBoxCImage;
            }
        }

        private void PicBoxAvatar_Click(object sender, EventArgs e)
        {

        }

        private void txtScoreBoard_TextChanged(object sender, EventArgs e)
        {

        }

        private void PicBoxCheck1_Click(object sender, EventArgs e)
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

        private void txtHighScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Drag_Drop(thisPlayer);
            Home.ShowDialog();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new HomePage(thisPlayer);
            form.ShowDialog();
            this.Close();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Drag_Drop_MouseHover(object sender, EventArgs e)
        {
            HelpReset();
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

        private void PicBoxA_MouseHover(object sender, EventArgs e)
        {
            HelpReset();
        }

        private void PicBoxB_MouseHover(object sender, EventArgs e)
        {
            HelpReset();
        }

        private void QuestionTime_Tick(object sender, EventArgs e)
        {

        }

        private void PicBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void PicBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void PicBox3_Click(object sender, EventArgs e)
        {
            
        }
    }

}
