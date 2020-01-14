using System;

namespace Operations
{
    public interface IOperation
    {
        char OpSymbol { get; }
        int PerformOperation(int a, int b);
    }
}