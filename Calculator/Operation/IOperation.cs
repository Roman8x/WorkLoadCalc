using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public  interface IOperation  
    {
        char operand { get; }
        int Calc  (int a, int b);
    }
}
