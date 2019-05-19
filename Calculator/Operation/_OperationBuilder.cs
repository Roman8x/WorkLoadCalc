using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operation
{
    /// <summary>
    /// Добавляем комнады в фабрику команд, команды легковесные их можно хранить в словаре 
    /// </summary>
    public  class _OperationBuilder
    {
        public IDictionary<char, IOperation>  Build() {
            var result = new Dictionary<char, IOperation>();
            // Можно отрефакторить и добавить комнады из сборки с помощью рефлексии и переписать что бы фабрика создавала классы по требованию и создавала их по требованию
            IOperation cmd;
            cmd = new Minus();
            result.Add(cmd.operand, cmd);

            cmd = new Plus();
            result.Add(cmd.operand, cmd);


            return result;
        }
    }
}
