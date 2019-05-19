using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operation
{
    class FirstOperation : IOperation
    {
        public char operand => throw new NotImplementedException();

        public int Calc(int a, int b)
        {
            return b ;
        }
    }
}
