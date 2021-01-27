using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuizBackend
{
    public class Game
    {
        // constructor class that intialize 
        public Game()
        {
            CurrentCategory = "$500";
            UserPrize = "$0";
            CreateCategories();
            CreateQuestions();
        }
        public List<Question> AllQuestions { get; set; }
        public List<string> Categories { get; set; }
        public string CurrentCategory { get; set; }
        public string UserPrize { get; set; }

        // method that creates the game categories
        private void CreateCategories()
        {
            Categories = new List<string>()
            {
                "$500",
                "$1 000",
                "$2 000",
                "$5 000",
                "$10 000",
                "$20 000",
                "$50 000",
                "$75 000",
                "$150 000",
                "$250 000",
                "$500 000",
                "$1 000 000"
            };
        }

        // method that converts json file to list of questions
        private void CreateQuestions()
        {
            var path = Directory.GetCurrentDirectory() + "\\questions.json";
            var content = File.ReadAllText(path);
            AllQuestions = JsonConvert.DeserializeObject<List<Question>>(content);
        }
        public Question GetQuestion()
        {
            Question question = new Question();
            question.Text = "What is the name of brilliant scientiest Einstein?";
            question.Category = "$500";
            question.Answers = new List<Answer>();
            for (int i = 0; i < 4; i++)
            {
                Answer answer = new Answer
                {
                    Id = i + 1,
                    IsCorrect = i == 0,
                    Text = i == 0 ? "Albert" : i == 1 ? "Anthony" : i == 2 ? "Aaron" : "Andrew"
                };
                question.Answers.Add(answer);
            }
            return question;
        }
    }
}
