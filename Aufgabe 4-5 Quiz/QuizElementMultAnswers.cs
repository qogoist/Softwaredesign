using System;
using System.Collections.Generic;

namespace Aufgabe_4_5_Quiz
{
    public class QuizElementMultAnswers : QuizElement
    {
        private List<Answer> answers;

        public QuizElementMultAnswers(string question, List<Answer> answers)
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
            Console.WriteLine("Enter the numbers for your answers, separated by a comma (e.g. '1,2,3,4')");
            Console.Write("> ");
        }

        override public bool CheckAnswer(string input)
        {
            try
            {
                string[] inputs = input.Split(",");

                var isCorrect = true;
                for (int i = 0; i < inputs.Length; i++)
                {
                    var j = Int32.Parse(inputs[i]) - 1;

                    if (!answers[j].isTrue)
                        isCorrect = false;
                }

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

        public static QuizElementMultAnswers CreateQuizElement()
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
                        Console.WriteLine("Is this answer true? (Type y/n for true/false)");
                        Console.Write("> ");
                        var input2 = Console.ReadLine().ToLower();

                        if (input2.Equals("y"))
                        {
                            answerList.Add(new Answer(input, true));
                        }
                        else if (input2.Equals("n"))
                        {
                            answerList.Add(new Answer(input, false));
                        }
                        else
                        {
                            throw new System.FormatException();
                        }
                    }
                }

                return new QuizElementMultAnswers(question, answerList);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid input! Please try again.");
                return QuizElementMultAnswers.CreateQuizElement();
            }
        }

    }
}