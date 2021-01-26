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
            question.ID = 1;
            question.Text = "What is the name of brilliant scientiest Einstein?";
            question.Answer1 = "Albert";
            question.Answer2 = "Anthony";
            question.Answer3 = "Aaron";
            question.Answer4 = "Andrew";
            return question;
        }
    }
}
