using System;

namespace Operations
{
    public static class OperationBuilder
    {
        public static IOperation[] GetOperations()
        {
            return new IOperation[] { new AddOperation(), new SubtractOperation(), new MultiplyOperation(), new DivideOperation(), new PowerOperation(), new GCFOperation() };
        }
    }
}