using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _24_21_25_Coursework
{
    public partial class Random_Question : Form
    {
        List<Questions> questions = new List<Questions>();
        Questions thisQuestion;
        Player thisplayer;
        
        public Random_Question(Player player)
        {
            InitializeComponent();
            //ReadQuestionsToList();
            thisplayer = player;
        }

        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Random_Question_Load(object sender, EventArgs e)
        {
            ChooseRandomQuestion();
        }
        public List<Questions> ReadQuestionsToList()
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
        public void ChooseRandomQuestion()
        {

            List<Questions> questions = ReadQuestionsToList();

          
            var unusedQuestions = questions.Where(q => !q.QuestionUsed).ToList();

           
            if (unusedQuestions.Count == 0)
            {
                MessageBox.Show("All questions have been used. Resetting them.");
                ResetQuestionsToUnused(questions);

               
                unusedQuestions = questions.Where(q => !q.QuestionUsed).ToList();
            }

          
            Random random = new Random();
            int randomIndex = random.Next(0, unusedQuestions.Count);
            Questions selectedQuestion = unusedQuestions[randomIndex];

          
            txtQuestion.Text = selectedQuestion.Question;

           
            selectedQuestion.QuestionUsed = true;

            
            SaveQuestions(questions);
        }
        public void ResetQuestionsToUnused(List<Questions> questions)
        {
            foreach (var question in questions)
            {
                question.QuestionUsed = false;
            }

            
            SaveQuestions(questions);
        }
        private void SaveQuestions(List<Questions> questions)
        {
            try
            {
                
                using (Stream sw = File.OpenWrite("Questions.bin"))
                {
                    
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(sw, questions);
                }

                Console.WriteLine("Questions have been saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving questions: {ex.Message}");
            }
        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Login = new HomePage(thisplayer);
            Login.ShowDialog();
            this.Close();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string userAnswer = txtAwser.Text.Trim();

        //    // Compare the user's answer with the correct answer
        //    if (userAnswer.Equals(currentQuestion.Answer, StringComparison.OrdinalIgnoreCase))
        //    {
        //        MessageBox.Show("Correct answer!");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Incorrect answer. Try again!");
        //    }

        //    // Optionally, mark the question as used after checking the answer
        //    currentQuestion.QuestionUsed = true;

        //    // Save the updated questions list to the file
        //    SaveQuestions(questions);

        //    // Move to the next question
        //    ChooseRandomQuestion();
        //}
    }
}
