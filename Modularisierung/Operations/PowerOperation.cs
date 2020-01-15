using System;

namespace Operations{
    public class PowerOperation : IOperation
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
}