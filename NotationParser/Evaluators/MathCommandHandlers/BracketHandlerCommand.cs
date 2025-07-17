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

        public string ReplacedExpression;

        public BracketHandlerCommand(string expression)
        {
            Expression = expression;
        }
        public void Handle(string expression)
        {
            // Logic to handle brackets in the expression
            // This will involve finding the innermost brackets and evaluating them first
            int openBracketIndex = Expression.LastIndexOf('(');
            if (openBracketIndex == -1)
            {
                throw new InvalidOperationException("Mismatched brackets in expression.");
            }
            int closeBracketIndex = Expression.IndexOf(')', openBracketIndex);

            if (closeBracketIndex == -1)
            {
                throw new InvalidOperationException("Mismatched brackets in expression.");
            }

            string replacedExpression = Expression.Substring(openBracketIndex, closeBracketIndex);
            string innerExpression = Expression.Substring(openBracketIndex + 1, closeBracketIndex - openBracketIndex - 1);
        }

        public double Evaluate()
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

            if (expressionParts.Length == 3)
            {
                var leftSideValue = expressionParts[0];
                var operatorSymbol = expressionParts[1];
                var rightSideValue = expressionParts[2];
            }

            return 0.0; // Replace with actual evaluation result
        }


    }
}
