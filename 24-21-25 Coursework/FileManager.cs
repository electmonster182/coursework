using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _24_21_25_Coursework
{
    public static class FileManager
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
    }
}
