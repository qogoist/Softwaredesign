using System;

namespace Operations
{
    public class AddOperation : IOperation
    {
        public char OpSymbol => '+';

        public int PerformOperation(int a, int b)
        {
            return a + b;
        }
    }
}