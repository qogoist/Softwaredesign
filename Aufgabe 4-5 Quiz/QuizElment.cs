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
    }

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
                var isCorrect = true;
                string[] inputs = input.Split(",");

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
                Console.WriteLine("Please enter your question.");
                Console.Write("> ");
                var question = Console.ReadLine();

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
                Console.WriteLine("Please enter your question.");
                Console.Write("> ");
                var question = Console.ReadLine();

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