using System;

namespace Operations
{
    public class GCFOperation : IOperation
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
