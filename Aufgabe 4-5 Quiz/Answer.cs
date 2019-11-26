using System;

namespace Aufgabe_4_5_Quiz
{
    public class Answer
    {
        public string text { get; private set; }
        public bool isTrue { get; set; }

        public Answer(string text, bool isTrue)
        {
            this.text = text;
            this.isTrue = isTrue;
        }
    }
}