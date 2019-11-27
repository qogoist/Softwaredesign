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
            AddDefaultQuestions();

            while (true)
            {
                DisplayMainMenu();

                try
                {
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
                catch (System.FormatException)
                {
                    Console.WriteLine("Input was in the wrong format, try again.");
                }

            }
        }

        static void AnswerQuestion()
        {
            Random rnd = new Random();
            int randQuestion = rnd.Next(0, questions.Count);

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
            while (true)
            {
                DisplayQuestionTypes();

                try
                {
                    var input = Int32.Parse(Console.ReadLine());

                    QuizElement question = null;
                    switch (input)
                    {
                        case 1:
                            question = QuizElementTrueFalse.CreateQuizElement();
                            break;
                        case 2:
                            question = QuizElementText.CreateQuizElement();
                            break;
                        case 3:
                            question = QuizElementGuess.CreateQuizElement();
                            break;
                        case 4:
                            question = QuizElementMultAnswers.CreateQuizElement();
                            break;
                        case 5:
                            question = QuizElementSingleAnswer.CreateQuizElement();
                            break;
                        default:
                            break;
                    }

                    Console.Write("Saving question.....");

                    if (question != null)
                    {
                        questions.Add(question);
                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Input had the wring format, try again!");
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Quiz! Your current score is " + score + " you have answered " + questionsAnswered + " questions.");
            Console.WriteLine("1. Answer Question");
            Console.WriteLine("2. Create New Question");
            Console.WriteLine("3. Quit Game");
            Console.Write("> ");
        }

        static void DisplayQuestionTypes()
        {
            Console.WriteLine("These are the available question types, chose one:");
            Console.WriteLine("1. True False Question");
            Console.WriteLine("2. Text Question");
            Console.WriteLine("3. Guess Question");
            Console.WriteLine("4. Multiple Answer Question");
            Console.WriteLine("5. Single Answer Question");
            Console.WriteLine("6. Go Back");
            Console.Write("> ");
        }

        static void AddDefaultQuestions()
        {
            questions.Add(new QuizElementTrueFalse("Softwaredesign is a lot of fun.", true));
            questions.Add(new QuizElementText("Who wrote this program?", new Answer("Jonas Haller", true)));
            questions.Add(new QuizElementGuess("How many fingers do you have?", 10f, 0.2f));
            questions.Add(new QuizElementMultAnswers("What buildings exist at the HFU?", new List<Answer> { new Answer("A", true), new Answer("B", true), new Answer("Z", false), new Answer("X", false) }));
            questions.Add(new QuizElementSingleAnswer("Is programming an art?", new List<Answer> { new Answer("Yes", false), new Answer("No", false), new Answer("Depends", true) }));
        }
    }
}