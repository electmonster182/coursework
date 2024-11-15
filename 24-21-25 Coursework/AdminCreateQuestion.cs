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
    public partial class AdminCreateQuestion : Form
    {
        
        Player ThisPlayer;
        Questions thisQuestion = new Questions();
        List<Questions> AllQuestions = new List<Questions>();

        public AdminCreateQuestion(Player player)
        {
            ThisPlayer = player;
            InitializeComponent();
        }

        private void btnCreateQuestion_Click(object sender, EventArgs e)
        {
            thisQuestion.Question = txtQuestion.Text;
            thisQuestion.Anwser = txtAnwser.Text;

            
            if (CheckFilledIn())
            {
                thisQuestion.QuestionUsed = false;

                AllQuestions = ReadQuestionsToList();

                try
                {
                    AllQuestions.Add(thisQuestion);

                    Stream sw = File.OpenWrite("Questions.bin");
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(sw, AllQuestions);
                    sw.Close();

                    MessageBox.Show("Question created successfully.");

                  
                    txtQuestion.Text = "";
                    txtAnwser.Text = "";
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show($"Error serializing question: {ex.Message}");
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"File I/O Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please fill in both the question and answer fields.");
            }
        }

        private void EnsureQuestionFileExists()
        {
            string filePath = "Questions.bin";

            if (!File.Exists(filePath))
            {
                try
                {
                   
                    List<Questions> emptyQuestionsList = new List<Questions>();
                    using (Stream sw = File.Open(filePath, FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(sw, emptyQuestionsList);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating questions file: {ex.Message}", "File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckFilledIn()
        {
            return !(string.IsNullOrWhiteSpace(txtQuestion.Text) || string.IsNullOrWhiteSpace(txtAnwser.Text));
        }

        public List<Questions> ReadQuestionsToList()
        {
            List<Questions> allQuestions = new List<Questions>();

            try
            {
                using (Stream sr = File.OpenRead("Questions.bin"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    allQuestions = (List<Questions>)bf.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading questions from file: {ex.Message}");
            }

            return allQuestions;
        }

        private void AdminCreateQuestion_Load(object sender, EventArgs e)
        {
            EnsureQuestionFileExists();
        }

        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new HomePage(ThisPlayer);
            form.ShowDialog();
            this.Close();
        }

    }
}
