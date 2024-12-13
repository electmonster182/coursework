using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace _24_21_25_Coursework
{
    [Serializable]
    public class Questions
    {
        string question;
        string anwser;
        bool questionUsed;

        public Questions()//default constructor.
        {
            question = "";
            anwser = "";

            questionUsed = false;

        }
        public Questions(string question, string anwser, bool questionUsed)// full constructor (never used).
        {
            Question = question;
            Anwser = anwser;
            QuestionUsed = questionUsed;

        }
        public string Question
        {
            get { return question; }
            set { question = value; }
        }
        public string Anwser
        {
            get { return anwser; }
            set { anwser = value; }
        }
        public bool QuestionUsed
        {
            get { return questionUsed; }
            set { questionUsed = value; }
        }

        public List<Questions> readQuestionToList() // reads player list from .bin file
        {
            List<Questions> questions = new List<Questions>();
            Stream sr;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                sr = File.OpenRead("Players.bin");
                questions = (List<Questions>)bf.Deserialize(sr);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            return questions;
        }

        public void writeListToFile(List<Questions> Questions) // writes question list to .bin file
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
