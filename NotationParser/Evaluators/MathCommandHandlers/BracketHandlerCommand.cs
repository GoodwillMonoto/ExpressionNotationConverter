using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class BracketHandlerCommand : MathHandler
    {
        public BracketHandlerCommand(string expression)
        {
            Expression = expression;
        }
        public override void Handle()
        {
            // Logic to handle brackets in the expression
            // This will involve finding the innermost brackets and evaluating them first
            int openBracketIndex = Expression.LastIndexOf('(');
            ReplacementStartIndex = openBracketIndex; // Store the index for replacement later
            if (openBracketIndex == -1)
            {
                throw new InvalidOperationException("Mismatched brackets in expression.");
            }
            int closeBracketIndex = Expression.IndexOf(')', openBracketIndex);
            ReplacementEndIndex = closeBracketIndex; // Store the index for replacement later

            if (closeBracketIndex == -1)
            {
                throw new InvalidOperationException("Mismatched brackets in expression.");
            }

            string ExpressionToReplace = Expression.Substring(openBracketIndex, closeBracketIndex + 1 - openBracketIndex);
            InnerExpression = Expression.Substring(openBracketIndex + 1, closeBracketIndex - 1 - openBracketIndex);

            Evaluate();

            ReplacementStartIndex = openBracketIndex;
            ReplacementEndIndex = closeBracketIndex;

            ResultExpression = $"{Expression.Substring(0, ReplacementStartIndex)}{ResultValue}{Expression.Substring(ReplacementEndIndex + 1)}";
        }
    }
}
