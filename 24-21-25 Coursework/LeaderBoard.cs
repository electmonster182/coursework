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
    public partial class LeaderBoard : Form
    {
        Player thisplayer;
        public LeaderBoard(Player player)
        {
            thisplayer = player;
            InitializeComponent();
        }
        
        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            txtUsername.Text = thisplayer.Username;
            
            PicBoxAvatar.Image = thisplayer.Avatar;
            txtHighScore.Text = thisplayer.HighScore.ToString();
            LeaderBoardSet();
            // Get the current screen resolution
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Resize the form to a percentage of the screen size
            this.Width = (int)(screenBounds.Width * 0.57);
            this.Height = (int)(screenBounds.Height * 0.54);
        }
        private void LeaderBoardSet()
        {
            List<Player> players = FileManager.ReadPlayersToList();
            players = players.OrderByDescending(x => x.HighScore).ToList();

            if (players.Count > 0)
            {
                lblScore1.Text = players[0].HighScore.ToString();
                lblUser1.Text = players[0].Username;
                PicBoxUser1.Image = players[0].Avatar;
            }
            if (players.Count > 1)
            {
                lblScore2.Text = players[1].HighScore.ToString();
                lblUser2.Text = players[1].Username;
                PicBoxUser2.Image = players[1].Avatar;
            }
            if (players.Count > 2)
            {
                lblScore3.Text = players[2].HighScore.ToString();
                lblUser3.Text = players[2].Username;
                PicBoxUser3.Image = players[2].Avatar;
            }
            if (players.Count > 3)
            {
                lblScore4.Text = players[3].HighScore.ToString();
                lblUser4.Text = players[3].Username;
                PicBoxUser4.Image = players[3].Avatar;
            }
            if (players.Count > 4)
            {
                lblScore5.Text = players[4].HighScore.ToString();
                lblUser5.Text = players[4].Username;
                PicBoxUser5.Image = players[4].Avatar;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Login = new Menu (thisplayer);
            Login.ShowDialog();
            this.Close();
        }

        private void txtScore2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser3_TextChanged(object sender, EventArgs e)
        {

        }

        private void picBackGround_Click(object sender, EventArgs e)
        {

        }
    }
}
