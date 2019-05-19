using Calculator.Operation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Calculator
    {
        private readonly IDictionary<char, IOperation>  operations  ;
        private readonly IDictionary<string, int> varableDict = new  Dictionary<string, int>();

        public Calculator(IDictionary<char, IOperation> operations)
        {
            this.operations = operations;
        }

        public void Run()
        {
            while (true)
            {
                var str = Console.ReadLine();
                if ("exit".Equals(str))
                    return;
                try
                {                    
                    var operands = str.Trim ().Split(" ");
                    if (operands.Length < 3)
                        throw new Exception("Минимальная длина 3 значения, два операнда и действие ");

                    string  varableName = string.Empty;
                    var nextSimbol = 0;
                    if ("=".Equals(operands[1]))
                    {                   // 0 1 2
                        nextSimbol = 2; // a = b  + 3
                        varableName = ParseVarbleName(operands[0]);
                    }

    
                    IOperation cmd = new FirstOperation();
                    int result = 0;
                    // Идем до тех пор пока не встретим конец строки
                    do   {                        
                        int value = ParseNextValue(operands [nextSimbol]);
                        result = cmd.Calc(result, value);
                        if (++nextSimbol > operands.Length-1)
                            break; // Больше команд нет 
                        var cmdName = Convert.ToChar(operands[nextSimbol++]);
                        if  (!operations.TryGetValue (cmdName, out cmd))                        
                            throw new Exception($"Неизвестная команда {cmdName}");                        
                    } while ( cmd != null ) ;

                  

                    Console.WriteLine(result);
                    if (!(string.IsNullOrEmpty (varableName) ))
                        varableDict[varableName] = result;
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string ParseVarbleName(string varibaleName)
        {
            if (CheckCanVaribaleName (varibaleName))
                return varibaleName;
            throw new Exception("Имя переменной может иметь только символы латинского алфавита");
        }


        private bool CheckCanVaribaleName ( string varName)
        {
            return Regex.IsMatch(varName, "^[a-zA-Z]*$");        
        }

        private int ParseNextValue(string value )
        {            
            if (CheckCanVaribaleName (value))
                // Упадет если нет такого значения в словаре 
                return varableDict[value];
            else
                // Упадет если не сможет распарсить строку в цифры
                return int.Parse(value);
        }
    }
}
