using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _24_21_25_Coursework
{
    [Serializable]
    public class Player
    {
      
        string username;
        string password;
       
        public Player()
        {        
            username = "";
            password = "";      
        }

        public Player(string username, string password)
        {           
            Username = username;
            Password = password;      
        }
        public string Username
        {
            get { return username; }
            set
            {username = value; }
        }

        public string Password
        {
            get { return password; }
            set
            { password = value; }
        }
        public List<Player> readFileToList() // reads player list from .bin file
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
            { 
            }

            return players;
        }
    }
}
