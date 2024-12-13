using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_21_25_Coursework.Menu_Forms
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
            
        }

        private void lbPercentage_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {     
            // Update Progress Bar
            LoadingBar.Increment(1); // Increment by 1% every tick
            lbPercentage.Text = $"{LoadingBar.Value}%"; // Display percentage

            // Check if loading is complete
            if (LoadingBar.Value == 100)
            {
                Timer.Stop(); // Stop the timer
                this.Hide();
                Form Login = new LogIn();
                Login.ShowDialog();
                this.Close(); // Hide the loading form
            }
       }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            // Get the current screen resolution
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Resize the form to a percentage of the screen size
            this.Width = (int)(screenBounds.Width * 0.57);
            this.Height = (int)(screenBounds.Height * 0.54);



            Timer.Interval = 149; // Set interval to 50ms (100% in ~5 seconds)
            Timer.Start();


            

            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\BackGround Video.mp4");
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.URL = videoPath; 
            axWindowsMediaPlayer1.settings.setMode("loop", true); 
            axWindowsMediaPlayer1.uiMode = "none"; 
            axWindowsMediaPlayer1.stretchToFit = true;
        }
    }
}
