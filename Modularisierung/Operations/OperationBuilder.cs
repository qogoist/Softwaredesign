using System;

namespace Operations
{
    public static class OperationBuilder
    {
        public static IOperation[] GetOperations()
        {
            return new IOperation[] { new Add(), new Subtract(), new Multiply(), new Divide(), new Power(), new GCF() };
        }
    }
}