using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.NotationExpressions
{
    public class InfixExpression
    {
        public string Mathexpression;
        public MathOperator MathOperator;

        public InfixExpression(string expression)
        {
            Mathexpression = expression;
        }

        public InfixExpression(string leftExpression, string rightExpression, MathOperator mathOperator)
        {
            Mathexpression = $"{leftExpression} {mathOperator.OperatorToken} {rightExpression}";
            MathOperator = mathOperator;
        }

    }
}
