using System;

namespace Aufgabe_1_Buchstabendreher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte einen kleinen Satz eingeben");
            Console.Write("> ");
            var text = Console.ReadLine();
            string letters = reverseLetters(text);
            string words = reverseWords(text);
            string sentence = reverseSentence(text);
            Console.WriteLine(letters + "\n" + words + "\n" + sentence);
        }

        // Reverses the string entirely, character by character. This reverses the order of the words, as well as the characters within the words.
        static string reverseLetters(string s)
        {
            string output = "";
            for (int i = 0; i < s.Length; i++)
            {
                output += s[s.Length - i - 1];
            }

            return output;
        }

        // Reverses the order of the words, but not the characters within the words. Separates on whitespace.
        static string reverseWords(string s)
        {
            string output = "";
            string[] sa = s.Split(" ");

            for (int i = 0; i < sa.Length; i++)
            {
                output += sa[sa.Length - i - 1];

                if (i != sa.Length - 1)
                    output += " ";
            }

            return output;
        }

        // Reverses the characters in the words, but leaves the order of the words untouched.
        // Reverses the order of the words first via reverseWords, then reverses the entire string via reverseLetters.
        static string reverseSentence(string s)
        {
            string output;
            output = reverseWords(reverseLetters(s));

            return output;
        }
    }
}
