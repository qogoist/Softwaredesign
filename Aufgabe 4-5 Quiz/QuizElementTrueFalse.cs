using System;
using System.Collections.Generic;

namespace Aufgabe_4_5_Quiz
{
    public class QuizElementTrueFalse : QuizElement
    {
        private bool isTrue;

        public QuizElementTrueFalse(string question, bool isTrue)
        {
            this.question = question;
            this.isTrue = isTrue;
        }

        override public void Display()
        {
            base.Display();
            Console.WriteLine("Answer 'Y' for yes/true, or 'N' for no/false.");
            Console.Write("> ");
        }

        override public bool CheckAnswer(string input)
        {
            if (input.Equals("y") || input.Equals("n"))
            {
                bool playerAnswer = false;

                if (input.Equals("y"))
                    playerAnswer = true;

                if (playerAnswer == isTrue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Your input was invalid. Please try again.");
                input = Console.ReadLine();
                return this.CheckAnswer(input);
            }

        }

        public static QuizElementTrueFalse CreateQuizElement()
        {
            Console.WriteLine("Please enter your question.");
            Console.Write("> ");
            var question = Console.ReadLine();
            var answer = false;

            while (true)
            {
                Console.WriteLine("Is the question true or false?");
                var input = Console.ReadLine();

                if (input.ToLower().Equals("true") || input.ToLower().Equals("false"))
                {
                    if (input.ToLower().Equals("true"))
                        answer = true;

                    break;
                }

                Console.WriteLine("Your input was invalid, please try again.");
            }

            return new QuizElementTrueFalse(question, answer);
        }
    }

}