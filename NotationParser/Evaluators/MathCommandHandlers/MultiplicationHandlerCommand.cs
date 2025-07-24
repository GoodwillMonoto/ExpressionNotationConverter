using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class MultiplicationHandlerCommand : MathHandler
    {
        public MultiplicationHandlerCommand(string expression)
        {
            Expression = expression;
            OperatorIndex = Expression.IndexOf('*');

        }
    }
}
