using Calculator.Operation;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {            
            var dictOperations = new _OperationBuilder().Build();
            new Calculator (dictOperations).Run();
        }
    }
}
