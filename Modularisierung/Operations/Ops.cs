using System;

namespace Operations
{
    public class Add : IOperation
    {
        public char OpSymbol => '+';

        public int PerformOperation(int a, int b)
        {
            return a + b;
        }
    }

    public class Subtract : IOperation
    {
        public char OpSymbol => '-';

        public int PerformOperation(int a, int b)
        {
            return a - b;
        }
    }

    public class Multiply : IOperation
    {
        public char OpSymbol => '*';

        public int PerformOperation(int a, int b)
        {
            return a * b;
        }
    }

    public class Divide : IOperation
    {
        public char OpSymbol => '/';

        public int PerformOperation(int a, int b)
        {
            return a / b;
        }
    }

    public class Power : IOperation
    {
        public char OpSymbol => '^';

        public int PerformOperation(int a, int b)
        {
            int result = 1;
            for (int i = 0; i < b; i++)
                result *= a;
            return result;
        }
    }

    public class GCF : IOperation
    {
        char IOperation.OpSymbol => '#';

        int IOperation.PerformOperation(int a, int b)
        {
            if (a < b)
            {
                int tmp = a; a = b; b = tmp;
            }
            while (b > 0)
            {
                int c = a % b; a = b; b = c;
            }
            return a;
        }
    }
}
