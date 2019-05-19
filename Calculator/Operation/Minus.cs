using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operation
{
    class Minus : IOperation 
    {
        public char operand => '-';

        public int Calc(int a, int b) => a - b;         
    }
}
