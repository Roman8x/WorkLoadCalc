using System;
using System.Collections;
using System.Collections.Generic;

namespace workload
{
    class Program
    {
        static void Main(string[] args)
        {
            new WorkServerManager (3).Run();
        }
    }
}
