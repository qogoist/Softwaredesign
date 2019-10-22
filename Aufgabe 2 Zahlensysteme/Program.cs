using System;
using System.Collections.Generic;

namespace Aufgabe_2_Zahlendreher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in the following order: The original number, its base, the target base. (Each separated by commas.");
            var inputString = Console.ReadLine().Split(",");
            var x = Int32.Parse(inputString[0]);
            var fromBase = Int32.Parse(inputString[1]);
            var toBase = Int32.Parse(inputString[2]);

            var y = ConvertNumberToBaseFromBase(x, fromBase, toBase);

            Console.WriteLine(x + " base " + fromBase + " = " + y + " base " + toBase);
        }

        public static int ConvertToBaseFromDecimal(int toBase, int dec)
        {
            if (dec < 0 || dec > 1023)
                throw new IndexOutOfRangeException();

            /*int mod = dec % toBase;
            int next = dec / toBase;
            if (next != 0)
                next = ConvertToBaseFromDecimal(toBase, next);

            string output = next.ToString() + mod.ToString();

            return Int32.Parse(output);*/

            var result = 0;
            var power = 0;

            while (dec != 0)
            {
                int mod = dec % toBase;
                dec = dec / toBase;

                result += (int)Math.Pow(10, power) * mod;
                power++;
            }

            return result;
        }

        public static int ConvertToDecimalFromBase(int fromBase, int number)
        {
            int result = 0;
            char[] numArray = number.ToString().ToCharArray();

            for (int i = 0; i < numArray.Length; i++)
            {
                var currentPos = (int)Char.GetNumericValue(numArray[numArray.Length - i - 1]);
                var multiplier = (int)Math.Pow(fromBase, i);

                result += currentPos * multiplier;
            }

            return result;
        }

        public static int ConvertNumberToBaseFromBase(int number, int fromBase, int toBase)
        {
            if (Math.Min(fromBase, toBase) < 2 || Math.Max(fromBase, toBase) > 10)
                throw new IndexOutOfRangeException();

            var dec = ConvertToDecimalFromBase(fromBase, number);
            var result = ConvertToBaseFromDecimal(toBase, dec);

            return result;
        }

        //DEPRECIATED
        public static int ConvertDecimalToHexal(int dec)
        {
            if (dec < 0 || dec > 1023)
                throw new IndexOutOfRangeException();

            int mod = dec % 6;
            int next = dec / 6;
            if (next != 0)
                next = ConvertDecimalToHexal(next);

            string output = next.ToString() + mod.ToString();

            return Int32.Parse(output);
        }

        public static int ConvertHexalToDecimal(int hex)
        {
            int result = 0;
            char[] hexArray = hex.ToString().ToCharArray();
            Array.Reverse(hexArray);

            for (int i = 0; i < hexArray.Length; i++)
            {
                var currentPos = (int)Char.GetNumericValue(hexArray[i]);
                var multiplier = (int)Math.Pow(6, i);

                result += currentPos * multiplier;
            }

            return result;
        }
    }
}
