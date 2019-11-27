using System;
using System.Collections.Generic;

namespace Aufgabe_4_5_Quiz
{
        public class QuizElementSingleAnswer : QuizElement
    {
        private List<Answer> answers;

        public QuizElementSingleAnswer(string question, List<Answer> answers)
        {
            this.question = question;
            this.answers = answers;
        }

        private void shuffleAnswers()
        {
            Random rng = new Random();
            int n = answers.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = answers[k];
                answers[k] = answers[n];
                answers[n] = value;
            }
        }

        override public void Display()
        {
            base.Display();
            this.shuffleAnswers();
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + answers[i].text);
            }
            Console.WriteLine("Enter the number for your answer.");
            Console.Write("> ");
        }

        override public bool CheckAnswer(string input)
        {
            try
            {
                var isCorrect = false;
                var i = Int32.Parse(input) - 1;

                if (this.answers[i].isTrue)
                    isCorrect = true;

                return isCorrect;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid input! Please try again.");
                Console.Write("> ");
                input = Console.ReadLine();
                return this.CheckAnswer(input);
            }
        }

        public static QuizElementSingleAnswer CreateQuizElement()
        {
            try
            {
                string question = QuizElement.promptEnterQuestion();

                var answerList = new List<Answer> { };

                var cont = true;
                while (cont)
                {
                    Console.WriteLine("Please enter a possible answer, alternatively simply press enter to go to the next step.");
                    Console.Write("> ");
                    var input = Console.ReadLine();

                    if (input.Equals(""))
                    {
                        cont = false;
                    }
                    else
                    {
                        answerList.Add(new Answer(input, false));
                    }
                }

                Console.WriteLine("Your answers are: ");
                for (int i = 0; i < answerList.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + answerList[i].text);
                }
                Console.WriteLine("Which answer is correct?");
                Console.Write("> ");
                var correctAnwer = Int32.Parse(Console.ReadLine());
                answerList[correctAnwer].isTrue = true;

                return new QuizElementSingleAnswer(question, answerList);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid input! Please try again.");
                return QuizElementSingleAnswer.CreateQuizElement();
            }
        }

    }
}