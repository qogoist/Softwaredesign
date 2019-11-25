using System;
using System.Collections.Generic;

namespace Aufgabe_4_5_Quiz
{
    class Program
    {
        public static List<QuizElement> questions = new List<QuizElement>();
        public static int score = 0;
        public static int questionsAnswered = 0;

        static void Main(string[] args)
        {
            //TODO: initialize questions

            while (true)
            {
                Console.WriteLine("Welcome to Quiz! Your current score is " + score + " you have answered " + questionsAnswered + " questions.");
                Console.WriteLine("1. Answer Question");
                Console.WriteLine("2. Create New Question");
                Console.WriteLine("3. Quite Game");
                Console.Write("> ");

                var input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        AnswerQuestion();
                        break;
                    case 2:
                        CreateNewQuizElement();
                        break;
                    case 3:
                        Console.WriteLine("Quitting Game...");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void AnswerQuestion()
        {
            Random rnd = new Random();
            int randQuestion = rnd.Next(0,questions.Count);

            var question = questions[randQuestion];
            question.Display();
            var input = Console.ReadLine();

            questionsAnswered++;

            var isCorrect = question.CheckAnswer(input.ToLower());

            if (isCorrect)
            {
                score++;
                Console.WriteLine("Your answer was correct!");
            }
            else
            {
                Console.WriteLine("Your answer was wrong!");
            }
        }

        static void CreateNewQuizElement()
        {
            Console.WriteLine("These are the available question types, chose one:");
            Console.WriteLine("1. True False Question");
            Console.WriteLine("2. Text Question");
            Console.WriteLine("3. Guess Question");
            Console.WriteLine("4. Multiple Answer Question");
            Console.WriteLine("5. Single Answer Question");
            Console.WriteLine("6. Go Back");
            Console.Write("> ");

            var input = Int32.Parse(Console.ReadLine());

            QuizElement question = null;
            switch (input)
            {
                case 1:
                    question = QuizElementTrueFalse.CreateQuizElement();
                    break;
                case 2:
                    //TODO: Text Quextion
                    break;
                case 3:
                    //TODO: Guess Quextion
                    break;
                case 4:
                    //TODO: Multiple Answer Quextion
                    break;
                case 5:
                    //TODO: Single Answer Quextion
                    break;
                default:
                    break;
            }

            if (question != null)
                questions.Add(question);
        }
    }
}