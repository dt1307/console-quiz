using QuizBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Millionaire Quiz");
            Game game = new Game();
            var question = game.GetQuestion();
            DisplayQuestion(question);
            Console.ReadLine();
        }

        static void DisplayQuestion(Question question)
        {
            Console.WriteLine();
            Console.WriteLine(question.Text);
            Console.WriteLine(question.Answer1);
            Console.WriteLine(question.Answer2);
            Console.WriteLine(question.Answer3);
            Console.WriteLine(question.Answer4);
        }
    }
}
