using System;
using System.Collections.Generic;

namespace Aufgabe_4_5_Quiz
{
    public class QuizElementGuess : QuizElement
    {
        private float correctAnswer;
        private float tolerance;

        public QuizElementGuess(string question, float correctAnswer, float tolerance)
        {
            this.question = question;
            this.correctAnswer = correctAnswer;
            this.tolerance = tolerance;
        }

        override public void Display()
        {
            base.Display();
            Console.WriteLine("Take a guess!");
            Console.Write("> ");
        }

        override public bool CheckAnswer(string input)
        {
            try
            {
                var guess = Int32.Parse(input);

                var isCorrect = false;

                if (guess == correctAnswer + (correctAnswer * tolerance) || guess == correctAnswer - (correctAnswer * tolerance))
                    isCorrect = true;

                return isCorrect;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid input! Please try again");
                Console.Write("> ");
                input = Console.ReadLine();
                return this.CheckAnswer(input);
            }
        }

        public static QuizElementGuess CreateQuizElement()
        {
            try
            {
                Console.WriteLine("Please enter your question.");
                Console.Write("> ");
                var question = Console.ReadLine();

                Console.WriteLine("Please enter the correct answer.");
                Console.Write("> ");
                float correctAnswer = float.Parse(Console.ReadLine());

                Console.WriteLine("Please enter a tolerance (in percent).");
                Console.Write("> ");
                float tolerance = float.Parse(Console.ReadLine()) / 100;

                return new QuizElementGuess(question, correctAnswer, tolerance);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid Input, please try again.");
                return QuizElementGuess.CreateQuizElement();
            }
        }

    }
}