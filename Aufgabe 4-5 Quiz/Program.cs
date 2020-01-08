using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace Aufgabe_4_5_Quiz
{
    class Program
    {
        public static List<QuizElement> _quizElements = new List<QuizElement>();
        public static int _score = 0;
        public static int _questionsAnswered = 0;

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
            int randQuestion = rnd.Next(0, _quizElements.Count);

            var question = _quizElements[randQuestion];
            question.Display();
            var input = Console.ReadLine();

            _questionsAnswered++;

            var isCorrect = question.CheckAnswer(input.ToLower());

            if (isCorrect)
            {
                _score++;
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
                    string basePath = "QuizElements\\";
                    switch (input)
                    {
                        case 1:
                            question = QuizElementTrueFalse.CreateQuizElement();
                            AddToDatabase<QuizElementTrueFalse>(question, basePath + "TrueFalse.json");
                            break;
                        case 2:
                            question = QuizElementText.CreateQuizElement();
                            AddToDatabase<QuizElementText>(question, basePath + "Text.json");
                            break;
                        case 3:
                            question = QuizElementGuess.CreateQuizElement();
                            AddToDatabase<QuizElementGuess>(question, basePath + "Guess.json");
                            break;
                        case 4:
                            question = QuizElementMultAnswers.CreateQuizElement();
                            AddToDatabase<QuizElementMultAnswers>(question, basePath + "MultAnswers.json");
                            break;
                        case 5:
                            question = QuizElementSingleAnswer.CreateQuizElement();
                            AddToDatabase<QuizElementSingleAnswer>(question, basePath + "SingleAnswer.json");
                            break;
                        default:
                            break;
                    }

                    Console.Write("Saving question.....");

                    if (question != null)
                    {
                        _quizElements.Add(question);
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
            Console.WriteLine("Welcome to Quiz! Your current score is " + _score + " you have answered " + _questionsAnswered + " questions.");
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
            string basePath = "Quizelements\\";
            DeserializeAndAdd<QuizElementGuess>(basePath + "Guess.json");
            DeserializeAndAdd<QuizElementMultAnswers>(basePath + "MultAnswers.json");
            DeserializeAndAdd<QuizElementSingleAnswer>(basePath + "SingleAnswer.json");
            DeserializeAndAdd<QuizElementText>(basePath + "Text.json");
            DeserializeAndAdd<QuizElementTrueFalse>(basePath + "TrueFalse.json");
        }

        static void DeserializeAndAdd<T>(string path)
        {
            string jsonString = File.ReadAllText(path);

            List<T> quizElementList = JsonConvert.DeserializeObject<List<T>>(jsonString);

            foreach(var question in quizElementList)
            {
                _quizElements.Add((QuizElement)(object)question);
            }
        }

        static void AddToDatabase<T>(QuizElement quizElement, string path)
        {
            string jsonString = File.ReadAllText(path);

            List<T> quizElementList = JsonConvert.DeserializeObject<List<T>>(jsonString);

            quizElementList.Add((T)(object)quizElement);

            jsonString = JsonConvert.SerializeObject(quizElementList, Formatting.Indented);

            File.WriteAllText(path, jsonString);

        }
    }
}