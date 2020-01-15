using System;

namespace Operations
{
    public class SubtractOperation : IOperation
    {
        public char OpSymbol => '-';

        public int PerformOperation(int a, int b)
        {
            return a - b;
        }
    }
}