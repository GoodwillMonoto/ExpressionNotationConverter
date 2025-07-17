using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.NotationExpressions
{
    public class InfixExpressionBuilder
    {
        public string Mathexpression;
        public MathOperator MathOperator;

        public InfixExpressionBuilder(string expression)
        {
            Mathexpression = expression;
        }

        public InfixExpressionBuilder(string leftExpression, MathOperator mathOperator, string rightExpression)
        {
            Mathexpression = $"{leftExpression} {mathOperator.OperatorToken} {rightExpression}";
            MathOperator = mathOperator;
        }

    }
}
