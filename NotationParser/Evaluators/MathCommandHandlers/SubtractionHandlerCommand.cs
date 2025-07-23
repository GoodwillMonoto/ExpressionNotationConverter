using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class SubtractionHandlerCommand : IMathCommandHandler
    {
        public decimal? ResultValue;

        public string Expression;

        private string InnerExpression;

        public string ExpressionToReplace;

        public SubtractionHandlerCommand(string expression)
        {
            Expression = expression;
        }

        public void Handle()
        {
            InnerExpression = Expression;
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
