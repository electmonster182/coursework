using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_21_25_Coursework
{
    [Serializable]
    public class Player
   {

        string username;
        string password;
        Image avatar;
        int score;
        int highscore;
        bool firstLog;
        bool stopMessage;
        int progression;
        bool admin;
        bool superadmin;
        public Player()
        {
            username = "";
            password = "";
            avatar = null;
            score = 0;
            highscore = 0;
            firstLog = false;
            stopMessage = false;
            progression = 0;
            admin = false;
            superadmin = false;
        }

        public Player(string username, string password, Image avatar,int score,int highscore,bool firstLog,bool stopMessage,int progression,bool admin,bool superadmin)
        {
            Username = username;
            Password = password;
            Avatar = avatar;
            HighScore = highscore;
            FirstLog = firstLog;
            StopMessage = stopMessage;
            Progression = progression;
            Admin = admin;
            SuperAdmin = superadmin;
        }
        public bool SuperAdmin
        {
            get { return superadmin; } // Use the private field
            set { superadmin = value; } // Set the private field
        }
        public bool Admin
        {
            get { return admin; } // Use the private field
            set { admin = value; } // Set the private field
        }
        public int Progression // this is for if then want to continue where they left off
        {
            get { return progression; }
            set { progression = value; }
        }
        public bool StopMessage // stops the message from happening everytime you go home
        {
            get { return stopMessage; }
            set { stopMessage = value; }
        }
        public bool FirstLog // if it is their first time logging in then you will get a intruduction message else you get welcome back message
        {
            get { return firstLog; }
            set { firstLog = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Image Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
        public int Score
        { 
            get { return score; } 
            set { score = value; } 
        }
        public int HighScore
        {
            get { return highscore; }
            set { highscore = value; }
        }
        public List<Player> readFileToList() 
        {
            List<Player> players = new List<Player>();
            Stream sr;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                sr = File.OpenRead("Players.bin");
                players = (List<Player>)bf.Deserialize(sr);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            return players;
        }


    }
}




