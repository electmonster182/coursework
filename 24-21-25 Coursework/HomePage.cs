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
    public partial class HomePage : Form
    {
        public Player thisplayer { get; set; }
        public HomePage(Player player)
        {
            InitializeComponent();
            thisplayer = player;
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
            this.Hide();
            Form form = new Drag_Drop(thisplayer);
            form.ShowDialog();
            this.Close();
        }
    }
}
