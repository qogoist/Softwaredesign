using System;
using System.Collections.Generic;

namespace Aufgabe_4_5_Quiz
{
    public abstract class QuizElement
    {
        protected string question;

        public virtual void Display()
        {
            Console.WriteLine(question);
        }
        public abstract bool CheckAnswer(string input);

        protected static string promptEnterQuestion()
        {
            Console.WriteLine("Please enter your question.");
            Console.Write("> ");
            string question = Console.ReadLine();

            return question;
        }
    }
}