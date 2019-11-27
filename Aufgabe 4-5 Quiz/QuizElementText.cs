using System;
using System.Collections.Generic;

namespace Aufgabe_4_5_Quiz
{
    public class QuizElementText : QuizElement
    {
        private Answer answer;

        public QuizElementText(string question, Answer answer)
        {
            this.question = question;
            this.answer = answer;
        }

        override public void Display()
        {
            base.Display();
            Console.WriteLine("Enter your answer.");
            Console.Write("> ");
        }

        override public bool CheckAnswer(string input)
        {
            var isTrue = false;

            if (input.Equals(answer.text.ToLower()))
                isTrue = true;

            return isTrue;
        }

        public static QuizElementText CreateQuizElement()
        {
            Console.WriteLine("Please enter your question.");
            Console.Write("> ");
            var question = Console.ReadLine();

            Console.WriteLine("Please enter the correct answer.");
            Console.Write("> ");
            var answerText = Console.ReadLine();

            var answer = new Answer(answerText, true);

            return new QuizElementText(question, answer);
        }
    }
}