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
            // get only question in a specific category (e.g. $500) using Where method (Microsoft.Linq) = it takes all elem from a list matching given criteria
            var questionFromCurrentCategory = AllQuestions.Where(x => x.Category == CurrentCategory).ToList();
            var number = Randomizer.GetRandomNumber(8);
            var question = questionFromCurrentCategory[number - 1];
            var orderNumbers = Randomizer.GetListOfRandomNumbers(4, 4);
            for (int i = 0; i < orderNumbers.Count; i++)
            {
                question.Answers[i].DisplayOrder = orderNumbers[i];
            }

            question.Answers = question.Answers.OrderBy(x => x.DisplayOrder).ToList();
            return question;
        }
    }
}
