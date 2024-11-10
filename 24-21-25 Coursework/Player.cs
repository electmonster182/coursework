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

        public Player()
        {
            username = "";
            password = "";
            avatar = null;
            score = 0;
        }

        public Player(string username, string password, Image avatar,int score)
        {
            Username = username;
            Password = password;
            Avatar = avatar;
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




