using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class MathHandler : IMathCommandHandler
    {
        public decimal? ResultValue;
        public string Expression;
        protected string InnerExpression;
        public string ExpressionToReplace;
        public int ReplacementStartIndex;
        public int ReplacementEndIndex;
        public string ResultExpression;
        public int OperatorIndex;
        public virtual void Handle()
        {
            int leftNumberStart = Expression.Substring(0,OperatorIndex - 1).LastIndexOf(' ', 0);
            int rightNumberEnd = Expression.IndexOf(' ', OperatorIndex + 2);

            if (leftNumberStart == - 1)
            {
                leftNumberStart = 0; // Start from the beginning if no space found
            }

            if (rightNumberEnd == -1)
            {
                rightNumberEnd = Expression.Length; // End at the last character if no space found
            }

            ReplacementStartIndex = leftNumberStart;
            ReplacementEndIndex = rightNumberEnd;

            InnerExpression = Expression.Substring(ReplacementStartIndex , ReplacementEndIndex - ReplacementStartIndex);

            Evaluate();

            ResultExpression = $"{Expression.Substring(0, ReplacementStartIndex)}{ResultValue}{Expression.Substring(ReplacementEndIndex)}";
        }

        protected virtual void Evaluate()
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
