using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class AdditionHandlerCommand : MathHandler 
    {
        public AdditionHandlerCommand(string expression)
        {
            Expression = expression;
            OperatorIndex = Expression.IndexOf('+');
        }
        
    }
}
