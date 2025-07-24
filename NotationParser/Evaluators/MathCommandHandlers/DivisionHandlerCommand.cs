using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class DivisionHandlerCommand : MathHandler
    {
        public DivisionHandlerCommand(string expression)
        {
            Expression = expression;
            OperatorIndex = Expression.IndexOf('/');
        }

    }
}
