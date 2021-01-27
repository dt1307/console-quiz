using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBackend
{
    public class Game
    {
        public Question GetQuestion()
        {
            Question question = new Question();
            question.Text = "What is the name of brilliant scientiest Einstein?";
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
