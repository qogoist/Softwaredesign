using System;

namespace Übung_7_Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringArr = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
            var stringEnumerator = stringArr.GetEnumerator();
            
            for (int i = 0; i < stringArr.Length; i++)
            {
                stringEnumerator.MoveNext();
                Console.WriteLine(stringEnumerator.Current);
            }

            foreach (var s in stringArr)
            {
                Console.WriteLine(s);
            }
        }
    }
}
