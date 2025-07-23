using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class BracketHandlerCommand : IMathCommandHandler
    {
        public decimal? ResultValue;

        public string Expression;

        private string InnerExpression;

        public string ExpressionToReplace;
        public int ReplacementStartIndex;
        public int ReplacementEndIndex;

        public BracketHandlerCommand(string expression)
        {
            Expression = expression;
        }
        public void Handle()
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

            string ExpressionToReplace = Expression.Substring(openBracketIndex, closeBracketIndex);
            string innerExpression = Expression.Substring(openBracketIndex + 1, closeBracketIndex - openBracketIndex - 1);

            Evaluate();
        }

        private void Evaluate()
        {
            // Logic to evaluate the inner expression
            // This could involve parsing the inner expression and calculating its value
            // For now, we will just return a placeholder value
            if (string.IsNullOrEmpty(InnerExpression))
            {
                throw new InvalidOperationException("Inner expression is empty.");
            }
            var expressionParts = InnerExpression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (expressionParts.Length == 0)
            {
                throw new InvalidOperationException("Inner expression is empty.");
            }

            ResultValue = new InfixToDecimalParser().ToDecimal(InnerExpression);
        }


    }
}
