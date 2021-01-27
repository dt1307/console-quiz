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
            string userAnswer = Console.ReadLine();

            if (ValidateUserAnswer(out int userNumber))
            {
                if (question.Answers[userNumber - 1].IsCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your answer is correct. Congratulations!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, wrong answer!");
                    Console.WriteLine("Game over!");
                }
            }


            Console.ReadLine();
        }

        private static bool ValidateUserAnswer(out int userNumber)
        {
            bool correctKey = false;
            int digit = 0;
            while (!correctKey)
            {
                string userAnswer = Console.ReadLine();
                bool isDigit = int.TryParse(userAnswer, out digit);
                if (isDigit)
                {
                    correctKey = digit < 1 || digit > 4 ? false : true;
                }

                if (!correctKey)
                {
                    Console.WriteLine("You've entered a invalid key.");
                    Console.Write("Please enter the correct answer: 1, 2, 3 or 4 => ");
                }
            }

            userNumber = digit;
            return correctKey;
        }

        static void DisplayQuestion(Question question)
        {
            Console.WriteLine();
            Console.WriteLine($"Question for {question.Category}");
            Console.WriteLine(question.Text);
            foreach (var answer in question.Answers)
            {
                Console.WriteLine($"{answer.DisplayOrder}. {answer.Text}");
            }

            Console.WriteLine();
            Console.Write("Please choose the correct answer: 1, 2, 3 or 4 => ");
        }
    }
}
