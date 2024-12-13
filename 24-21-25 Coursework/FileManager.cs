using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _24_21_25_Coursework
{
    public  class FileManager
    {
        

        //Players File Manipulation
        public static List<Player> ReadPlayersToList() //Reads all players from the players.bin file to a list and if the players.bin file doesnt exist yet it will be created
        {
            List<Player> players = new List<Player>();
            try
            {
                using (Stream sr = File.OpenRead("Players.bin"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    if (sr.Length != 0)
                    {
                        players.AddRange((List<Player>)bf.Deserialize(sr));
                    }
                    return players;
                }
            }
            catch (FileNotFoundException)
            {
                using (Stream sr = File.Create("Players.bin"))
                {
                    players = new List<Player>();
                    return players;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return players;
        }
        public static List<Questions> CreateQuestionFile() //Reads all players from the players.bin file to a list and if the players.bin file doesnt exist yet it will be created
        {
            List<Questions> questions = new List<Questions>();
            try
            {
                using (Stream sr = File.Create("Questions.bin"))
                {
                    questions = new List<Questions>();
                    return questions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return questions;
        }
        public static void WritePlayersFile(List<Player> players = null) // Writes all players from a list to the players.bin file
        {
            if (players == null) players = new List<Player>();

            try
            {
                using (Stream sr = File.OpenWrite("Players.bin"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(sr, players);
                    sr.Close();
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("(" + ex + ")");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + "(" + ex + ")");
            }
        }
        public static void UpdateHighScore(Player thisPlayer) //updates a users high score attribute and writes it to the players.bin file
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

        public static void UpdateScore(Player thisPlayer) //updates a users high score attribute and writes it to the players.bin file
        {
            List<Player> players = new List<Player>();
            players.AddRange(FileManager.ReadPlayersToList());
            
                foreach (Player player in players)
                {
                    if (player.Username == thisPlayer.Username)
                    {
                        
                        player.Score = thisPlayer.Score;
                        FileManager.WritePlayersFile(players);
                    }
                }
            
        }
        public static List<Questions> ReadQuestionsToList()
        {
            Stream sr;
            BinaryFormatter bf = new BinaryFormatter();
            List<Questions> AllQuestions = new List<Questions>();
            try
            {
                sr = File.OpenRead("Questions.bin");
                AllQuestions = (List<Questions>)bf.Deserialize(sr);

                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return AllQuestions;
        }
        public static void UpdateProgresion(Player thisPlayer) //updates a users high score attribute and writes it to the players.bin file
        {
            List<Player> players = new List<Player>();
            players.AddRange(FileManager.ReadPlayersToList());
            
                foreach (Player player in players)
                {
                    if (player.Username == thisPlayer.Username)
                    {
                        player.Progression = thisPlayer.Progression;                       
                        FileManager.WritePlayersFile(players);
                    }
                }
            
        }

        public static void writeQuestionToFile(List<Questions> Questions) // writes question list to .bin file
        {
            Stream sw;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                sw = File.OpenWrite("Questions.bin");
                bf.Serialize(sw, Questions);
                sw.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

       
    }
}
